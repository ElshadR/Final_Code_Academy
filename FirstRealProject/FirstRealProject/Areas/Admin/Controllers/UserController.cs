using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.Admin.Models;
using FirstRealProject.Areas.User.Models.ViewModels;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private FirstRealProjectDbContext _dbContext;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IFindAnnounce _findAnnounce;
        public UserController(FirstRealProjectDbContext dbContext ,UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr,
            IFindAnnounce findAnnounce)
        {
            _dbContext = dbContext;
            _userManager = userMgr;
            _signInManager = signinMgr;
            _findAnnounce = findAnnounce;
        }


  
        public async Task<IActionResult> Users(string roleName,string name)
        {


            AppUserModelA userModelA = new AppUserModelA
            {
                HeaderName = name,
                RoleName=roleName,
                AppUsers = !String.IsNullOrEmpty(roleName) ? await _userManager.GetUsersInRoleAsync(roleName)
                                            : await _userManager.Users.ToListAsync(),

            };

            return View(userModelA);
        }

        public async Task<IActionResult> Create(string roleName, string headername) => View(new UserRegisterModelA
        {
            RoleName=roleName,
            HeaderName=headername,
            Roles=await _dbContext.Roles.ToListAsync()
        });

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterModelA model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { Email = model.Email, UserName = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
          
                    var result2= await _userManager.AddToRolesAsync(user, model.UserRoles);

                    if(result2.Succeeded)
                        return RedirectToAction("Users", new { roleName = model.RoleName, name = model.HeaderName });
                    else
                    {
                        foreach (var error in result2.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            model.Roles = await _dbContext.Roles.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Edit(string id, string roleName, string headername)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            UserChangeModelA model = new  UserChangeModelA{ Id = user.Id,Name=user.UserName, Email = user.Email,Phone=user.PhoneNumber };
            model.AllRoles = await _dbContext.Roles.ToListAsync();
            model.UserRoles=await _userManager.GetRolesAsync(user);
            model.RoleName = roleName;
            model.HeaderName = headername;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserChangeModelA model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;
                    user.PhoneNumber = model.Phone;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        var allRoles = _dbContext.Roles.ToList();
                        var addedRoles = model.UserRoles.Except(userRoles);
                        var removedRoles = userRoles.Except(model.UserRoles);
                        await _userManager.AddToRolesAsync(user, addedRoles);
                        await _userManager.RemoveFromRolesAsync(user, removedRoles);
                        return RedirectToAction("Users", new {roleName=model.RoleName, name = model.HeaderName });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id, string roleName, string headername)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Users", new { roleName, name = headername });
        }

        public async Task<ActionResult> Details(string id)
        {
            UserViewModel dataUser = await _findAnnounce.FindUserDataAsync(id);

            return View(dataUser);
        }
    }
}