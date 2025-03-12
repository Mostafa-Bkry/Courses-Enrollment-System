using Microsoft.EntityFrameworkCore;

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

        public bool Add(Course course)
        {
            _context?.Courses?.Add(course);
            return (_context?.Entry(course)?.State == EntityState.Added) ? true : false;
        }

        public bool Edit(Course course)
        {
            Course? existingCrs = _context?.Courses?.Find(course.Id);

            if(existingCrs is not null)
            {
                existingCrs.Title = course.Title;
                existingCrs.Description = course.Description;
                existingCrs.MaxCapacity = course.MaxCapacity;

                return (_context?.Entry(existingCrs)?.State == EntityState.Modified) ? true : false;
            }

            return false;
        }

        public bool Delete(int id)
        {
            Course? existCrs = _context?.Courses?.Find(id);

            if (existCrs is not null)
            {
                _context?.Remove(existCrs);
                return (_context?.Entry(existCrs)?.State == EntityState.Deleted) ? true : false;
            }

            return false;
        }
    }
}
