using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IGenericService<Message> _messageService;
        public ContactController(IGenericService<Message> messageService)
        {
            _messageService = messageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            _messageService.Insert(message);
            return NoContent();
        }
    }
}
