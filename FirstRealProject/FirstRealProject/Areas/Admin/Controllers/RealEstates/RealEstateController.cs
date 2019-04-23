using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstRealProject.Areas.Admin.Controllers.RealEstates
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class RealEstateController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _findData { get; set; }
        private IUpdateAnnounce _updateData { get; set; }



        public RealEstateController(FirstRealProjectDbContext dbContext, IFindAnnounce finddata, IUpdateAnnounce updateData)
        {
            _dbContext = dbContext;
            _findData = finddata;
            _updateData = updateData;
        }


        public IActionResult Index()
        {
            return View();
        }
		//Apartment
		[HttpGet]
		public async Task<IActionResult> ApartmentEdit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetApartmentA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> ApartmentEdit(ApartmentEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateApartmentA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("apartmentedit", "realestate", new { id = announce.Id });
        }
		public async Task<IActionResult> ApartmentRead(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetApartmentA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Commercial
		public async Task<IActionResult> CommercialEdit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetOfficeA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> CommercialEdit(CommercialEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateOfficeA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("commercialedit", "realestate", new { id = announce.Id });
        }
		public async Task<IActionResult> CommercialRead(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetOfficeA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Garage
		public async Task<IActionResult> GarageEdit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetGarageA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> GarageEdit(GarageEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateGarageA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("garageedit", "realestate", new { id = announce.Id });
        }
		public async Task<IActionResult> GarageRead(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetGarageA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//HouseVillas
		public async Task<IActionResult> HouseVillaEdit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetHouseA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
		[HttpPost]
		public async Task<IActionResult> HouseVillaEdit(HouseVillaEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateHouseA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin", findtable = announce.FindTable });

            }
            return RedirectToAction("housevillaedit", "realestate", new { id = announce.Id, findtable = announce.FindTable });
        }
		public async Task<IActionResult> HouseVillaRead(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetHouseA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }

		//Land
		public async Task<IActionResult> LandEdit(int? id)
		{
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetLandA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
		}
		[HttpPost]
		public async Task<IActionResult> LandEdit(LandEditModel announce)
        {
            if (ModelState.IsValid)
            {
                var success = await _updateData.UpdateLandA(announce);

                if (success)
                    return RedirectToAction("index", "home", new { area = "Admin",findtable=announce.FindTable });

            }
            return RedirectToAction("landedit", "realestate", new { id = announce.Id });
        }
		public async Task<IActionResult> LandRead(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var announce = await _findData.GetLandA(id);

            if (announce == null)
                return NotFound();

            return View(announce);
        }
	}
}