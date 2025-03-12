
namespace Repository.Interfaces
{
    public interface ICoursesRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
    }
}
