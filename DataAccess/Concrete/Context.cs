using Microsoft.EntityFrameworkCore;
using Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Concrete
{
    public class Context: IdentityDbContext<AppUser,AppRole,int>
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
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
