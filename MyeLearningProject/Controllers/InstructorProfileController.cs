using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyeLearningProject.Models;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles = "Instructor")]
    public class InstructorProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public InstructorProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();

            model.NameSurname = user.NameSurname;
            model.PhoneNumber = user.PhoneNumber;
            model.Email = user.Email;
            model.ImageURL = user.Image;


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.Image = imagename;
            }

            user.NameSurname = p.NameSurname;
            user.Email = p.Email;
            user.PhoneNumber = p.PhoneNumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("InstructorLogin", "Account");
            }
            return View();
        }
    }
}
