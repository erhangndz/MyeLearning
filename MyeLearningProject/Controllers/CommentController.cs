using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.VisualStudio;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles ="Student")]
    public class CommentController : Controller
    {
        private readonly IGenericService<Comment> _commentService;
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(IGenericService<Comment> commentService, ICourseService courseService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _courseService = courseService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.id=id;
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
        public async Task<IActionResult> Index(Comment comment,int id)
        {
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.Status = true;
            comment.CourseId = id;
            comment.AppUserId = user.Id;
            _commentService.Insert(comment);
            return RedirectToAction("Index", "StudentCourse");


        }

    }
}
