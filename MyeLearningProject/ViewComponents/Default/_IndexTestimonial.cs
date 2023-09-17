using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexTestimonial:ViewComponent
    {
        private readonly IGenericService<Testimonial> _testimonialService;

        public _IndexTestimonial(IGenericService<Testimonial> testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.GetList();
            return View(values);
        }
    }
}
