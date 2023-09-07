using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Admin
{
    public class _AdminSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
