using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.InstructorLayout
{
    public class _InstructorNavbar:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _InstructorNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.NameSurname;
            ViewBag.image = user.Image;

            return View();
        }
    }
}
