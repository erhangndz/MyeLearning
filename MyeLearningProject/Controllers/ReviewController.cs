using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyeLearningProject.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IGenericService<Student> _studentService;
        private readonly ICourseService _courseService;

        public ReviewController(IReviewService reviewService, IGenericService<Student> studentService, ICourseService courseService)
        {
            _reviewService = reviewService;
            _studentService = studentService;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var student = _studentService.GetList();
            List<SelectListItem> studentList = (from x in student
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.StudentID.ToString()
                                                }).ToList();
            ViewBag.student = studentList;
            var course = _courseService.GetList();
            List<SelectListItem> courseList = (from x in course
                                               select new SelectListItem
                                               {
                                                   Text = x.CourseName,
                                                   Value = x.CourseId.ToString()
                                               }).ToList();
            ViewBag.course = courseList;
          
            return View();
        }
        [HttpPost]
        public IActionResult Index(Review review)
        {
           
            
            _reviewService.Insert(review);
            return RedirectToAction("Index");
        }
    }
}
