using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IGenericService<Instructor> _instructorService;
        public InstructorController(IGenericService<Instructor> instructorService)
        {
            _instructorService = instructorService;
        }
        public IActionResult Index()
        {
            var values = _instructorService.GetList();
            return View(values);
        }
    }
}
