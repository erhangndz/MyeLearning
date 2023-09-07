using Microsoft.AspNetCore.Mvc;
using MyeLearningProject.DAL.Context;

namespace MyeLearningProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
          var values=  context.Categories.ToList();
            return View(values);
        }
    }
}
