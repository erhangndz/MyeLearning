using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class WatchList
    {
        public int WatchListID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int LessonNumber { get; set; }
        public string VideoUrl { get; set; }
    }
}
