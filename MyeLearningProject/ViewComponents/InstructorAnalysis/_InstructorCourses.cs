using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorCourses:ViewComponent
    {
        private readonly ICourseService _courseService;

        public _InstructorCourses(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.courseCount = _courseService.GetList().Count(x=>x.InstructorId==id);
            var values = _courseService.GetAll().Where(x => x.InstructorId == id).ToList();
            return View(values);
        }
    }
}
