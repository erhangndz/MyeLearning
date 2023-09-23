using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorAnalysis
{
    public class _InstructorContact:ViewComponent
    {
        private readonly IGenericService<Instructor> _instructorService;

        public _InstructorContact(IGenericService<Instructor> instructorService)
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
