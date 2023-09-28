using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
	[AllowAnonymous]
	public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
