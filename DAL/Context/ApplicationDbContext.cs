using DAL.Data_Seeds;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Data Seeding
            modelBuilder.Entity<Student>()
                        .HasData(StudentsSeed.InitialStudents);

            modelBuilder.Entity<Course>()
                        .HasData(CoursesSeed.InitialCourses);

            modelBuilder.Entity<Enrollment>()
                        .HasData(EnrollmentsSeed.InitialEnrollments);
            #endregion

            #region Models Relationships
            modelBuilder.Entity<Enrollment>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Enrollment>()
                        .HasOne(sc => sc.Student)
                        .WithMany(s => s.Enrollments)
                        .HasForeignKey(sc => sc.StudentId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrollment>()
                        .HasOne(sc => sc.Course)
                        .WithMany(s => s.Enrollments)
                        .HasForeignKey(sc => sc.CourseId)
                        .OnDelete(DeleteBehavior.NoAction); 
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
