using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexCourses:ViewComponent
    {
        private readonly ICourseService _courseService;

        public _IndexCourses(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _courseService.GetAll();
            return View(values);
        }
    }
}
