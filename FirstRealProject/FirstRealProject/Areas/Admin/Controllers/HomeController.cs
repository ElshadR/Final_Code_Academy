using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.Admin.Models;
using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Areas.Admin.Models.Enums;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Models.Transports.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
		private IUserValidator<AppUser> userValidator;
		private IPasswordValidator<AppUser> passwordValidator;
		private IPasswordHasher<AppUser> passwordHasher;

        private IFindAnnounce _findData;
        private IHostingEnvironment _hostingEnvironment { get; set; }

        private UserManager<AppUser> _userManager;
        private FirstRealProjectDbContext _db;

        public HomeController(UserManager<AppUser> usrMgr,IUserValidator<AppUser> userValid,IFindAnnounce find,
		IPasswordValidator<AppUser> passValid,IPasswordHasher<AppUser> passwordHash, FirstRealProjectDbContext db,
        IHostingEnvironment hostingEnvironment)
		{
			userValidator = userValid;
			passwordValidator = passValid;
			passwordHasher = passwordHash;
			_userManager = usrMgr;
			_db = db;
            _findData = find;
            _hostingEnvironment = hostingEnvironment;
		}

        //view common announces
        public async Task<IActionResult> Index(FindTableA findTable, int page=0,int count=15)
        {
            var commondata = await _findData.GetAnnouncesA(findTable,FindStatusAnnounceA.Common);
            ViewPageA viewPageA = new ViewPageA()
            {
                ViewAnnounceAs = await _findData.GetAnnouncesA(findTable, FindStatusAnnounceA.Common,page, count),
                 
                Pagination =new PaginationA(commondata.Count(), count, page)
                {
                    AreaName="Admin",
                    ControllerName="home",
                    ActionName="index",
                    FindTable=findTable
                }
            };

            return View(viewPageA);
        }
        public async Task<IActionResult> DeleteAnnounce(FindTableA findTable, int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            List<string> paths = new List<string>();
            switch (findTable)
            {
                case FindTableA.Common:
                    return RedirectToAction("index", "home", new { area = "Admin" });

                case FindTableA.Car:

                    try
                    {
                        var announce = await _db.Cars.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.CarPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Cars.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Car);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }

                case FindTableA.Bus:
                    try
                    {
                        var announce = await _db.Buses.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.BusPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Buses.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Bus);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Accessory:
                    try
                    {
                        var announce = await _db.Accessories.FindAsync(id);

                        if (announce == null)
                            return NotFound();


                        foreach (var item in announce.AccessoryPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Accessories.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Accessory);

                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Motocycle:
                    try
                    {
                        var announce = await _db.Motocycles.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.MotocyclePhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Motocycles.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Motocycle);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Apartment:
                    try
                    {
                        var announce = await _db.Apartments.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.ApartmentPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Apartments.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Apartment);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.House:
                    try
                    {
                        var announce = await _db.Houses.FindAsync(id);

                        if (announce == null)
                            return NotFound();


                        foreach (var item in announce.HousePhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Houses.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.House);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Office:
                    try
                    {
                        var announce = await _db.Offices.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.OfficePhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Offices.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Office);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Garage:
                    try
                    {
                        var announce = await _db.Garages.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.GaragePhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Garages.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Garage);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Land:
                    try
                    {
                        var announce = await _db.Lands.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.LandPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Lands.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Land);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Job:
                    try
                    {
                        var announce = await _db.Jobs.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.JobPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Jobs.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Job);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Business:
                    try
                    {
                        var announce = await _db.BusinessEquipments.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.BusinessEPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.BusinessEquipments.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Business);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                case FindTableA.Food:
                    try
                    {
                        var announce = await _db.Foods.FindAsync(id);

                        if (announce == null)
                            return NotFound();

                        foreach (var item in announce.FoodPhotos)
                        {
                            paths.Add(item.Path);

                        }

                        _db.Foods.Remove(announce);

                        await _db.SaveChangesAsync();

                        await DeletePhotoAfter(paths, FindTableA.Food);


                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                    catch (Exception exp)
                    {
                        return RedirectToAction("index", "home", new { area = "Admin" });
                    }
                default:
                    return RedirectToAction("index", "home", new { area = "Admin" });
            }
        }

        public async Task<IActionResult> DeletePhotoAfter(List<string> photos, FindTableA findTable)
        {
            try
            {
                switch (findTable)
                {
                    case FindTableA.Common:
                        return Json("fail");
                    case FindTableA.Car:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);

                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                        }
                        return Json("success");
                    case FindTableA.Bus:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                        }
                        return Json("success");
                    case FindTableA.Accessory:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                        }
                        return Json("success");
                    case FindTableA.Motocycle:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                        }
                        return Json("success");
                    case FindTableA.Apartment:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                        }
                        return Json("success");
                    case FindTableA.House:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                        }
                        return Json("success");
                    case FindTableA.Office:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                        }
                        return Json("success");
                    case FindTableA.Garage:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                        }
                        return Json("success");
                    case FindTableA.Land:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                        }
                        return Json("success");
                    case FindTableA.Job:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                                
                        }
                        return Json("success");
                    case FindTableA.Business:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);
                                
                        }
                        return Json("success");
                    case FindTableA.Food:
                        foreach (var item in photos)
                        {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                              
                        }
                        return Json("success");
                    default:
                        return Json("fail");
                }
            }
            catch (Exception)
            {
                return Json("fail");
            }
        }
        public async Task<IActionResult> DeletePhoto(int announceId, FindTableA findTable,int photoId)
        {
            try
            {
                switch (findTable)
                {
                    case FindTableA.Common:
                        return Json("fail");
                    case FindTableA.Car:
                        var photos = await _db.CarPhotos.Where(p => p.CarId == announceId).ToListAsync();
                        foreach (var item in photos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);



                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.CarPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Bus:
                        var busphotos = await _db.BusPhotos.Where(p => p.BusId == announceId).ToListAsync();
                        foreach (var item in busphotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.BusPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Accessory:
                        var accessoryphotos = await _db.AccessoryPhotos.Where(p => p.AccessoryId == announceId).ToListAsync();
                        foreach (var item in accessoryphotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.AccessoryPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Motocycle:
                        var motocyclephotos = await _db.MotocyclePhotos.Where(p => p.MotocycleId == announceId).ToListAsync();
                        foreach (var item in motocyclephotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.MotocyclePhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Apartment:
                        var apartmentphotos = await _db.ApartmentPhotos.Where(p => p.ApartmentId == announceId).ToListAsync();
                        foreach (var item in apartmentphotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.ApartmentPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.House:
                        var housephotos = await _db.HousePhotos.Where(p => p.HouseId == announceId).ToListAsync();
                        foreach (var item in housephotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.HousePhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Office:
                        var officephotos = await _db.OfficePhotos.Where(p => p.OfficeId == announceId).ToListAsync();
                        foreach (var item in officephotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.OfficePhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Garage:
                        var garagephotos = await _db.GaragePhotos.Where(p => p.GarageId == announceId).ToListAsync();
                        foreach (var item in garagephotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.GaragePhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Land:
                        var landphotos = await _db.LandPhotos.Where(p => p.LandId == announceId).ToListAsync();
                        foreach (var item in landphotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.LandPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Job:
                        var jobphotos = await _db.JobPhotos.Where(p => p.JobId == announceId).ToListAsync();
                        foreach (var item in jobphotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.JobPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Business:
                        var businesphotos = await _db.BusinessEPhotos.Where(p => p.BusinessEquipmentId == announceId).ToListAsync();
                        foreach (var item in businesphotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.BusinessEPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    case FindTableA.Food:
                        var foodphotos = await _db.FoodPhotos.Where(p => p.FoodId == announceId).ToListAsync();
                        foreach (var item in foodphotos)
                        {
                            if (item.Id == photoId)
                            {
                                string webRootPath = _hostingEnvironment.WebRootPath;

                                string fullPath = Path.Combine(webRootPath);
                                foreach (var ite in item.Path.Split('/'))
                                {
                                    fullPath = Path.Combine(fullPath, ite);
                                }

                                if (!Directory.Exists(fullPath))
                                    System.IO.File.Delete(fullPath);

                                _db.FoodPhotos.Remove(item);

                                await _db.SaveChangesAsync();
                            }
                        }
                        return Json("success");
                    default:
                        return Json("fail");
                }
            }
            catch (Exception)
            {
                return Json("fail");
            }
        }
        //view non check in announces
        public async Task<IActionResult> NonCheckIn(FindTableA findTable, int page = 0, int count = 15)
        {
            var commondata = await _findData.GetAnnouncesA(findTable,FindStatusAnnounceA.NonCheckIn);
            ViewPageA viewPageA = new ViewPageA
            {
                ViewAnnounceAs = await _findData.GetAnnouncesA(findTable, FindStatusAnnounceA.NonCheckIn, page, count),
                Pagination = new PaginationA(commondata.Count(), count, page)
                {
                    AreaName = "Admin",
                    ControllerName = "home",
                    ActionName = "index",
                    FindTable = findTable
                }
            };

            return View(viewPageA);
        }

        //view published announces
        public async Task<IActionResult> Published(FindTableA findTable, int page = 0, int count = 15)
        {
            var commondata = await _findData.GetAnnouncesA(findTable, FindStatusAnnounceA.Published);
            ViewPageA viewPageA = new ViewPageA
            {
                ViewAnnounceAs = await _findData.GetAnnouncesA(findTable, FindStatusAnnounceA.Published, page, count),
                Pagination = new PaginationA(commondata.Count(), count, page)
                {
                    AreaName = "Admin",
                    ControllerName = "home",
                    ActionName = "index",
                    FindTable = findTable
                }
            };

            return View(viewPageA);
        }

        //view non published announces
        public async Task<IActionResult> NonPublished(FindTableA findTable, int page = 0, int count = 15)
        {
            var commondata = await _findData.GetAnnouncesA(findTable, FindStatusAnnounceA.NonPublished);
            ViewPageA viewPageA = new ViewPageA
            {
                ViewAnnounceAs = await _findData.GetAnnouncesA(findTable, FindStatusAnnounceA.NonPublished, page, count),
                Pagination = new PaginationA(commondata.Count(), count, page)
                {
                    AreaName = "Admin",
                    ControllerName = "home",
                    ActionName = "index",
                    FindTable = findTable
                }
            };

            return View(viewPageA);
        }
        public async Task<IActionResult> CarEditAnnounce(int id, FindTable findTable)
        {
            var data = await _findData.GetCar(id, "", false);

            if (id == 0 || data==null)
                return NotFound();

            return View(data);
        }

        public async Task<IActionResult> Comments( int page = 0, int count = 15,bool checkin=false)
        {
            var data = await _db.Comments.Where(x=>x.CheckIn==checkin).Skip(page*count).Take(count).ToListAsync();
            var commondata = await _db.Comments.ToListAsync();
            var commentdata = new CommentModel
            {
                Comments = data,
                Pagination = new PaginationA(commondata.Count(), count, page)
                {
                    AreaName = "Admin",
                    ControllerName = "home",
                    ActionName = "comments",
                }
            };
            return View(commentdata);
        }
        public async Task<IActionResult> CommentDelete(int? id,bool checkin)
        {
            try
            {
                if (id == 0 || id == null)
                    return NotFound();

                var comment = await _db.Comments.FindAsync(id);

                _db.Comments.Remove(comment);
                await _db.SaveChangesAsync();
                return RedirectToAction("comments", "home",new { checkin });
            }
            catch (Exception)
            {
                return RedirectToAction("comments", "home", new { checkin });
            }
        }
        public async Task<IActionResult> CommentEdit(int? id,bool checkin,bool check)
        {
            try
            {
                if (id == 0 || id == null)
                    return NotFound();

                var comment = await _db.Comments.FindAsync(id);
                if (comment.CheckInDate==null && checkin)
                {
                    comment.CheckIn = checkin;
                    comment.CheckInDate = DateTime.Now;
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("comments", "home", new { check });
            }
            catch (Exception)
            {
                return RedirectToAction("comments", "home", new { check });
            }
        }
    }
}