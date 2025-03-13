﻿
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Enrollment> GetAll()
        {
            return _context?.Enrollments?.AsNoTracking().ToList() ?? new List<Enrollment>();
        }

        public Enrollment GetById(int crsId, int stdId)
        {
            return _context?.Enrollments?.Find(crsId, stdId) ?? new Enrollment();
        }

        public List<Course> GetCoursesPerStudent(int stdId)
        {
            return _context?.Enrollments?
                            //.Include(e => e.Course)
                            .Where(e => e.StudentId == stdId)
                            .Select(e => e.Course)
                            .ToList() ?? new List<Course>();
        }

        public List<Student> GetStudentsPerCourse(int crsId)
        {
            return _context?.Enrollments?
                            //.Include(e => e.Student)
                            .Where(e => e.CourseId == crsId)
                            .Select(e => e.Student)
                            .ToList() ?? new List<Student>();
        }

        public bool Add(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int crsId, int stdId)
        {
            throw new NotImplementedException();
        }
    }
}
