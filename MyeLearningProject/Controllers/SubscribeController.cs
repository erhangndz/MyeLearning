using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IGenericService<Subscribe> _subscribeService;

        public SubscribeController(IGenericService<Subscribe> subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public IActionResult Index()
        {
            var values = _subscribeService.GetList();
            return View(values);
        }

        public IActionResult DeleteSubscribe(int id)
        {
            _subscribeService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSubscribe(int id)
        {
            var values = _subscribeService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSubscribe(Subscribe subscribe)
        {
            _subscribeService.Update(subscribe);
            return RedirectToAction("Index");
        }

        
    }
}
