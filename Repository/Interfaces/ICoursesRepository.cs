
namespace Repository.Interfaces
{
    public interface ICoursesRepository
    {
        List<Course> GetAll();
        Course GetById(int id);

        bool Add(Course course);
        bool Edit(Course course);
    }
}
