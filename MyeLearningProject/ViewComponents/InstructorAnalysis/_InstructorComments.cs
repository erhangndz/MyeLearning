using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorComments:ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;


        public _InstructorComments(ICommentService commentService, ICourseService courseService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _courseService = courseService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var courseId = _courseService.GetList().Where(x => x.AppUserId == user.Id).Select(x => x.CourseId).ToList();

            var commentList = _commentService.GetAll().Where(x => courseId.Contains(x.CourseId)).ToList();
            return View(commentList);
        }
    }
}
