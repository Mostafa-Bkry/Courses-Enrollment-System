
namespace DAL.Data_Seeds
{
    internal static class CoursesSeed
    {
        public static List<Course> InitialCourses { get; set; } = new List<Course>
        {
            new Course {Id = 1, Title = "C#", Description = "C#", MaxCapacity = 100},
            new Course {Id = 2, Title = "Python", Description = "Python", MaxCapacity = 20},
            new Course {Id = 3, Title = "C++", Description = "C++", MaxCapacity = 5},
            new Course {Id = 4, Title = "C", Description = "C", MaxCapacity = 2},
            new Course {Id = 5, Title = "Ruby", Description = "Ruby", MaxCapacity = 1},
            new Course {Id = 6, Title = "Go", Description = "Go", MaxCapacity = 10},
        };
    }
}
