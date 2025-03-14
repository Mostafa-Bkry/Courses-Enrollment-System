
namespace Repository.Interfaces
{
    public interface IEnrollmentsRepository
    {
        List<Enrollment> GetAll();
        Enrollment GetById(int crsId, int stdId);
        List<Student> GetStudentsPerCourse(int crsId);
        List<Course> GetCoursesPerStudent(int stdId);

        bool Add(List<Enrollment> enrollments);
        bool Delete(int crsId, int stdId);
    }
}
