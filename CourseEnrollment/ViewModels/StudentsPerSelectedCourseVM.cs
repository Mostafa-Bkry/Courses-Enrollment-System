namespace CourseEnrollment.ViewModels
{
    public class StudentsPerSelectedCourseVM
    {
        public int CrsId { get; set; }
        public List<Student> CrsStudents { get; set; } = new List<Student>();
    }
}
