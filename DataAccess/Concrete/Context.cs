using Microsoft.EntityFrameworkCore;
using Entity.Models;

namespace DataAccess.Concrete
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
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
