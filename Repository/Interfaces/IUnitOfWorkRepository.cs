
namespace Repository.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        ICoursesRepository Courses { get; }
        IStudentsRepository Students { get; }
        IEnrollmentsRepository Enrollments { get; }

        int Complete();
    }
}
