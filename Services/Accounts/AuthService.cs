using ExaminationSystem.DTO.Accounts;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ExaminationSystem.Services.Accounts
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<User> userManager, 
            RoleManager<IdentityRole<int>> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> Login(LoginRequestDTO loginDTO)
        {
            var authResponse = new AuthResponseDTO();

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                authResponse.Message = "Email or Password is incorrect";
                return authResponse;
            }

            var token = await CreatJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            authResponse.IsAuthenticated = true;
            authResponse.Roles = roles.ToList();
            authResponse.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authResponse.ExpiresOn = token.ValidTo;

            if (user.RefreshTokens.Any(r => !r.IsDeleted))
            {
                var activeRefershToken = user.RefreshTokens.SingleOrDefault(r => !r.IsDeleted);
                authResponse.RefreshToken = activeRefershToken.Token;
                authResponse.RefreshTokenExpiration = activeRefershToken.ExpiredOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authResponse.RefreshToken = refreshToken.Token;
                authResponse.RefreshTokenExpiration = refreshToken.ExpiredOn;
            }

            return authResponse;
        }

        public async Task<AuthResponseDTO> Register(RegisterRequestDTO registerDTO)
        {
            if (await _userManager.FindByNameAsync(registerDTO.UserName) is not null)
            {
                return new AuthResponseDTO()
                {
                    Message = "Username is alerady registered!"
                };
            }

            if (await _userManager.FindByEmailAsync(registerDTO.Email) is not null)
            {
                return new AuthResponseDTO() 
                { 
                    Message = "Email is already registered!" 
                };
            }

            var user = registerDTO.MapOne<User>();

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthResponseDTO() 
                { 
                    Message = errors
                };
            }

            if (registerDTO.Type == "Instructor")
                await _userManager.AddToRoleAsync(user, "Instructor");
            else if (registerDTO.Type == "Student")
                await _userManager.AddToRoleAsync(user, "Student");

            var token = await CreatJwtToken(user);

            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new AuthResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
                IsAuthenticated = true,
                Message = "Registration Successed",
                Roles = new List<string>() { "User" },
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiredOn
            };

        }

        private async Task<JwtSecurityToken> CreatJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            double.TryParse(_configuration["JWT:DurationInMintues"], out double DurationInMintues);

            var expiryTime = DateTime.UtcNow.AddMinutes(DurationInMintues);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudiance"],
                claims: claims,
                expires: expiryTime,
                signingCredentials: signInCredentials
            );
            return token;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var RandomNumber = new Byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(RandomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpiredOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow,
            };
        }

    }
}
