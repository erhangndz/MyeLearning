using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Admin
{
    public class _AdminNavbar:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

		public _AdminNavbar(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async  Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name=user.NameSurname;
            ViewBag.image=user.Image;

            return View();
        }
    }
}
