using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Models;
using FirstRealProject.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstRealProject.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	public class AccountController : Controller
    {
		private UserManager<AppUser> userManager;
		private SignInManager<AppUser> signInManager;
		public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr)
		{
			userManager = userMgr;
			signInManager = signinMgr;
		}


		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			ViewBag.returnUrl = returnUrl;
			return View(new LoginModel());
		}
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel details,string returnUrl)
		{
			if (ModelState.IsValid)
			{
				AppUser user = await userManager.FindByEmailAsync(details.Email);
				if (user != null)
				{
					await signInManager.SignOutAsync();
					Microsoft.AspNetCore.Identity.SignInResult result =
					await signInManager.PasswordSignInAsync(
					user, details.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index","Home");
					}
				}
				ModelState.AddModelError(nameof(LoginModel.Email),
				"Invalid user or password");
			}
			return View(details);
		}

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
            return Redirect("/Home/Index");
		}

		[AllowAnonymous]
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}