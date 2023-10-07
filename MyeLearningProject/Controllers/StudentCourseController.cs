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
        private readonly IGenericService<WatchList> _watchListService;

        public StudentCourseController(ICourseService courseService, UserManager<AppUser> userManager, IGenericService<WatchList> watchListService)
        {
            _courseService = courseService;
            _userManager = userManager;
            _watchListService = watchListService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _courseService.GetAll();
            return View(values);
        }

        public IActionResult WatchCourse(int id,string name)
        {
            var values = _watchListService.GetList().Where(x=>x.CourseID==id).ToList();

            ViewBag.courseName = name;
            return View(values);
        }
    }
}


   