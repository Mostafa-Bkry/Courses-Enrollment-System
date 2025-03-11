using DAL.Data_Seeds;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Models Relationships
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                        .HasOne(sc => sc.Student)
                        .WithMany(s => s.StudentCourses)
                        .HasForeignKey(sc => sc.StudentId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentCourse>()
                        .HasOne(sc => sc.Course)
                        .WithMany(s => s.StudentCourses)
                        .HasForeignKey(sc => sc.CourseId)
                        .OnDelete(DeleteBehavior.NoAction); 
            #endregion

            #region Data Seeding
            modelBuilder.Entity<Student>()
                        .HasData(StudentsSeed.InitialStudents);

            modelBuilder.Entity<Course>()
                        .HasData(CoursesSeed.InitialCourses);

            modelBuilder.Entity<StudentCourse>()
                        .HasData(StudentCoursesSeed.InitialStCourses);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
