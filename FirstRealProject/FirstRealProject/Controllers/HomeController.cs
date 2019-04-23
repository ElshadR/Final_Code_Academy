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

        public HomeController(UserManager<AppUser> userMgr, IHostingEnvironment hostingEnvironment, FirstRealProjectDbContext dbContext, IAnnounceToAdd toAdd, IFindAnnounce dataFind, ISettingAnnounce setting)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
            _setting = setting;
            _userManager = userMgr;
            _addAnnounce = toAdd;
            _hostingEnvironment = hostingEnvironment;
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
                foreach (var item in carCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceCar);
                        }
                    }
                }
            }
            if (busCookie != null)
            {
                foreach (var item in busCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceBus);
                        }
                    }
                }
            }
            if (motocycleCookie != null)
            {
                foreach (var item in motocycleCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceMotocycle);
                        }
                    }
                }
            }
            if (accessoryCookie != null)
            {
                foreach (var item in accessoryCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceAccessory);
                        }
                    }
                }
            }
            if (apartmentCookie != null)
            {
                foreach (var item in apartmentCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceApartment);
                        }
                    }
                }
            }
            if (houseCookie != null)
            {
                foreach (var item in houseCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                          }).SingleOrDefaultAsync();
                            data.Add(announceHouse);
                        }
                    }
                }
            }
            if (officeCookie != null)
            {
                foreach (var item in officeCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceOffice);
                        }
                    }
                }
            }
            if (landCookie != null)
            {
                foreach (var item in landCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceLand);
                        }
                    }
                }
            }
            if (garageCookie != null)
            {
                foreach (var item in garageCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceGarage);
                        }
                    }
                }
            }
            if (jobCookie != null)
            {
                foreach (var item in jobCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceJob);
                        }
                    }
                }
            }
            if (businessCookie != null)
            {
                foreach (var item in businessCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                        }).SingleOrDefaultAsync();
                            data.Add(announceBusiness);
                        }
                    }
                }
            }
            if (foodCookie != null)
            {
                foreach (var item in foodCookie)
                {
                    int id = 0;
                    if (!String.IsNullOrEmpty(item))
                    {
                        if (Int32.TryParse(item, out id))
                        {
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
                                         }).SingleOrDefaultAsync();
                            data.Add(announceFood);
                        }
                    }
                }
            }

            return View(data);
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
            ViewPage data = new ViewPage
            {
                ViewAnnouncesSimple = await _dataFind.CommonAnnounce(viewPage, "sade elan", 0, 7),
                ViewAnnouncesVip = await _dataFind.CommonAnnounce(viewPage, "vip elan", 0, 7),
                ViewAnnouncesPremium = await _dataFind.CommonAnnounce(viewPage, "premium elan", 0, 7)
            };
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
