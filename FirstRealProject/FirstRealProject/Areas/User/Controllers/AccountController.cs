using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.Users.Models;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace FirstRealProject.Areas.Users.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

		[Authorize]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new UserLoginModel());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(
                    user, details.Password, false, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError(nameof(UserLoginModel.Email),
                "Invalid user or password");
            }
            return View(details);
        }


        public IActionResult Register(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
					IdentityResult resultRole = await userManager.AddToRoleAsync(user, "User");
					if (resultRole.Succeeded)
					{
						await signInManager.SignOutAsync();
						Microsoft.AspNetCore.Identity.SignInResult results = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                        return RedirectToAction("Index", "Home");
					}
					else
					{
						foreach (IdentityError error in resultRole.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
					}
				}
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}