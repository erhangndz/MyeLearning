using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        private readonly IGenericService<Message> _messageService;

        public MessageController(IGenericService<Message> messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values= _messageService.GetList();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            _messageService.Delete(id);
            return RedirectToAction("Index");
        }

        
     
        public IActionResult MessageDetails(int id)
        {
           var values= _messageService.GetById(id);
            return View(values);
        }

        
    }
}
