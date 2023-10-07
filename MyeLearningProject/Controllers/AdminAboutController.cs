using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminAboutController : Controller
    {
        IGenericService<AboutUs> _aboutUsService;

        public AdminAboutController(IGenericService<AboutUs> aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        public IActionResult Index()
        {
            var values = _aboutUsService.GetList();
            return View(values);
        }

        public IActionResult DeleteAbout(int id)
        {
            _aboutUsService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var values = _aboutUsService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAbout(AboutUs about)
        {
            _aboutUsService.Update(about);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAbout()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(AboutUs about)
        {
           
            _aboutUsService.Insert(about);
            return RedirectToAction("Index");
        }
    }
}
