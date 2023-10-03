using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyeLearningProject.Models;

namespace MyeLearningProject.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			AppUser user = new AppUser()
			{
				UserName = model.Username,

			};

			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}
			else
			{
				ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
				return View();
			}




		}

		[HttpGet]
		public IActionResult InstructorLogin()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> InstructorLogin(LoginViewModel model)
        {
            AppUser user = new AppUser()
            {
                UserName = model.Username,

            };

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "InstructorAnalysis");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                return View();
            }

        }

		[HttpGet]
		public IActionResult StudentLogin()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> StudentLogin(LoginViewModel model)
		{
			AppUser user = new AppUser()
			{
				UserName = model.Username,

			};

			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}
			else
			{
				ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
				return View();
			}

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
				UserName = model.Username

			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, "Student");
				return RedirectToAction("Login");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
					return View();
				}
			}

			return View(model);



		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}

	}
}
