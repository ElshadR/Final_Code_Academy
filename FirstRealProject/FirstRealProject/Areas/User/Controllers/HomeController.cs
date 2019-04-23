using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.User.Models.ViewModels;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Transports.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Areas.Users.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }

        public HomeController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr,FirstRealProjectDbContext dbContext,IFindAnnounce dataFind)
        {
            _dbContext = dbContext;
            _userManager = userMgr;
            _signInManager = signinMgr;
            _dataFind = dataFind;
        }

        public async Task<IActionResult> Index()
        {
            //sign in user find id
            string id = _userManager.GetUserId(User);

            //find sign in user 
            UserViewModel dataUser =await _dataFind.FindUserDataAsync(id);
            dataUser.CommonAnnounceCount = dataUser.NonPublishedAnnounces.Count + dataUser.PublishedAnnounces.Count + dataUser.CheckInAnnounces.Count;
            return View(dataUser);
        }

        public async Task<IActionResult> Announces(string type)
        {
            //sign in user find id
            string id = _userManager.GetUserId(User);

            //find sign in user 
            UserViewModel dataUser = await _dataFind.FindUserDataAsync(id);
            dataUser.CommonAnnounceCount = dataUser.NonPublishedAnnounces.Count + dataUser.PublishedAnnounces.Count + dataUser.CheckInAnnounces.Count;
            if(type.ToLower()=="published")
                return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", dataUser.PublishedAnnounces);
            if(type.ToLower() == "ended")
                return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", dataUser.EndedAnnounces);
            if(type.ToLower() == "checkin")
                return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", dataUser.CheckInAnnounces);
            if(type.ToLower() == "nonpublished")
                return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", dataUser.NonPublishedAnnounces);


            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", null);
        }
    }
}