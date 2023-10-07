using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGenericService<Student> _studentService;
        private readonly UserManager<AppUser> _userManager;
        public StudentController(IGenericService<Student> studentService, UserManager<AppUser> userManager)
        {
            _studentService = studentService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.GetUsersInRoleAsync("Student");
            return View(values);
        }

        
    }
}
