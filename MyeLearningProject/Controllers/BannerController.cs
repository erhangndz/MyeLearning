using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BannerController : Controller
    {
        private readonly IGenericService<Banner> _bannerService;

        public BannerController(IGenericService<Banner> bannerService)
        {
            _bannerService = bannerService;
        }

        public IActionResult Index()
        {
            var values = _bannerService.GetList();
            return View(values);
        }

        public IActionResult DeleteBanner(int id)
        {
            _bannerService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBanner(Banner banner)
        {
           
            _bannerService.Insert(banner);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditBanner(int id)
        {
            var value = _bannerService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditBanner(Banner banner)
        {
           
            _bannerService.Update(banner);
            return RedirectToAction("Index");
        }
    }
}
