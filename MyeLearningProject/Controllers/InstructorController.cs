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

        public IActionResult DeleteInstructor(int id)
        {
           var value= _instructorService.GetById(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
           
            _instructorService.Update(value);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor instructor)
        {
            instructor.Status = true;
            _instructorService.Insert(instructor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            var value = _instructorService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditInstructor(Instructor instructor)
        {
            instructor.Status = true;
            _instructorService.Update(instructor);
            return RedirectToAction("Index");
        }
    }
}
