using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorCourses:ViewComponent
    {
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;

        public _InstructorCourses(ICourseService courseService, UserManager<AppUser> userManager)
        {
            _courseService = courseService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.courseCount = _courseService.GetAll().Count(x=>x.AppUserId==user.Id);
            var values = _courseService.GetAll().Where(x => x.AppUserId == user.Id).ToList();
            return View(values);
        }
    }
}
