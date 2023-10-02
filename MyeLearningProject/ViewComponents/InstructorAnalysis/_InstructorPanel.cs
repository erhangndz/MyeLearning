using Business.Concrete;
using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorPanel:ViewComponent
    {
        private readonly IGenericService<Instructor> _instructorService;
        private readonly ICourseService _courseService;
        private readonly ICommentService _commentService;

        public _InstructorPanel(IGenericService<Instructor> instructorService, ICourseService courseService, ICommentService commentService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.courseCount = _courseService.GetList().Count(x=>x.InstructorId==id);
            var courseId = _courseService.GetList().Where(x => x.InstructorId == id).Select(x => x.CourseId).ToList();

            ViewBag.commentCount = _commentService.GetAll().Where(x => courseId.Contains(x.CourseId)).Count();
            
            var values = _instructorService.GetById(id);
            return View(values);
        }
    }
}
