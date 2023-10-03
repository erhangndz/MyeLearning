using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles = "Instructor")]
    public class InstructorAnalysisController : Controller
    {
        
        public IActionResult Index()
        {
            
            return View();
        }

        
    }
}
