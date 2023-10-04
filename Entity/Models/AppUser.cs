using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string? NameSurname { get; set; }
        public string? Image { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Course> Courses { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
