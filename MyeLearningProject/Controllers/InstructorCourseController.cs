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

        public InstructorCourseController(UserManager<AppUser> userManager, ICourseService courseService, IGenericService<Category> categoryService)
        {
            _userManager = userManager;
            _courseService = courseService;
            _categoryService = categoryService;
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
    }
}
