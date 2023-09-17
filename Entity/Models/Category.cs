namespace Entity.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Image { get; set; }
        public List<Course> Courses { get; set; }
        public bool Status { get; set; }
    }
}
