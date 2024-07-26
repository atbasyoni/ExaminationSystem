namespace ExaminationSystem.Models
{
    public class BaseModel
    {
        public int ID { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}
