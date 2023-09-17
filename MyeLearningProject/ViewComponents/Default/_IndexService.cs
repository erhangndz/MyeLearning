using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexService:ViewComponent
    {
        private readonly IGenericService<Service> _serviceService;

        public _IndexService(IGenericService<Service> serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _serviceService.GetList();
            return View(values);
        }
    }
}
