using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Jobs;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstRealProject.Areas.Admin.Controllers.Jobs
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class JobController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _findData { get; set; }
        private IUpdateAnnounce _updateData { get; set; }



        public JobController(FirstRealProjectDbContext dbContext, IFindAnnounce finddata, IUpdateAnnounce updateData)
        {
            _dbContext = dbContext;
            _findData = finddata;
            _updateData = updateData;
        }

        public IActionResult Index()
        {
            return View();
        }
		//Job
		public async Task<IActionResult> JobEdit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetJobA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> JobEdit(JobEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateJobA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("jobedit", "job", new { id = announce.Id });
        }
		public async Task<IActionResult> JobRead(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetJobA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Business
		public async Task<IActionResult> BusinessEdit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetBusinessA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> BusinessEdit(BusinessEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateBusinessA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("jobedit", "job", new { id = announce.Id });
        }
		public async Task<IActionResult> BusinessRead(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetBusinessA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Food
		public async Task<IActionResult> FoodEdit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetFoodA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> FoodEdit(FoodEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateFoodA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("jobedit", "job", new { id = announce.Id });
        }
		public async Task<IActionResult> FoodRead(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetFoodA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
	}
}