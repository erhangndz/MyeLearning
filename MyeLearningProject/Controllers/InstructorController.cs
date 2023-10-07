using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InstructorController : Controller
    {
        private readonly IGenericService<Instructor> _instructorService;
        private readonly UserManager<AppUser> _userManager;
        public InstructorController(IGenericService<Instructor> instructorService, UserManager<AppUser> userManager)
        {
            _instructorService = instructorService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.GetUsersInRoleAsync("Instructor");
            return View(values);
        }

        

        

       
    }
}
