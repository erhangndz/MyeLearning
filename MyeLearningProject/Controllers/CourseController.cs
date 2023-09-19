using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
