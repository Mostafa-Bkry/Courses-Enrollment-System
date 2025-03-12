﻿
namespace DAL.Models
{
    public class Enrollment
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; } 
        public virtual Course Course { get; set; } 
    }
}
