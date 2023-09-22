using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGenericService<Student> _studentService;
        public StudentController(IGenericService<Student> studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var values = _studentService.GetList();
            return View(values);
        }

        public IActionResult DeleteStudent(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _studentService.Insert(student);
            return RedirectToAction("Index");
        }
    }
}
