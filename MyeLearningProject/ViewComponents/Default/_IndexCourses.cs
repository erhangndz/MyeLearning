using Business.Interfaces;
using DataAccess.Concrete;
using Entity.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyeLearningProject.Models;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexCourses:ViewComponent
    {
        private readonly ICourseService _courseService;
        private readonly IGenericService<Review> _reviewService;

		public _IndexCourses(ICourseService courseService, IGenericService<Review> reviewService)
		{
			_courseService = courseService;
			_reviewService = reviewService;
		}

		public IViewComponentResult Invoke()
        {
            

            var context = new Context();

            var result = context.Courses.Include(x => x.Category).Include(x => x.AppUser).Select(x => new CourseDto
            {
                CategoryName = x.Category.CategoryName,
                CourseName = x.CourseName,
                CourseTime = x.CourseTime,
                Description = x.Description,
                Image = x.Image,
                NameSurname = x.AppUser.NameSurname,  /*context.Users.Where(y=>y.Id==x.AppUserId).Select(x=>x.NameSurname).FirstOrDefault()*/
                Price = x.Price,
                Quota = x.Quota,
                AvgReviewScore = context.Reviews.Where(y => y.CourseId == x.CourseId).Average(x => x.Score),

            }).AsEnumerable();

            var values = result.TakeLast(6).ToList();
            return View(values);
        }
    }
}
