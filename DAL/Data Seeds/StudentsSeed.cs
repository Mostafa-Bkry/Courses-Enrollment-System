﻿
namespace DAL.Data_Seeds
{
    internal static class StudentsSeed
    {
        public static List<Student> InitialStudents { get; set; } = new List<Student>()
        {
            new Student() 
            {
                Id = 1, FullName = "Mostafa Alaa", Email = "example1@domain.com", 
                BirthDate = new DateOnly(1999, 10, 3), NID = "12345678910111", 
                PhoneNumber = "01111111111"
            },
            new Student() 
            {
                Id = 2, FullName = "Ahmed Ali", Email = "example2@domain.com", 
                BirthDate = new DateOnly(2000, 1, 1), NID = "12349101115678", 
                PhoneNumber = "02222222222"
            },
            new Student() 
            {
                Id = 3, FullName = "Hassan Mohamed", Email = "example3@domain.com", 
                BirthDate = new DateOnly(1950, 5, 3), NID = "56781234910111", 
                PhoneNumber = "03333333333"
            },
            new Student() 

            {
                Id = 4, FullName = "Khaled Ali", Email = "example4@domain.com", 
                BirthDate = new DateOnly(1999, 2, 2), NID = "12678913450111", 
                PhoneNumber = "04444444444"
            },
            new Student() 

            {
                Id = 5, FullName = "Mahmoud Abbas", Email = "example5@domain.com", 
                BirthDate = new DateOnly(2005, 3, 2), NID = "12340115678911", 
                PhoneNumber = "05555555555"
            },
            new Student() 

            {
                Id = 6, FullName = "Ibrahim Mohamed", Email = "example6@domain.com",
                BirthDate = new DateOnly(2001, 12, 11), NID = "17891012345611", 
                PhoneNumber = "06666666666"
            },
            new Student() 

            {
                Id = 7, FullName = "Anas Mostafa", Email = "example7@domain.com", 
                BirthDate = new DateOnly(2002, 1, 11), NID = "12891013456711", 
                PhoneNumber = "07777777777"
            },
            new Student() 

            {
                Id = 8, FullName = "Hosny Hassan", Email = "example8@domain.com", 
                BirthDate = new DateOnly(1994, 2, 11), NID = "11011123456789", 
                PhoneNumber = "08888888888"
            },
        };
    }
}
