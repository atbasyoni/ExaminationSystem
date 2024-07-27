using ExaminationSystem.Models;

namespace ExaminationSystem.Models
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Student> Students { get; set; }
    }
}
