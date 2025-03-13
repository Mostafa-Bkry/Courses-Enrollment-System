using System.ComponentModel.DataAnnotations;

namespace CourseEnrollment.ViewModels
{
    public class EnrollmentFormVM
    {
        [Display(Name = "Choose Course")]
        public int selectedCrsId { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

        [Display(Name = "Choose Students")]
        public List<int> SelectedStudentsIds { get; set; } = new List<int>();

        public List<EnrollFormSelectStudentDataVM> Students { get; set; } 
            = new List<EnrollFormSelectStudentDataVM>();
    }
}
