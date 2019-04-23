using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Areas.Admin.Controllers.Transport
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
    public class TransportController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _findData { get; set; }
        private IUpdateAnnounce _updateData { get; set; }



        public TransportController(FirstRealProjectDbContext dbContext,IFindAnnounce finddata,IUpdateAnnounce updateData)
        {
            _dbContext = dbContext;
            _findData = finddata;
            _updateData = updateData;
        }

        //Car
        public async Task<IActionResult> CarEdit(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetCarA(id);

            announce.ControllerName = "transport";
            announce.ActionName = "caredit";

            if (announce == null)
                return NotFound();

			return View(announce);
		}
		[HttpPost]
		public async Task<IActionResult> CarEdit(CarEditModel announce)
		{
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateCarA(announce);

                if(success)
                    return RedirectToAction("index", "home", new { area="Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("caredit","transport",new { id=announce.Id});
		}
		public async Task<IActionResult> CarRead(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetCarA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Bus
		public async Task<IActionResult> BusEdit(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetBusA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> BusEdit(BusEditModel announce)
		{
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateBusA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("caredit", "transport", new { id = announce.Id });
        }
		public async Task<IActionResult> BusRead(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetBusA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Motorcycle
		public async Task<IActionResult> MotorcycleEdit(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetMotocycleA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> MotorcycleEdit(MotorcycleEditModel announce)
		{
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateMotocycleA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("caredit", "transport", new { id = announce.Id });
        }
		public async Task<IActionResult> MotorcycleRead(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetMotocycleA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Accessory
		public async Task<IActionResult> AccessoryEdit(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetAccessoryA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> AccessoryEdit(AccessoryEditModel announce)
		{
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateAccessoryA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("caredit", "transport", new { id = announce.Id });
        }
		public async Task<IActionResult> AccessoryRead(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetAccessoryA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
	}
}