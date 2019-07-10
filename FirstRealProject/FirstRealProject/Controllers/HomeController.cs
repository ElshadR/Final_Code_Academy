using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstRealProject.Models;
using FirstRealProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Infrastructure.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Commons;
using Microsoft.AspNetCore.Identity;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.PagesModels.ViewModel.Common;
using FirstRealProject.Models.Transports.MotocycleModels;
using Microsoft.Extensions.Logging;

namespace FirstRealProject.Controllers
{
    public class HomeController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }
        private IAnnounceToAdd _addAnnounce { get; set; }
        private ISettingAnnounce _setting { get; set; }
        private UserManager<AppUser> _userManager;
        private IHostingEnvironment _hostingEnvironment { get; set; }
        readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userMgr, IHostingEnvironment hostingEnvironment, FirstRealProjectDbContext dbContext, IAnnounceToAdd toAdd, IFindAnnounce dataFind, ISettingAnnounce setting)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
            _setting = setting;
            _userManager = userMgr;
            _addAnnounce = toAdd;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public async Task<IActionResult> SelectedAnnounces()
        {
            
            var carCookie = Request.Cookies["carId"]?.Split(',');
            var busCookie = Request.Cookies["busId"]?.Split(',');
            var accessoryCookie = Request.Cookies["accessoryId"]?.Split(',');
            var motocycleCookie = Request.Cookies["motocycleId"]?.Split(',');
            var apartmentCookie = Request.Cookies["apartmentId"]?.Split(',');
            var houseCookie = Request.Cookies["houseId"]?.Split(',');
            var officeCookie = Request.Cookies["officeId"]?.Split(',');
            var garageCookie = Request.Cookies["garageId"]?.Split(',');
            var landCookie = Request.Cookies["landId"]?.Split(',');
            var jobCookie = Request.Cookies["jobId"]?.Split(',');
            var businessCookie = Request.Cookies["businessId"]?.Split(',');
            var foodCookie = Request.Cookies["foodId"]?.Split(',');

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (carCookie != null)
            {
                try
                {
                    data.AddRange(SelectCars(carCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Cars were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add cars to the list");
                }

            }
            if (busCookie != null)
            {
                try
                {
                    data.AddRange(SelectBuses(busCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Buses were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add buses to the list");
                }
                
            }
            if (motocycleCookie != null)
            {
                try
                {
                    data.AddRange(SelectMotocycles(motocycleCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Motocycles were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add motocycles to the list");
                }
            }
            if (accessoryCookie != null)
            {
                try
                {
                    data.AddRange(SelectAccessories(accessoryCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Accessories were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add accessories to the list");
                }
            }
            if (apartmentCookie != null)
            {
                try
                {
                    data.AddRange(SelectApartments(apartmentCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Apartments were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add apartments to the list");
                }
            }
            if (houseCookie != null)
            {
                try
                {
                    data.AddRange(SelectHouses(houseCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Houses were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add houses to the list");
                }
            }
            if (officeCookie != null)
            {
                try
                {
                    data.AddRange(SelectOffices(officeCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Offices were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add offices to the list");
                }
            }
            if (landCookie != null)
            {
                try
                {
                    data.AddRange(SelectLands(landCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Lands were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add lands to the list");
                }
            }
            if (garageCookie != null)
            {
                try
                {
                    data.AddRange(SelectGarages(garageCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Garages were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add garages to the list");
                }
            }
            if (jobCookie != null)
            {
                try
                {
                    data.AddRange(SelectJobs(jobCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Jobs were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add jobs to the list");
                }
            }
            if (businessCookie != null)
            {
                try
                {
                    data.AddRange(SelectBusinesses(businessCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Businesses were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add businesses to the list");
                }
            }
            if (foodCookie != null)
            {
                try
                {
                data.AddRange(SelectFoods(foodCookie).GetAwaiter().GetResult());
                    _logger.LogInformation("Foods were added to the list");
                }
                catch (Exception exp)
                {
                    _logger.LogError(exp, "Could not add foods to the list");
                }
            }

            return View(data);
        }

        public async  Task<IEnumerable<ViewAnnounce>> SelectCars(string[] carCookie )
        {
            try
            {
                IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
                if (carCookie != null && carCookie.Count() != 0)
                {
                    announces = await _dbContext.Cars
                                             .Where(c => carCookie.Contains(c.Id.ToString()))
                                             .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                             .Select(c => new ViewAnnounce(FindTable.Car)
                                             {
                                                 Id = c.Id,
                                                 Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                                 Price = c.Price,
                                                 City = c.City.Name,
                                                 AnnounceUnicode = c.AnnounceUniqueCode,
                                                 AddedPublishDate = c.AnnouncePublishDate.Value,
                                                 SelectedAnnounce = true,
                                                 ActivePhoto = c.CarPhotos.Select(p => new ViewPhoto
                                                 {
                                                     Id = p.Id,
                                                     Path = p.Path,
                                                     AnnounceId = c.Id,

                                                 }).FirstOrDefault(),
                                                 Photos = c.CarPhotos.Select(p => new ViewPhoto
                                                 {
                                                     Id = p.Id,
                                                     Path = p.Path,
                                                     AnnounceId = c.Id,

                                                 }).ToList(),
                                             }).ToListAsync();
                }
                return announces;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public async Task<IEnumerable<ViewAnnounce>> SelectBuses(string[] busCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (busCookie != null && busCookie.Count() != 0)
            {
                announces = await _dbContext.Buses
                                         .Where(c => busCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Bus)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.BusPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.BusPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectMotocycles(string[] motocycleCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (motocycleCookie != null && motocycleCookie.Count() != 0)
            {
                announces = await _dbContext.Motocycles
                                         .Where(c => motocycleCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.MotocyclePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.MotocyclePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectAccessories(string[] accessoryCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (accessoryCookie != null && accessoryCookie.Count() != 0)
            {
                announces = await _dbContext.Accessories
                                         .Where(c => accessoryCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Accessory)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.AccessoryPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.AccessoryPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectApartments(string[] apartmentCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (apartmentCookie != null && apartmentCookie.Count() != 0)
            {
                announces = await _dbContext.Apartments
                                         .Where(c => apartmentCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Apartment)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Apartment),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.ApartmentPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.ApartmentPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectHouses(string[] hoseCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (hoseCookie != null && hoseCookie.Count() != 0)
            {
                announces = await _dbContext.Houses
                                         .Where(c => hoseCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.House)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.House),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.HousePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.HousePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectOffices(string[] officeCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (officeCookie != null && officeCookie.Count() != 0)
            {
                announces = await _dbContext.Offices
                                         .Where(c => officeCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Office)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Office),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.OfficePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.OfficePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectLands(string[] landCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (landCookie != null && landCookie.Count() != 0)
            {
                announces = await _dbContext.Lands
                                         .Where(c => landCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Land)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.LandPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.LandPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }

        public async Task<IEnumerable<ViewAnnounce>> SelectGarages(string[] garageCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (garageCookie != null && garageCookie.Count() != 0)
            {
                announces = await _dbContext.Garages
                                         .Where(c => garageCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Garage)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.GaragePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.GaragePhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectJobs(string[] jobCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (jobCookie != null && jobCookie.Count() != 0)
            {
                announces = await _dbContext.Jobs
                                         .Where(c => jobCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                          .Select(c => new ViewAnnounce(FindTable.Job)
                                          {
                                              Id = c.Id,
                                              Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                              Price = c.Price,
                                              City = c.City.Name,
                                              AnnounceUnicode = c.AnnounceUniqueCode,
                                              AddedPublishDate = c.AnnouncePublishDate.Value,
                                              SelectedAnnounce = true,
                                              ActivePhoto = c.JobPhotos.Select(p => new ViewPhoto
                                              {
                                                  Id = p.Id,
                                                  Path = p.Path,
                                                  AnnounceId = c.Id,

                                              }).FirstOrDefault(),
                                              Photos = c.JobPhotos.Select(p => new ViewPhoto
                                              {
                                                  Id = p.Id,
                                                  Path = p.Path,
                                                  AnnounceId = c.Id,

                                              }).ToList(),
                                          }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectBusinesses(string[] businessCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (businessCookie != null && businessCookie.Count() != 0)
            {
                announces = await _dbContext.BusinessEquipments
                                         .Where(c => businessCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Business)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.BusinessEPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.BusinessEPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IEnumerable<ViewAnnounce>> SelectFoods(string[] foodCookie)
        {
            IEnumerable<ViewAnnounce> announces = new List<ViewAnnounce>();
            if (foodCookie != null && foodCookie.Count() != 0)
            {
                announces = await _dbContext.Foods
                                         .Where(c => foodCookie.Contains(c.Id.ToString()))
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Food)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,
                                             SelectedAnnounce = true,
                                             ActivePhoto = c.FoodPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.FoodPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).ToListAsync();
            }
            return announces;
        }
        public async Task<IActionResult> CompairAnnounces()
        {
            List<ViewAnnounce> data = new List<ViewAnnounce>();
            try
            {
                string compairAnnounces = HttpContext.Session.GetString("compair");
                var compairs = compairAnnounces.Split('/');
                for (int i = 1; i < compairs.Length; i++)
                {
                    var item = compairs[i].TrimStart('{').TrimEnd('}').Split(',');
                    int id;
                    if (Int32.TryParse(item[0], out id))
                    {
                        switch (item[1].ToLower())
                        {
                            case "car":
                                var announceCar = await _dbContext.Cars
                                         .Where(c => c.Id == id)
                                         .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                         .Select(c => new ViewAnnounce(FindTable.Car)
                                         {
                                             Id = c.Id,
                                             Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                             Price = c.Price,
                                             City = c.City.Name,
                                             AnnounceUnicode = c.AnnounceUniqueCode,
                                             AddedPublishDate = c.AnnouncePublishDate.Value,

                                             ActivePhoto = c.CarPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).FirstOrDefault(),
                                             Photos = c.CarPhotos.Select(p => new ViewPhoto
                                             {
                                                 Id = p.Id,
                                                 Path = p.Path,
                                                 AnnounceId = c.Id,

                                             }).ToList(),
                                         }).SingleOrDefaultAsync();
                                data.Add(announceCar);
                                break;
                            case "motocycle":
                                var announceMotocycle = await _dbContext.Motocycles
                                     .Where(c => c.Id == id)
                                     .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                     .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                     {
                                         Id = c.Id,
                                         Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                         Price = c.Price,
                                         City = c.City.Name,
                                         AnnounceUnicode = c.AnnounceUniqueCode,
                                         AddedPublishDate = c.AnnouncePublishDate.Value,

                                         ActivePhoto = c.MotocyclePhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).FirstOrDefault(),
                                         Photos = c.MotocyclePhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).ToList(),
                                     }).SingleOrDefaultAsync();
                                data.Add(announceMotocycle);
                                break;
                            case "bus":
                                var announceBus = await _dbContext.Buses
                                     .Where(c => c.Id == id)
                                     .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                     .Select(c => new ViewAnnounce(FindTable.Bus)
                                     {
                                         Id = c.Id,
                                         Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                         Price = c.Price,
                                         City = c.City.Name,
                                         AnnounceUnicode = c.AnnounceUniqueCode,
                                         AddedPublishDate = c.AnnouncePublishDate.Value,

                                         ActivePhoto = c.BusPhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).FirstOrDefault(),
                                         Photos = c.BusPhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).ToList(),
                                     }).SingleOrDefaultAsync();
                                data.Add(announceBus);
                                break;
                            case "accessory":
                                var announceAccessory = await _dbContext.Accessories
                                     .Where(c => c.Id == id)
                                     .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                     .Select(c => new ViewAnnounce(FindTable.Accessory)
                                     {
                                         Id = c.Id,
                                         Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                         Price = c.Price,
                                         City = c.City.Name,
                                         AnnounceUnicode = c.AnnounceUniqueCode,
                                         AddedPublishDate = c.AnnouncePublishDate.Value,

                                         ActivePhoto = c.AccessoryPhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).FirstOrDefault(),
                                         Photos = c.AccessoryPhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).ToList(),
                                     }).SingleOrDefaultAsync();
                                data.Add(announceAccessory);
                                break;
                            case "apartment":
                                var announceApartment = await _dbContext.Apartments
                                    .Where(c => c.Id == id)
                                    .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                    .Select(c => new ViewAnnounce(FindTable.Apartment)
                                    {
                                        Id = c.Id,
                                        Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Apartment),
                                        Price = c.Price,
                                        City = c.City.Name,
                                        AnnounceUnicode = c.AnnounceUniqueCode,
                                        AddedPublishDate = c.AnnouncePublishDate.Value,

                                        ActivePhoto = c.ApartmentPhotos.Select(p => new ViewPhoto
                                        {
                                            Id = p.Id,
                                            Path = p.Path,
                                            AnnounceId = c.Id,

                                        }).FirstOrDefault(),
                                        Photos = c.ApartmentPhotos.Select(p => new ViewPhoto
                                        {
                                            Id = p.Id,
                                            Path = p.Path,
                                            AnnounceId = c.Id,

                                        }).ToList(),
                                    }).SingleOrDefaultAsync();
                                data.Add(announceApartment);
                                break;
                            case "house":
                                var announceHouse = await _dbContext.Houses
                                      .Where(c => c.Id == id)
                                      .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                      .Select(c => new ViewAnnounce(FindTable.House)
                                      {
                                          Id = c.Id,
                                          Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.House),
                                          Price = c.Price,
                                          City = c.City.Name,
                                          AnnounceUnicode = c.AnnounceUniqueCode,
                                          AddedPublishDate = c.AnnouncePublishDate.Value,

                                          ActivePhoto = c.HousePhotos.Select(p => new ViewPhoto
                                          {
                                              Id = p.Id,
                                              Path = p.Path,
                                              AnnounceId = c.Id,

                                          }).FirstOrDefault(),
                                          Photos = c.HousePhotos.Select(p => new ViewPhoto
                                          {
                                              Id = p.Id,
                                              Path = p.Path,
                                              AnnounceId = c.Id,

                                          }).ToList(),
                                      }).SingleOrDefaultAsync();
                                data.Add(announceHouse);
                                break;
                            case "office":
                                var announceOffice = await _dbContext.Offices
                                     .Where(c => c.Id == id)
                                     .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                     .Select(c => new ViewAnnounce(FindTable.Office)
                                     {
                                         Id = c.Id,
                                         Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Office),
                                         Price = c.Price,
                                         City = c.City.Name,
                                         AnnounceUnicode = c.AnnounceUniqueCode,
                                         AddedPublishDate = c.AnnouncePublishDate.Value,

                                         ActivePhoto = c.OfficePhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).FirstOrDefault(),
                                         Photos = c.OfficePhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).ToList(),
                                     }).SingleOrDefaultAsync();
                                data.Add(announceOffice);
                                break;
                            case "land":
                                var announceLand = await _dbContext.Lands
                                    .Where(c => c.Id == id)
                                    .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                    .Select(c => new ViewAnnounce(FindTable.Land)
                                    {
                                        Id = c.Id,
                                        Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                        Price = c.Price,
                                        City = c.City.Name,
                                        AnnounceUnicode = c.AnnounceUniqueCode,
                                        AddedPublishDate = c.AnnouncePublishDate.Value,

                                        ActivePhoto = c.LandPhotos.Select(p => new ViewPhoto
                                        {
                                            Id = p.Id,
                                            Path = p.Path,
                                            AnnounceId = c.Id,

                                        }).FirstOrDefault(),
                                        Photos = c.LandPhotos.Select(p => new ViewPhoto
                                        {
                                            Id = p.Id,
                                            Path = p.Path,
                                            AnnounceId = c.Id,

                                        }).ToList(),
                                    }).SingleOrDefaultAsync();
                                data.Add(announceLand);
                                break;
                            case "garage":
                                var announceGarage = await _dbContext.Garages
                                     .Where(c => c.Id == id)
                                     .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                     .Select(c => new ViewAnnounce(FindTable.Garage)
                                     {
                                         Id = c.Id,
                                         Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                         Price = c.Price,
                                         City = c.City.Name,
                                         AnnounceUnicode = c.AnnounceUniqueCode,
                                         AddedPublishDate = c.AnnouncePublishDate.Value,

                                         ActivePhoto = c.GaragePhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).FirstOrDefault(),
                                         Photos = c.GaragePhotos.Select(p => new ViewPhoto
                                         {
                                             Id = p.Id,
                                             Path = p.Path,
                                             AnnounceId = c.Id,

                                         }).ToList(),
                                     }).SingleOrDefaultAsync();
                                data.Add(announceGarage);
                                break;
                            case "job":
                                var announceJob = await _dbContext.Jobs
                                    .Where(c => c.Id == id)
                                    .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                    .Select(c => new ViewAnnounce(FindTable.Job)
                                    {
                                        Id = c.Id,
                                        Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                        Price = c.Price,
                                        City = c.City.Name,
                                        AnnounceUnicode = c.AnnounceUniqueCode,
                                        AddedPublishDate = c.AnnouncePublishDate.Value,

                                        ActivePhoto = c.JobPhotos.Select(p => new ViewPhoto
                                        {
                                            Id = p.Id,
                                            Path = p.Path,
                                            AnnounceId = c.Id,

                                        }).FirstOrDefault(),
                                        Photos = c.JobPhotos.Select(p => new ViewPhoto
                                        {
                                            Id = p.Id,
                                            Path = p.Path,
                                            AnnounceId = c.Id,

                                        }).ToList(),
                                    }).SingleOrDefaultAsync();
                                data.Add(announceJob);
                                break;
                            case "business":
                                var announceBusiness = await _dbContext.BusinessEquipments
                                   .Where(c => c.Id == id)
                                   .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                   .Select(c => new ViewAnnounce(FindTable.Business)
                                   {
                                       Id = c.Id,
                                       Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                       Price = c.Price,
                                       City = c.City.Name,
                                       AnnounceUnicode = c.AnnounceUniqueCode,
                                       AddedPublishDate = c.AnnouncePublishDate.Value,

                                       ActivePhoto = c.BusinessEPhotos.Select(p => new ViewPhoto
                                       {
                                           Id = p.Id,
                                           Path = p.Path,
                                           AnnounceId = c.Id,

                                       }).FirstOrDefault(),
                                       Photos = c.BusinessEPhotos.Select(p => new ViewPhoto
                                       {
                                           Id = p.Id,
                                           Path = p.Path,
                                           AnnounceId = c.Id,

                                       }).ToList(),
                                   }).SingleOrDefaultAsync();
                                data.Add(announceBusiness);
                                break;
                            case "food":
                                var announceFood = await _dbContext.Foods
                                        .Where(c => c.Id == id)
                                        .Where(c => c.AnnounceCheckIn && c.AnnouncePublished)
                                        .Select(c => new ViewAnnounce(FindTable.Food)
                                        {
                                            Id = c.Id,
                                            Name = _setting.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                            Price = c.Price,
                                            City = c.City.Name,
                                            AnnounceUnicode = c.AnnounceUniqueCode,
                                            AddedPublishDate = c.AnnouncePublishDate.Value,

                                            ActivePhoto = c.FoodPhotos.Select(p => new ViewPhoto
                                            {
                                                Id = p.Id,
                                                Path = p.Path,
                                                AnnounceId = c.Id,

                                            }).FirstOrDefault(),
                                            Photos = c.FoodPhotos.Select(p => new ViewPhoto
                                            {
                                                Id = p.Id,
                                                Path = p.Path,
                                                AnnounceId = c.Id,

                                            }).ToList(),
                                        }).SingleOrDefaultAsync();
                                data.Add(announceFood);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return View(data.OrderByDescending(a => a.AddedPublishDate));
        }
        [HttpPost]
        public IActionResult Compair(SelectedAnnounce selected)
        {
            try
            {
                string compairAnnounces = HttpContext.Session.GetString("compair");
                string newCompair = compairAnnounces + "/{" + selected.AnnounceId + "," + selected.FindTable.ToString() + "}";
                HttpContext.Session.SetString("compair", newCompair);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return Json("success");
        }
        [HttpPost]
        public IActionResult CompairDelete(SelectedAnnounce selected)
        {
            try
            {
                string compairAnnounces = HttpContext.Session.GetString("compair");
                var compairs = compairAnnounces.Split('/');
                var editCompair = "";
                var removeCompair = "{" + selected.AnnounceId + "," + selected.FindTable.ToString() + "}";
                for (int i = 1; i < compairs.Length; i++)
                {

                    if (removeCompair != compairs[i])
                        editCompair += "/" + compairs[i];
                }
                HttpContext.Session.SetString("compair", editCompair);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return Json("success");
        }
        [HttpPost]
        public IActionResult Selected(SelectedAnnounce selected)
        {
            try
            {
                switch (selected.FindTable)
                {
                    case FindTable.Car:
                        string carCookieName = Request.Cookies["carId"];
                        Response.Cookies.Append("carId", carCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Bus:
                        string busCookieName = Request.Cookies["busId"];
                        Response.Cookies.Append("busId", busCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Accessory:
                        string accessoryCookieName = Request.Cookies["accessoryId"];
                        Response.Cookies.Append("accessoryId", accessoryCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Motocycle:
                        string motocycleCookieName = Request.Cookies["motocycleId"];
                        Response.Cookies.Append("motocycleId", motocycleCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Apartment:
                        string apartmentCookieName = Request.Cookies["apartmentId"];
                        Response.Cookies.Append("apartmentId", apartmentCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.House:
                        string houseCookieName = Request.Cookies["houseId"];
                        Response.Cookies.Append("houseId", houseCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Office:
                        string officeCookieName = Request.Cookies["officeId"];
                        Response.Cookies.Append("officeId", officeCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Garage:
                        string garageCookieName = Request.Cookies["garageId"];
                        Response.Cookies.Append("garageId", garageCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Land:
                        string landCookieName = Request.Cookies["landId"];
                        Response.Cookies.Append("landId", landCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Job:
                        string jobCookieName = Request.Cookies["jobId"];
                        Response.Cookies.Append("jobId", jobCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Business:
                        string businessCookieName = Request.Cookies["businessId"];
                        Response.Cookies.Append("businessId", businessCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    case FindTable.Food:
                        string foodCookieName = Request.Cookies["foodId"];
                        Response.Cookies.Append("foodId", foodCookieName + selected.AnnounceId.ToString() + ",");
                        break;
                    default:
                        break;
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> SelectedDelete(SelectedAnnounce selected)
        {
            try
            {
                switch (selected.FindTable)
                {
                    case FindTable.Car:
                        string carCookieName = Request.Cookies["carId"];
                        string newCookieName = "";
                        foreach (var item in carCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                newCookieName += item.Trim() + ",";
                            }
                        }

                        Response.Cookies.Append("carId", newCookieName);
                        break;
                    case FindTable.Bus:
                        string busCookieName = Request.Cookies["busId"];
                        string busnewCookieName = "";
                        foreach (var item in busCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                busnewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("busId", busCookieName);
                        break;
                    case FindTable.Accessory:
                        string accessoryCookieName = Request.Cookies["accessoryId"];
                        string accessorynewCookieName = "";
                        foreach (var item in accessoryCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                accessorynewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("accessoryId", accessorynewCookieName);
                        break;
                    case FindTable.Motocycle:
                        string motocycleCookieName = Request.Cookies["motocycleId"];
                        string motocyclenewCookieName = "";
                        foreach (var item in motocycleCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                motocyclenewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("motocycleId", motocyclenewCookieName);
                        break;
                    case FindTable.Apartment:
                        string apartmentCookieName = Request.Cookies["apartmentId"];
                        string apartmentnewCookieName = "";
                        foreach (var item in apartmentCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                apartmentnewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("apartmentId", apartmentnewCookieName);
                        break;
                    case FindTable.House:
                        string houseCookieName = Request.Cookies["houseId"];
                        string housenewCookieName = "";
                        foreach (var item in houseCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                housenewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("houseId", housenewCookieName);
                        break;
                    case FindTable.Office:
                        string officeCookieName = Request.Cookies["officeId"];
                        string officenewCookieName = "";
                        foreach (var item in officeCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                officenewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("officeId", officenewCookieName);
                        break;
                    case FindTable.Garage:
                        string garageCookieName = Request.Cookies["garageId"];
                        string garagenewCookieName = "";
                        foreach (var item in garageCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                garagenewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("garageId", garagenewCookieName);
                        break;
                    case FindTable.Land:
                        string landCookieName = Request.Cookies["landId"];
                        string landnewCookieName = "";
                        foreach (var item in landCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                landnewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("landId", landnewCookieName);
                        break;
                    case FindTable.Job:
                        string jobCookieName = Request.Cookies["jobId"];
                        string jobnewCookieName = "";
                        foreach (var item in jobCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                jobnewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("jobId", jobnewCookieName);
                        break;
                    case FindTable.Business:
                        string businessCookieName = Request.Cookies["businessId"];
                        string businessnewCookieName = "";
                        foreach (var item in businessCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                businessnewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("businessId", businessnewCookieName);
                        break;
                    case FindTable.Food:
                        string foodCookieName = Request.Cookies["foodId"];
                        string foodnewCookieName = "";
                        foreach (var item in foodCookieName.Split(','))
                        {
                            if (item.Trim() != selected.AnnounceId.ToString() && item.Trim() != "")
                            {
                                foodnewCookieName += item.Trim() + ",";
                            }
                        }
                        Response.Cookies.Append("foodId", foodnewCookieName);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return Json("success");
        }

        public async Task<IActionResult> Index(ViewPage viewPage)
        {
            ViewPage data = new ViewPage();
            try
            {
                HttpContext.Session.SetString("compair", "");
                viewPage.announceIds = Request.Cookies["carId"];
                viewPage.announceBusIds = Request.Cookies["busId"];
                viewPage.announceMotocycleIds = Request.Cookies["motocycleId"];
                viewPage.announceAccessoryIds = Request.Cookies["accessoryId"];
                viewPage.announceApartmentIds = Request.Cookies["apartmentId"];
                viewPage.announceHouseIds = Request.Cookies["houseId"];
                viewPage.announceOfficeIds = Request.Cookies["officeId"];
                viewPage.announceLandIds = Request.Cookies["landId"];
                viewPage.announceGarageIds = Request.Cookies["garageId"];
                viewPage.announceJobIds = Request.Cookies["jobId"];
                viewPage.announceBusinessIds = Request.Cookies["businessId"];
                viewPage.announceFoodIds = Request.Cookies["foodId"];
                data = new ViewPage
                {
                    ViewAnnouncesSimple = await _dataFind.CommonAnnounce(viewPage, "sade elan", 0, 7),
                    ViewAnnouncesVip = await _dataFind.CommonAnnounce(viewPage, "vip elan", 0, 7),
                    ViewAnnouncesPremium = await _dataFind.CommonAnnounce(viewPage, "premium elan", 0, 7)
                };
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Home controller Index action");
            }
            return View(data);
        }
        [Route("all/[controller]/type-home")]
        public async Task<IActionResult> TypeAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceIds = Request.Cookies["carId"];
            commonData.announceBusIds = Request.Cookies["busId"];
            commonData.announceMotocycleIds = Request.Cookies["motocycleId"];
            commonData.announceAccessoryIds = Request.Cookies["accessoryId"];
            commonData.announceApartmentIds = Request.Cookies["apartmentId"];
            commonData.announceHouseIds = Request.Cookies["houseId"];
            commonData.announceOfficeIds = Request.Cookies["officeId"];
            commonData.announceLandIds = Request.Cookies["landId"];
            commonData.announceGarageIds = Request.Cookies["garageId"];
            commonData.announceJobIds = Request.Cookies["jobId"];
            commonData.announceBusinessIds = Request.Cookies["businessId"];
            commonData.announceFoodIds = Request.Cookies["foodId"];

            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.CommonAnnounce(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.CommonAnnounce(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName = "home",
                        ActionName = "type-home"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {

                data = await _dataFind.CommonAnnounce(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.CommonAnnounce(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName = "home",
                        ActionName = "type-home"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.CommonAnnounce(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.CommonAnnounce(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName = "home",
                        ActionName = "type-home"
                    }
                };
            }

            return View(commonData);
        }
        //====================home end


        public async Task<bool> DeletePhotoAfter(List<string> photos, FindTable findTable)
        {
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
            return true;
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAnnounce(DeleteModalModel deleteModal)
        {

            if (ModelState.IsValid)
            {
            List<string> pathss = new List<string>();
                switch (deleteModal.FindTable)
                {
                    case FindTable.Car:
                        var car = await _dbContext.Cars.FindAsync(deleteModal.Id);

                        if (car != null && car.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.CarPhotos.Where(p => p.CarId == car.Id).ToList();
                            foreach (var item in paths)
                            {
                                    pathss.Add(item.Path);
                            }

                            _dbContext.Cars.Remove(car);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Car);
                            return Json("success");
                        }

                        break;
                    case FindTable.Bus:
                        var bus = await _dbContext.Buses.FindAsync(deleteModal.Id);

                        if (bus != null && bus.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.BusPhotos.Where(p => p.BusId == bus.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Buses.Remove(bus);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Bus);
                            return Json("success");
                        }
                        break;
                    case FindTable.Accessory:
                        var accessory = await _dbContext.Accessories.FindAsync(deleteModal.Id);

                        if (accessory != null && accessory.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.AccessoryPhotos.Where(p => p.AccessoryId == accessory.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Accessories.Remove(accessory);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Accessory);
                            return Json("success");
                        }
                        break;
                    case FindTable.Motocycle:
                        var motocycle = await _dbContext.Motocycles.FindAsync(deleteModal.Id);

                        if (motocycle != null && motocycle.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.MotocyclePhotos.Where(p => p.MotocycleId == motocycle.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Motocycles.Remove(motocycle);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Motocycle);
                            return Json("success");
                        }
                        break;
                    case FindTable.Apartment:
                        var apartment = await _dbContext.Apartments.FindAsync(deleteModal.Id);

                        if (apartment != null && apartment.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.ApartmentPhotos.Where(p => p.ApartmentId == apartment.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Apartments.Remove(apartment);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Apartment);
                            return Json("success");
                        }
                        break;
                    case FindTable.House:
                        var house = await _dbContext.Houses.FindAsync(deleteModal.Id);

                        if (house != null && house.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.HousePhotos.Where(p => p.HouseId == house.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Houses.Remove(house);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.House);
                            return Json("success");
                        }
                        break;
                    case FindTable.Office:
                        var office = await _dbContext.Offices.FindAsync(deleteModal.Id);

                        if (office != null && office.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.OfficePhotos.Where(p => p.OfficeId == office.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Offices.Remove(office);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Office);
                            return Json("success");
                        }
                        break;
                    case FindTable.Garage:
                        var garage = await _dbContext.Garages.FindAsync(deleteModal.Id);

                        if (garage != null && garage.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.GaragePhotos.Where(p => p.GarageId == garage.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Garages.Remove(garage);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Garage);
                            return Json("success");
                        }
                        break;
                    case FindTable.Land:
                        var land = await _dbContext.Lands.FindAsync(deleteModal.Id);

                        if (land != null && land.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.LandPhotos.Where(p => p.LandId == land.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Lands.Remove(land);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Land);
                            return Json("success");
                        }
                        break;
                    case FindTable.Job:
                        var job = await _dbContext.Jobs.FindAsync(deleteModal.Id);

                        if (job != null && job.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.JobPhotos.Where(p => p.JobId == job.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Jobs.Remove(job);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Job);
                            return Json("success");
                        }
                        break;
                    case FindTable.Business:
                        var business = await _dbContext.BusinessEquipments.FindAsync(deleteModal.Id);

                        if (business != null && business.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.BusinessEPhotos.Where(p => p.BusinessEquipmentId == business.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.BusinessEquipments.Remove(business);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Business);
                            return Json("success");
                        }
                        break;
                    case FindTable.Food:
                        var food = await _dbContext.Foods.FindAsync(deleteModal.Id);

                        if (food != null && food.AnnouncePinCode == deleteModal.AnnouncePinCode)
                        {
                            var paths = _dbContext.FoodPhotos.Where(p => p.FoodId == food.Id).ToList();
                            foreach (var item in paths)
                            {
                                pathss.Add(item.Path);
                            }
                            _dbContext.Foods.Remove(food);
                            await _dbContext.SaveChangesAsync();
                        await DeletePhotoAfter(pathss, FindTable.Food);
                            return Json("success");
                        }
                        break;
                    default:
                        break;
                }
            }

            return Json("fail");
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Comment contact)
        {

            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public async Task<IActionResult> Comment(Comment contact)
        {

            if (ModelState.IsValid)
            {

                bool added = await _addAnnounce.AddContact(contact);

                if (added)
                    return Json("success");

            }

            return Json("fail");
        }

        [Route("all/[controller]/user-agreement")]
        public async Task<IActionResult> UserAgreement()
        {
            return View();
        }

        [Route("all/[controller]/roles")]
        public async Task<IActionResult> Roles()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
