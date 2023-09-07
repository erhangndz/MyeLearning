using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexService:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
