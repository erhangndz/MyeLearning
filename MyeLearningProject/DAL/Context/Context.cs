using Microsoft.EntityFrameworkCore;
using MyeLearningProject.DAL.Entities;

namespace MyeLearningProject.DAL.Context
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ERHAN\\SQLEXPRESS;database=DbeLearning;integrated security=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
