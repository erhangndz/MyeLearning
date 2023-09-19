namespace Entity.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string? CoverImage { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public List<Course> Courses { get; set; }
        public bool Status { get; set; }
    }
}
