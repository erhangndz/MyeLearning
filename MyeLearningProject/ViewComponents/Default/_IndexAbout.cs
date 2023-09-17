using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexAbout:ViewComponent
    {
        private readonly IGenericService<AboutUs> _aboutUsService;

        public _IndexAbout(IGenericService<AboutUs> aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutUsService.GetList();
            return View(values);
        }
    }
}
