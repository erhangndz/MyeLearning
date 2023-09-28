using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
    {
        private readonly IGenericService<Subscribe> _subscribeService;

        public DefaultController(IGenericService<Subscribe> subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Subscribe()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Subscribe(Subscribe subscribe)
        {
            _subscribeService.Insert(subscribe);
            return NoContent();
        }
    }
}
