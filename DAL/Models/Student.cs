
namespace DAL.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(500)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [MaxLength(150)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be like that example@domain.com")]
        public string Email { get; set; }

        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "Must be exactly 14 digits.")]
        [Display(Name = "National ID")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Must contain only numbers & be exactly 14 digits.")]
        public string NID { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Must be exactly 11 digits.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Must contain only numbers & be exactly 11 digits.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } 
            = new HashSet<Enrollment>();
    }
}
