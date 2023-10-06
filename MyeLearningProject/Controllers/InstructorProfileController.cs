using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class InstructorProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public InstructorProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
