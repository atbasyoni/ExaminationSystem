using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.DTO.Accounts
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
