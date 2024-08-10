using ExaminationSystem.DTO.Accounts;

namespace ExaminationSystem.Mediators.Accounts
{
    public interface IAuthMediator
    {
        Task<AuthResponseDTO> Register(RegisterRequestDTO registerDTO);
        Task<AuthResponseDTO> Login(LoginRequestDTO loginDTO);
    }
}
