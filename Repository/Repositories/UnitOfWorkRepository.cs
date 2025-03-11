using DAL.Context;
using Repository.Interfaces;

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
        }
    }
}
