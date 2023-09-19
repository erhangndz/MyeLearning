using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        private readonly IGenericService<Instructor> _instructorService;

        public InstructorAnalysisController(IGenericService<Instructor> instructorService)
        {
            _instructorService = instructorService;
        }

        public IActionResult Index(int id)
        {
            ViewBag.id = id;
            return View();
        }

        
    }
}
