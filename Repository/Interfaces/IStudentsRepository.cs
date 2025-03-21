﻿
namespace Repository.Interfaces
{
    public interface IStudentsRepository
    {
        List<Student> GetAll();
        Student GetById(int id);

        bool Add(Student student, out bool uniqueEmail);
        bool Edit(Student student, out bool uniqueEmail);
        bool Delete(int id);
    }
}
