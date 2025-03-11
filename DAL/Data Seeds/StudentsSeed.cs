
namespace DAL.Data_Seeds
{
    internal static class StudentsSeed
    {
        public static List<Student> InitialStudents { get; set; } = new List<Student>()
        {
            new Student() 
            {
                Id = 1, FullName = "Mostafa Alaa", Email = "example@domain.com", 
                BirthDate = new DateTime(1999, 10, 3), NID = "12345678910111", 
                PhoneNumber = "01111111111"
            },
            new Student() 
            {
                Id = 2, FullName = "Ahmed Ali", Email = "example@domain.com", 
                BirthDate = new DateTime(2000, 1, 1), NID = "12349101115678", 
                PhoneNumber = "02222222222"
            },
            new Student() 
            {
                Id = 3, FullName = "Hassan Mohamed", Email = "example@domain.com", 
                BirthDate = new DateTime(1933, 10, 11), NID = "56781234910111", 
                PhoneNumber = "03333333333"
            },
            new Student() 

            {
                Id = 4, FullName = "Khaled Ali", Email = "example@domain.com", 
                BirthDate = new DateTime(1933, 10, 11), NID = "12678913450111", 
                PhoneNumber = "04444444444"
            },
            new Student() 

            {
                Id = 5, FullName = "Mahmoud Abbas", Email = "example@domain.com", 
                BirthDate = new DateTime(1933, 10, 11), NID = "12340115678911", 
                PhoneNumber = "05555555555"
            },
            new Student() 

            {
                Id = 6, FullName = "Ibrahim Mohamed", Email = "example@domain.com",
                BirthDate = new DateTime(1933, 10, 11), NID = "17891012345611", 
                PhoneNumber = "06666666666"
            },
            new Student() 

            {
                Id = 7, FullName = "Anas Mostafa", Email = "example@domain.com", 
                BirthDate = new DateTime(1933, 10, 11), NID = "12891013456711", 
                PhoneNumber = "07777777777"
            },
            new Student() 

            {
                Id = 8, FullName = "Hosny Hassan", Email = "example@domain.com", 
                BirthDate = new DateTime(1933, 10, 11), NID = "11011123456789", 
                PhoneNumber = "08888888888"
            },
        };
    }
}
