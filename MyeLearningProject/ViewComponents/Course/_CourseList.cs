using Business.Concrete;
using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MyeLearningProject.ViewComponents.Course
{
    public class _CourseList:ViewComponent
    {
        private readonly ICourseService _courseService;
        private readonly IGenericService<Review> _reviewService;
        public _CourseList(ICourseService courseService, IGenericService<Review> reviewService)
        {
            _courseService = courseService;
            _reviewService = reviewService;
        }

        public IViewComponentResult Invoke(int page=1)
        {
            ViewBag.course2AvgScore = _reviewService.GetList().Where(x => x.CourseId == 2).Average(x => x.Score).ToString("0.#");
            ViewBag.course3AvgScore = _reviewService.GetList().Where(x => x.CourseId == 3).Average(x => x.Score).ToString("0.#");
            ViewBag.course4AvgScore = _reviewService.GetList().Where(x => x.CourseId == 4).Average(x => x.Score).ToString("0.#");
            ViewBag.course8AvgScore = _reviewService.GetList().Where(x => x.CourseId == 8).Average(x => x.Score).ToString("0.#");
            var values=  _courseService.GetAll().ToPagedList(page,3);
            return View(values);
        }
    }
}
