﻿
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Repository.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context?.Students?.ToList() ?? new List<Student>();
        }

        public Student GetById(int id)
        {
            return _context?.Students?.Find(id) ?? new Student();
        }

        public bool Add(Student student, out bool uniqueEmail)
        {
            Student? std = _context.Students.SingleOrDefault(s => s.Email == student.Email);
            if (std is null)
            {
                uniqueEmail = true;
                _context?.Students?.Add(student);
                return (_context?.Entry(student)?.State == EntityState.Added) ? true : false;
            }
            else
            {
                uniqueEmail = false;
            }

            return false;
        }

        public bool Edit(Student student, out bool uniqueEmail)
        {
            Student? existingStud = _context?.Students?.Find(student.Id);

            if (existingStud is not null)
            {
                if (existingStud.Email == student.Email)
                {
                    uniqueEmail = true;
                }
                else
                {
                    Student? std = _context?.Students.SingleOrDefault(s => s.Email == student.Email);
                    if (std is null || existingStud.Email == std.Email)
                        uniqueEmail = true;
                    else
                        uniqueEmail = false;
                }

                if (uniqueEmail)
                {
                    existingStud.FullName = student.FullName;
                    existingStud.Email = student.Email;
                    existingStud.BirthDate = student.BirthDate;
                    existingStud.NID = student.NID;
                    existingStud.PhoneNumber = student.PhoneNumber;

                    return true;
                }
            }

            uniqueEmail = false;
            return false;
        }

        public bool Delete(int id)
        {
            Student? existStud = _context?.Students?.Find(id);

            if (existStud is not null)
            {
                _context?.Remove(existStud);
                return (_context?.Entry(existStud)?.State == EntityState.Deleted) ? true : false;
            }

            return false;
        }
    }
}
