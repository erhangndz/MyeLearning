using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Admin
{
    public class _AdminHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
