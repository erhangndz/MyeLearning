using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Admin
{
    public class _AdminScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
