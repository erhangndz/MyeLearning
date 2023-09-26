using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IGenericService<Review> _reviewService;

        public ReviewController(IGenericService<Review> reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
           
            return View();
        }
    }
}
