using ExaminationSystem.DTO.Accounts;

namespace ExaminationSystem.Services.Accounts
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Register(RegisterRequestDTO registerDTO);
        Task<AuthResponseDTO> Login(LoginRequestDTO loginDTO);
    }
}
