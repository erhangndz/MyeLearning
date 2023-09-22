using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IGenericService<Testimonial> _testimonialService;

        public TestimonialController(IGenericService<Testimonial> testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var values = _testimonialService.GetList();
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.GetById(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }

            _testimonialService.Update(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var values = _testimonialService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            testimonial.Status= true;
            _testimonialService.Update(testimonial);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            testimonial.Status = true;
            _testimonialService.Insert(testimonial);
            return RedirectToAction("Index");
        }
    }
}
