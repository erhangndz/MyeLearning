using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int Score { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        
        
    }
}
