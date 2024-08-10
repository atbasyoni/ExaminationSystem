using ExaminationSystem.Enums;
using Microsoft.AspNetCore.Identity;

namespace ExaminationSystem.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AddressID { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
