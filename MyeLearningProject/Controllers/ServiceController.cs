using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IGenericService<Service> _serviceService;

        public ServiceController(IGenericService<Service> serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetList();
            return View(values);
        }

        public IActionResult DeleteService(int id)
        {
            _serviceService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddService()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {

            _serviceService.Insert(service);
            return RedirectToAction("Index");
        }
    }
}
