using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quota { get; set; }
        public string CourseTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public bool Status { get; set; }
        public List<CourseRegister> CourseRegisters { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Review> Reviews { get; set; }
        
    }
}
