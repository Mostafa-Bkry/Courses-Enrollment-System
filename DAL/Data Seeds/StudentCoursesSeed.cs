
namespace DAL.Data_Seeds
{
    internal static class StudentCoursesSeed
    {
        public static List<StudentCourse> InitialStCourses { get; set; } = new List<StudentCourse>()
        {
            //Course Id = 1
            new StudentCourse {CourseId = 1, StudentId = 1},
            new StudentCourse {CourseId = 1, StudentId = 2},
            new StudentCourse {CourseId = 1, StudentId = 3},
            new StudentCourse {CourseId = 1, StudentId = 4},
            new StudentCourse {CourseId = 1, StudentId = 5},
            new StudentCourse {CourseId = 1, StudentId = 6},
            //Course Id = 2
            new StudentCourse {CourseId = 2, StudentId = 1},
            new StudentCourse {CourseId = 2, StudentId = 2},
            new StudentCourse {CourseId = 2, StudentId = 3},
            new StudentCourse {CourseId = 2, StudentId = 4},
            new StudentCourse {CourseId = 2, StudentId = 8},
            new StudentCourse {CourseId = 2, StudentId = 7},
            //Coure Id = 3
            new StudentCourse {CourseId = 3, StudentId = 1},
            new StudentCourse {CourseId = 3, StudentId = 1},
            new StudentCourse {CourseId = 3, StudentId = 1},
            //Coure Id = 4
            new StudentCourse {CourseId = 4, StudentId = 1},
            //Coure Id = 5
            new StudentCourse {CourseId = 5, StudentId = 3},
            //Coure Id = 6
            new StudentCourse {CourseId = 6, StudentId = 7},
        };
    }
}
