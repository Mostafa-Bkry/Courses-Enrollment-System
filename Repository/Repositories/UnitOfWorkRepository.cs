
namespace Repository.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationDbContext _context;

        public ICoursesRepository Courses { get; private set; }
        public IStudentsRepository Students { get; private set; }
        public IEnrollmentsRepository Enrollments { get; private set; }

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            _context = context;

            Courses = new CoursesRepository(_context);
            Students = new StudentsRepository();
            Enrollments = new EnrollmentsRepository();
        }

        public int Complete()
        {
            return _context?.SaveChanges() ?? 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
