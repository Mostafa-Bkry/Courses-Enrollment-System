
namespace Repository.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ApplicationDbContext _context;

        public CoursesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAll()
        {
            return _context?.Courses?.ToList() ?? new List<Course>();
        }

        public Course GetById(int id)
        {
            return _context?.Courses?.Find(id) ?? new Course();
        }
    }
}
