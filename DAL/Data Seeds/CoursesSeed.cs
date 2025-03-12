
namespace DAL.Data_Seeds
{
    internal static class CoursesSeed
    {
        public static List<Course> InitialCourses { get; set; } = new List<Course>
        {
            new Course {Id = 1, Title = "C#", Description = "Learn C# Programming Language", MaxCapacity = 100},
            new Course {Id = 2, Title = "Python", Description = "Learn Python Programming Language", MaxCapacity = 20},
            new Course {Id = 3, Title = "C++", Description = "Learn C++ Programming Language", MaxCapacity = 5},
            new Course {Id = 4, Title = "C", Description = "Learn C Programming Language", MaxCapacity = 2},
            new Course {Id = 5, Title = "Ruby", Description = "Learn Ruby Programming Language", MaxCapacity = 1},
            new Course {Id = 6, Title = "Go", Description = "Learn Go Programming Language", MaxCapacity = 10},
        };
    }
}
