using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Admin
{
    public class _AdminNavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
