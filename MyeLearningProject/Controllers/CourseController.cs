using Business.Interfaces;
using DataAccess.Concrete;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyeLearningProject.Models;
using X.PagedList;

namespace MyeLearningProject.Controllers
{
	[AllowAnonymous]
	public class CourseController : Controller
    {
       private readonly ICourseService _courseService;
        private readonly IGenericService<Review> _reviewService;

        public CourseController(ICourseService courseService, IGenericService<Review> reviewService)
        {
            _courseService = courseService;
            _reviewService = reviewService;
        }

        public IActionResult Index(int page=1)
        {
            var context = new Context();

            var result = context.Courses.Include(x => x.Category).Include(x => x.AppUser).Select(x => new CourseDto
            {
                CategoryName = x.Category.CategoryName,
                CourseName = x.CourseName,
                CourseTime = x.CourseTime,
                Description = x.Description,
                Image = x.Image,
                NameSurname = x.AppUser.NameSurname,  /*context.Users.Where(y=>y.Id==x.AppUserId).Select(x=>x.NameSurname).FirstOrDefault()*/
                Price = x.Price,
                Quota = x.Quota,
                AvgReviewScore = context.Reviews.Where(y => y.CourseId == x.CourseId).Average(x => x.Score),

            });

            var values = result.ToPagedList(page, 3);
            return View(values);
        }
    }
}
