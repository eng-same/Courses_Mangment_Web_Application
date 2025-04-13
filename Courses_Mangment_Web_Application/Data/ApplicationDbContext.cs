using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Courses_Mangment_Web_Application.Models;

namespace Courses_Mangment_Web_Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }
        
        public DbSet<Course> Courses { get; set; }
        
        public DbSet<StudentCourse> StudentCourses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring composite key for StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Configuring many-to-one relationships
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring one-to-many relationships
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Configuring one-to-many relationships
            modelBuilder.Entity<Course>()
               .HasOne(c => c.Category)
               .WithMany(i => i.Courses)
               .HasForeignKey(c => c.CategoryId);

            // Seeding data
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Computer sciences", Description = "Computer-Science related courses" },
                    new Category { Id = 2, Name = "Arts", Description = "Arts related courses" }
                );

            modelBuilder.Entity<Instructor>()
                .HasData(
                    new Instructor { Id = 1, Name = "أ.فرج نجم", Email = "Instructor1@example.com" },
                    new Instructor { Id = 2, Name = "أ.خيرالله الفرجاني", Email = "Instructor2@example.com" },
                    new Instructor { Id = 3, Name = "ياسمين فوزي", Email = "Instructor3@example.com" }
                );

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course { Id = 1, Title = "Data Structure and algorithms I", Description = "Introduction Data Structure and algorithms by أ.فرج نجم", Price = 100.00m, InstructorId = 1, CategoryId = 1  ,Hours=(decimal)3.2 },
                    new Course { Id = 2, Title = "Data Structure and algorithms II", Description = "Introduction Data Structure and algorithms by أ.خيرالله الفرجاني", Price = 250.00m, InstructorId = 2, CategoryId = 1  ,Hours=(decimal)3.2 },
                    new Course { Id = 3, Title = "Painting 101", Description = "Introduction to Painting by ياسمين فوزي", Price = 150.00m, InstructorId = 3, CategoryId = 2 , Hours = (decimal)5.3 }

                );

            modelBuilder.Entity<Student>()
                .HasData(
                    new Student { Id = 1, Name = "Sami Awadh", Email = "Student1@example.com" },
                    new Student { Id = 2, Name = "Othman Shnip", Email = "Student2@example.com" }
                );

            modelBuilder.Entity<StudentCourse>()
                .HasData(
                    new StudentCourse { StudentId = 1, CourseId = 1 ,evaluation=4 ,feedback="it was such a nice course " },
                    new StudentCourse { StudentId = 2, CourseId = 3 , evaluation = 1, feedback = "westing money ,bad instructors no good material " },
                    new StudentCourse { StudentId = 2, CourseId = 2 , evaluation = 3, feedback = "good !! " },
                    new StudentCourse { StudentId = 1, CourseId = 2, evaluation = 2, feedback = " no good " }
                );
        }
    }
}
