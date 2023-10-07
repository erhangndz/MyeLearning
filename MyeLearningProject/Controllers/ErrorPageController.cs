using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
