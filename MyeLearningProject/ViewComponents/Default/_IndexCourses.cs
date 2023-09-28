using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

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
            ViewBag.course2AvgScore= _reviewService.GetList().Where(x=>x.CourseId==2).Average(x=>x.Score).ToString();
            ViewBag.course3AvgScore= _reviewService.GetList().Where(x=>x.CourseId==3).Average(x=>x.Score).ToString();
            ViewBag.course4AvgScore= _reviewService.GetList().Where(x=>x.CourseId==4).Average(x=>x.Score).ToString();
            ViewBag.course8AvgScore= _reviewService.GetList().Where(x=>x.CourseId==8).Average(x=>x.Score).ToString();
            var values = _courseService.GetAll();
            return View(values);
        }
    }
}
