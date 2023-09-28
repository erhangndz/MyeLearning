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
            var reviewList= _reviewService.GetList();
            var values = _courseService.GetAll();
            return View(values);
        }
    }
}
