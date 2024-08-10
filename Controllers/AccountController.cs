using ExaminationSystem.DTO.Accounts;
using ExaminationSystem.Mediators.Accounts;
using ExaminationSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthMediator _authMediator;

        public AccountController(IAuthMediator authMediator)
        {
            _authMediator = authMediator;
        }

        [HttpPost]
        public async Task<ResultViewModel<AuthResponseDTO>> RegisterAsync(RegisterRequestDTO registerDTO)
        {
            var result = await _authMediator.Register(registerDTO);
            if (!result.IsAuthenticated)
            {
                return new ResultViewModel<AuthResponseDTO>
                {
                    IsSuccess = false,
                    Data = result
                };
            }

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return new ResultViewModel<AuthResponseDTO>
            {
                IsSuccess = true,
                Data = result,
            };
        }

        [HttpPost]
        public async Task<ResultViewModel<AuthResponseDTO>> Login(LoginRequestDTO loginDTO)
        {
            var result = await _authMediator.Login(loginDTO);

            if (!result.IsAuthenticated)
            {
                return new ResultViewModel<AuthResponseDTO>
                {
                    IsSuccess = false,
                    Data = result
                };
            }

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return new ResultViewModel<AuthResponseDTO>
            {
                IsSuccess = true,
                Data = result,
            };
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expiration)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expiration.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None,
            };

            Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
        }

    }
}
