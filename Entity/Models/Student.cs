using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public string Password { get; set; }
        public List<CourseRegister> CourseRegisters { get; set; }
        public List<Comment> Comments { get; set; }
       
    }
}
