using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace MyeLearningProject.Controllers
{
	[AllowAnonymous]
	public class CourseController : Controller
    {
       private readonly ICourseService _courseService;
        private readonly IGenericService<Review> _reviewService;

        public CourseController(ICourseService courseService, IGenericService<Review> reviewService)
        {
            _courseService = courseService;
            _reviewService = reviewService;
        }

        public IActionResult Index(int page=1)
        {
            ViewBag.course2AvgScore = _reviewService.GetList().Where(x => x.CourseId == 2).Average(x => x.Score).ToString("0.#");
            ViewBag.course3AvgScore = _reviewService.GetList().Where(x => x.CourseId == 3).Average(x => x.Score).ToString("0.#");
            ViewBag.course4AvgScore = _reviewService.GetList().Where(x => x.CourseId == 4).Average(x => x.Score).ToString("0.#");
            ViewBag.course8AvgScore = _reviewService.GetList().Where(x => x.CourseId == 8).Average(x => x.Score).ToString("0.#");
            var values = _courseService.GetAll().ToPagedList(page, 3);
            return View(values);
        }
    }
}
