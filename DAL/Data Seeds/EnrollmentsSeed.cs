
namespace DAL.Data_Seeds
{
    internal static class EnrollmentsSeed
    {
        public static List<Enrollment> InitialEnrollments { get; set; } = new List<Enrollment>()
        {
            //Course Id = 1
            new Enrollment {CourseId = 1, StudentId = 1},
            new Enrollment {CourseId = 1, StudentId = 2},
            new Enrollment {CourseId = 1, StudentId = 3},
            new Enrollment {CourseId = 1, StudentId = 4},
            new Enrollment {CourseId = 1, StudentId = 5},
            new Enrollment {CourseId = 1, StudentId = 6},
            //Course Id = 2
            new Enrollment {CourseId = 2, StudentId = 1},
            new Enrollment {CourseId = 2, StudentId = 2},
            new Enrollment {CourseId = 2, StudentId = 3},
            new Enrollment {CourseId = 2, StudentId = 4},
            new Enrollment {CourseId = 2, StudentId = 8},
            new Enrollment {CourseId = 2, StudentId = 7},
            //Coure Id = 3
            new Enrollment {CourseId = 3, StudentId = 5},
            new Enrollment {CourseId = 3, StudentId = 3},
            new Enrollment {CourseId = 3, StudentId = 8},
            //Coure Id = 4
            new Enrollment {CourseId = 4, StudentId = 1},
            //Coure Id = 5
            new Enrollment {CourseId = 5, StudentId = 3},
            //Coure Id = 6
            new Enrollment {CourseId = 6, StudentId = 7},
        };
    }
}
