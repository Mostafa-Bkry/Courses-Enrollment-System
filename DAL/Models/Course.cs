
namespace DAL.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(600)]
        public string? Description { get; set; }

        public int MaxCapacity { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } 
            = new HashSet<Enrollment>();
    }
}
