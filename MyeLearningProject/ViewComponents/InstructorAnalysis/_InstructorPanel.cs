using Business.Concrete;
using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorPanel:ViewComponent
    {
        private readonly IGenericService<Instructor> _instructorService;
        private readonly ICourseService _courseService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public _InstructorPanel(IGenericService<Instructor> instructorService, ICourseService courseService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.courseCount = _courseService.GetAll().Count(x=>x.AppUserId ==user.Id);
            var courseId = _courseService.GetAll().Where(x => x.AppUserId == user.Id).Select(x => x.CourseId).ToList();

            ViewBag.commentCount = _commentService.GetAll().Where(x => courseId.Contains(x.CourseId)).Count();
            var studentList = _userManager.GetUsersInRoleAsync("Student").Result;
            ViewBag.studentCount= studentList.Count();
            ViewBag.image = user.Image;
            ViewBag.name = user.NameSurname;

            return View();
        }
    }
}
