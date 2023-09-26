using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyeLearningProject.Models;

namespace MyeLearningProject.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
		{
            return View();
		}

		[HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
			AppUser user = new AppUser()
			{
				Email = model.Email,
				

			};
			if (ModelState.IsValid)
			{
				await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
				return RedirectToAction("Index","Instructor");
			}
            return View();
        }

        [HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(RegisterViewModel model)
		{
			AppUser user = new AppUser()
			{
				Email = model.Email,
				UserName=model.Username

			};
			if(ModelState.IsValid)
			{
				await _userManager.CreateAsync(user,model.Password);
				return RedirectToAction("Login");
			}

			return View();
		}

    }
}
