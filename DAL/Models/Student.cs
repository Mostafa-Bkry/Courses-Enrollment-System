
namespace DAL.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string FullName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(14, MinimumLength = 14)]
        public string NID { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string? PhoneNumber { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } 
            = new HashSet<StudentCourse>();
    }
}
