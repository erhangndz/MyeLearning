namespace MyeLearningProject.Models
{
	public class CourseDto
	{
		public string CourseName { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public decimal Price { get; set; }
		public int Quota { get; set; }
		public string CourseTime { get; set; }
		public string CategoryName { get; set; }
		public string NameSurname { get; set; }
        public double? AvgReviewScore { get; set; }
    }
}
