
namespace Repository.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        ICoursesRepository Courses { get; }
        IStudentsRepository Students { get; }
        IEnrollmentsRepository Enrollments { get; }
    }
}
