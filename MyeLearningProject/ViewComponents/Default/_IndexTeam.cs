using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexTeam:ViewComponent
    {
        private readonly IGenericService<Instructor> _instructorService;
        public _IndexTeam(IGenericService<Instructor> instructorService)
        {
            _instructorService = instructorService;
        }
        public IViewComponentResult Invoke()
        {
           var values= _instructorService.GetList();
            return View(values);
        }
    }
}
