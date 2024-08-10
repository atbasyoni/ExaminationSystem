using ExaminationSystem.DTO.Accounts;
using ExaminationSystem.Services.Accounts;

namespace ExaminationSystem.Mediators.Accounts
{
    public class AuthMediator : IAuthMediator
    {
        private readonly IAuthService _authService;

        public AuthMediator(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponseDTO> Login(LoginRequestDTO loginDTO)
        {
            return await _authService.Login(loginDTO);
        }

        public async Task<AuthResponseDTO> Register(RegisterRequestDTO registerDTO)
        {
            return await _authService.Register(registerDTO);
        }
    }
}
