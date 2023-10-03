using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexTeam:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _IndexTeam(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var instructors = await _userManager.GetUsersInRoleAsync("Instructor");
            return View(instructors);
        }
    }
}
