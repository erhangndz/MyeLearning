using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexSlider:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
