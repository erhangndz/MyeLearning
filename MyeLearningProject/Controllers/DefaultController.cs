using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
