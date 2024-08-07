using ExaminationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExaminationSystem.Helpers
{
    public class JWTHandler
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly JWT _jwt;

        public JWTHandler(IConfiguration configuration, UserManager<User> userManager, IOptions<JWT> jwt)
        {
            _configuration = configuration;
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        public async Task<JwtSecurityToken> GetTokenAsync(User user)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwt.ValidIssuer,
                audience: _jwt.ValidAudiance,
                claims: await GetClaimAsync(user),
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: GetSigningCredentials()
            );

            return jwt;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaimAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

    }
}
