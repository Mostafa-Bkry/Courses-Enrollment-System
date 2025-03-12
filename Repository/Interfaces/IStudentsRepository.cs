
namespace Repository.Interfaces
{
    public interface IStudentsRepository
    {
        List<Student> GetAll();
        Student GetById(int id);

        bool Add(Student student);
        bool Edit(Student student);
        bool Delete(int id);
    }
}
