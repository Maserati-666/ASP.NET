using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using SpisokStudents.Models;
using System.Diagnostics;

namespace SpisokStudents.Data
{
    public class RatingStudentContext : DbContext
    {
        public RatingStudentContext(DbContextOptions<RatingStudentContext> options)
    : base(options)
        {}
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasAlternateKey(u => new { u.StudentId, u.CourseName });
        }
    }
}
