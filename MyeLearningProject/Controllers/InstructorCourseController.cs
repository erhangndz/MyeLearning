using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles ="Instructor")]
    public class InstructorCourseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly IGenericService<Category> _categoryService;
        private readonly IGenericService<WatchList> _watchListService;

        public InstructorCourseController(UserManager<AppUser> userManager, ICourseService courseService, IGenericService<Category> categoryService, IGenericService<WatchList> watchListService)
        {
            _userManager = userManager;
            _courseService = courseService;
            _categoryService = categoryService;
            _watchListService = watchListService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _courseService.GetAll().Where(x=>x.AppUserId==user.Id).ToList();
            return View(values);
        }

        public IActionResult DeleteCourse(int id)
        {
            _courseService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var cat = _categoryService.GetList();
            
            List<SelectListItem> category = (from x in cat
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();

            ViewBag.category = category;
            
            var values = _courseService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            course.AppUserId = user.Id;
            _courseService.Update(course);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCourse()
        {
            var cat = _categoryService.GetList();
           
            List<SelectListItem> category = (from x in cat
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();

            ViewBag.category = category;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            course.AppUserId = user.Id;
            course.Status = true;
            _courseService.Insert(course);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddVideo(int id,string name)
        {
            ViewBag.id = id;
            ViewBag.courseName=name;
            var values = _watchListService.GetList().Where(x=>x.CourseID == id).ToList();
            return View(values);
        }
        [HttpPost]
        public IActionResult AddVideo(WatchList watchList)
        {
            _watchListService.Insert(watchList);
            return RedirectToAction("Index");
        }
    }
}
