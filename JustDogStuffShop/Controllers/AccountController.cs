using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JustDogStuffShop.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustDogStuffShop.Controllers
{
	[Authorize]
    public class AccountController : Controller
    {
		private readonly UserManager<IdentityUser> _userMgr;
		private readonly SignInManager<IdentityUser> _signInMgr;

		public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
		{
			_userMgr = userMgr;
			_signInMgr = signInMgr;
		}

		//returnUrl is the Url the user is directed to after a successful login
		[AllowAnonymous]
		public IActionResult LogIn(string returnUrl)
		{
			return View(new LoginViewModel
			{
				ReturnUrl = returnUrl
			});
		}

		//called when user enters login information
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(loginViewModel);
			}

			var user = await _userMgr.FindByNameAsync(loginViewModel.UserName);

			//if user already exists and succeeds, log the user in and redirect them to the home/index page
			if (user != null)
			{
				var result = await _signInMgr.PasswordSignInAsync(user, loginViewModel.Password, false, false);

				if (result.Succeeded)
				{
					if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
					{
						return RedirectToAction("Index", "Home");
					}

					return Redirect(loginViewModel.ReturnUrl);
				}
			}

			//else, display error and return to the login view again
			ModelState.AddModelError("", "Username/Password combination was not found");
			return View(loginViewModel);
		}

		[AllowAnonymous]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public async Task<IActionResult> Register(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser() { UserName = loginViewModel.UserName };
				var result = await _userMgr.CreateAsync(user, loginViewModel.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
			}

			//if model isn't valid or user wasn't created successfully, return to the same view
			return View(loginViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInMgr.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
    }
}
