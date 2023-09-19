using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorPanel:ViewComponent
    {
        private readonly IGenericService<Instructor> _instructorService;

        public _InstructorPanel(IGenericService<Instructor> instructorService)
        {
            _instructorService = instructorService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _instructorService.GetById(id);
            return View(values);
        }
    }
}
