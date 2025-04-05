using System.Runtime.Intrinsics.X86;

using Microsoft.EntityFrameworkCore;

using StudentResultWebApi.Models;

namespace StudentResultWebApi.Data
{
    public class AppDbContext(DbContextOptions op) : DbContext(op)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSemester> StudentSemesters { get; set; }
        public DbSet<Marks> Marks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marks>().HasKey(m => new {m.StudentId,m.SubjectId });

            modelBuilder.Entity<Student>()
                .HasMany(s => s.semesters)
                .WithMany(s => s.Students)
                .UsingEntity<StudentSemester>();
        }

    }
}
