using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorComments:ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly ICourseService _courseService;
       

        public _InstructorComments(ICommentService commentService, ICourseService courseService)
        {
            _commentService = commentService;
            _courseService = courseService;
         
        }

        public IViewComponentResult Invoke(int id)
        {
            

            var courseId = _courseService.GetList().Where(x => x.InstructorId == id).Select(x => x.CourseId).ToList();

            var commentList = _commentService.GetAll().Where(x => courseId.Contains(x.CourseId)).ToList();
            return View(commentList);
        }
    }
}
