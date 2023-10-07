using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentCourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;

        public StudentCourseController(ICourseService courseService, UserManager<AppUser> userManager)
        {
            _courseService = courseService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _courseService.GetAll();
            return View(values);
        }

        public IActionResult WatchCourse(int id)
        {
            return View();
        }
    }
}

//< iframe width = "560" height = "315" src = "https://www.youtube.com/embed/VnfpRjs7j7E?si=81aLjZ9h4T1I95Z1" title = "YouTube video player" frameborder = "0" allow = "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen ></ iframe >
   