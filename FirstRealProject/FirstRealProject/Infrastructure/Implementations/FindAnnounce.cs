using FirstRealProject.Areas.Admin.Models;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Jobs;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport;
using FirstRealProject.Areas.Admin.Models.Enums;
using FirstRealProject.Areas.User.Models.ViewModels;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForFoodModels;
using FirstRealProject.Models.Jobs.ForJob;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using FirstRealProject.Models.PagesModels.ViewModel.Jobs.Businesses.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Jobs.Foods.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Jobs.Job.Item;
using FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Apartments.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Garages.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Houses.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Lands.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Offices.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Accessories.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Buses.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Cars.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Motocycles.Item;
using FirstRealProject.Models.Real_Estates.ApartmentModels;
using FirstRealProject.Models.Real_Estates.GarageModels;
using FirstRealProject.Models.Real_Estates.HouseModels;
using FirstRealProject.Models.Real_Estates.LandModels;
using FirstRealProject.Models.Real_Estates.OfficeModels;
using FirstRealProject.Models.Transports.AccessoryModels;
using FirstRealProject.Models.Transports.BusModels;
using FirstRealProject.Models.Transports.CarModels;
using FirstRealProject.Models.Transports.MotocycleModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Implementations
{
    public class FindAnnounce : IFindAnnounce
    {
        public FirstRealProjectDbContext _dbContext { get; set; }
        public ISettingAnnounce _settingAnnounce { get; set; }
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public FindAnnounce(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr, FirstRealProjectDbContext dbContext, ISettingAnnounce settingAnnounce)
        {
            _dbContext = dbContext;
            _settingAnnounce = settingAnnounce;
            _userManager = userMgr;
            _signInManager = signinMgr;
        }
        //common
        public async Task<IEnumerable<ViewAnnounce>> CommonAnnounce(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {
            List<ViewAnnounce> commomtData = new List<ViewAnnounce>();
            if (announceName.ToLower() == "last")
            {
                var carsData = await GetCars(viewPage, announceName);
                var carpData = await GetCars(viewPage, "premium elan");
                var bussData = await GetBuses(viewPage, announceName);
                var buspData = await GetBuses(viewPage, "premium elan");
                var motocyclesData = await GetMotocycles(viewPage, announceName);
                var motocyclepData = await GetMotocycles(viewPage, "premium elan");
                var accessorysData = await GetAccessories(viewPage, announceName);
                var accessorypData = await GetAccessories(viewPage, "premium elan");
                commomtData.AddRange(carsData);
                commomtData.AddRange(carpData);
                commomtData.AddRange(bussData);
                commomtData.AddRange(buspData);
                commomtData.AddRange(motocyclesData);
                commomtData.AddRange(motocyclepData);
                commomtData.AddRange(accessorysData);
                commomtData.AddRange(accessorypData);


                var apartmentData = await GetApartments(viewPage, announceName);
                var apartmentpData = await GetApartments(viewPage, "premium elan");
                var houseData = await GetHouses(viewPage, announceName);
                var housepData = await GetHouses(viewPage, "premium elan");
                var officeData = await GetOffices(viewPage, announceName);
                var officepData = await GetOffices(viewPage, "premium elan");
                var landData = await GetLands(viewPage, announceName);
                var landpData = await GetLands(viewPage, "premium elan");
                var garageData = await GetGarages(viewPage, announceName);
                var garagepData = await GetGarages(viewPage, "premium elan");
                commomtData.AddRange(apartmentData);
                commomtData.AddRange(apartmentpData);
                commomtData.AddRange(housepData);
                commomtData.AddRange(houseData);
                commomtData.AddRange(officepData);
                commomtData.AddRange(officeData);
                commomtData.AddRange(landData);
                commomtData.AddRange(landpData);
                commomtData.AddRange(garagepData);
                commomtData.AddRange(garageData);

                var jobData = await GetJobs(viewPage, announceName);
                var jobpData = await GetJobs(viewPage, "premium elan");
                var businessData = await GetBusinesses(viewPage, announceName);
                var businesspData = await GetBusinesses(viewPage, "premium elan");
                var foodData = await GetFoods(viewPage, announceName);
                var foodpData = await GetFoods(viewPage, "premium elan");
                commomtData.AddRange(jobData);
                commomtData.AddRange(jobpData);
                commomtData.AddRange(businesspData);
                commomtData.AddRange(businessData);
                commomtData.AddRange(foodpData);
                commomtData.AddRange(foodData);
            }
            else
            {
                var carData = await GetCars(viewPage, announceName);
                var busData = await GetBuses(viewPage, announceName);
                var motocycleData = await GetMotocycles(viewPage, announceName);
                var accessoryData = await GetAccessories(viewPage, announceName);
                commomtData.AddRange(carData);
                commomtData.AddRange(busData);
                commomtData.AddRange(motocycleData);
                commomtData.AddRange(accessoryData);
                var apartmentData = await GetApartments(viewPage, announceName);
                var houseData = await GetHouses(viewPage, announceName);
                var officeData = await GetOffices(viewPage, announceName);
                var landData = await GetLands(viewPage, announceName);
                var garageData = await GetGarages(viewPage, announceName);
                commomtData.AddRange(apartmentData);
                commomtData.AddRange(houseData);
                commomtData.AddRange(officeData);
                commomtData.AddRange(landData);
                commomtData.AddRange(garageData);

                var jobData = await GetJobs(viewPage, announceName);
                var businessData = await GetBusinesses(viewPage, announceName);
                var foodData = await GetFoods(viewPage, announceName);
                commomtData.AddRange(jobData);
                commomtData.AddRange(businessData);
                commomtData.AddRange(foodData);
                    
            }


            return commomtData.OrderByDescending(t => t.AddedPublishDate)
                    .Skip(startItem)
                    .Take(dataCount)
                    .ToList(); 
        }

        //transport
        public async Task<IEnumerable<ViewAnnounce>> GetTransports(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {
            List<ViewAnnounce> commomtData = new List<ViewAnnounce>();
            if (announceName.ToLower() == "last")
            {
                var carsData = await GetCars(viewPage, announceName);
                var carpData = await GetCars(viewPage, "premium elan");
                var bussData = await GetBuses(viewPage, announceName);
                var buspData = await GetBuses(viewPage, "premium elan");
                var motocyclesData = await GetMotocycles(viewPage, announceName);
                var motocyclepData = await GetMotocycles(viewPage, "premium elan");
                var accessorysData = await GetAccessories(viewPage, announceName);
                var accessorypData = await GetAccessories(viewPage, "premium elan");
                commomtData.AddRange(carsData);
                commomtData.AddRange(carpData);
                commomtData.AddRange(bussData);
                commomtData.AddRange(buspData);
                commomtData.AddRange(motocyclesData);
                commomtData.AddRange(motocyclepData);
                commomtData.AddRange(accessorysData);
                commomtData.AddRange(accessorypData);
                commomtData = commomtData
                    .OrderByDescending(t => t.AddedPublishDate)
                    .Skip(startItem)
                    .Take(dataCount)
                    .ToList();
            }
            else
            {
                var carData = await GetCars(viewPage, announceName);
                var busData = await GetBuses(viewPage, announceName);
                var motocycleData = await GetMotocycles(viewPage, announceName);
                var accessoryData = await GetAccessories(viewPage, announceName);
                commomtData.AddRange(carData);
                commomtData.AddRange(busData);
                commomtData.AddRange(motocycleData);
                commomtData.AddRange(accessoryData);
                commomtData = commomtData
                    .OrderByDescending(t => t.AddedPublishDate)
                    .Skip(startItem)
                    .Take(dataCount)
                    .ToList();
            }
            

            return commomtData;
        }

        public Task<CarView> GetTransport(int id, string unicode)
        {
            throw new NotImplementedException();
        }
        // car find data start
        public async Task<IEnumerable<ViewAnnounce>> GetCars(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            var t = await _dbContext.Cars.ToListAsync();
            List<ViewAnnounce> data = new List<ViewAnnounce>();

            var k = await _dbContext.Cars.OrderByDescending(x=>x.AnnouncePublishDate).ToListAsync();
            var a = await _dbContext.Cars.Where(x=>x.AnnounceType.Name.ToLower()=="premium elan").ToListAsync();
            var b = await _dbContext.Cars.Where(x=>x.AnnounceType.Name.ToLower()=="vip elan").Skip(0).Take(16).ToListAsync();
            var s = await _dbContext.Cars.Where(x=>x.AnnounceType.Name.ToLower()=="vip elan").Skip(16).Take(16).ToListAsync();
            var q = await _dbContext.Cars.Where(x=>x.AnnounceType.Name.ToLower()== "sade elan").ToListAsync();

            if (announceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int sYear;
                    int bYear;
                    if (viewPage.SYear == null || viewPage.SYear == 0)
                        sYear = 0;
                    else
                        sYear = viewPage.SYear.Value;
                    if (viewPage.BYear == null || viewPage.BYear == 0)
                        bYear = 0;
                    else
                        bYear = viewPage.BYear.Value;

                    int sKilometer;
                    int bKilometer;
                    if (viewPage.SKilometer == null || viewPage.SKilometer == 0)
                        sKilometer = 0;
                    else
                        sKilometer = viewPage.SKilometer.Value;
                    if (viewPage.BKilometer == null || viewPage.BKilometer == 0)
                        bKilometer = 0;
                    else
                        bKilometer = viewPage.BKilometer.Value;

                    int sMotor;
                    int bMotor;
                    if (viewPage.SMotor == null || viewPage.SMotor == 0)
                        sMotor = 0;
                    else
                        sMotor = viewPage.SMotor.Value;
                    if (viewPage.BMotor == null || viewPage.BMotor == 0)
                        bMotor = 0;
                    else
                        bMotor = viewPage.BMotor.Value;

                    int modelId;
                    if (viewPage.CarModelId == null || viewPage.CarModelId == 0)
                        modelId = 0;
                    else
                        modelId = viewPage.CarModelId.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;

                    var datas = await _dbContext.Cars
                                             .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                             //search conditionBarter
                                             .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                             //search conditionCredit
                                             .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                             //search name
                                             .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                             //search city
                                             .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                             ////search model
                                             .Where(c => modelId == 0 ? true : c.CarModelId == modelId)
                                             //search price
                                             .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                             //search year
                                             .Where(c => bYear == 0 ? sYear == 0 ? true : (c.CarYear >= sYear) : (c.CarYear <= bYear && c.CarYear >= sYear))
                                             //search kilometer
                                             .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.CarKilometer >= sKilometer) : (c.CarKilometer <= bKilometer && c.CarKilometer >= sKilometer))
                                             //search motor
                                             .Where(c => bMotor == 0 ? sMotor == 0 ? true : (c.CarMotor >= sMotor) : (c.CarMotor <= bMotor && c.CarMotor >= sMotor))
                                             .OrderByDescending(x => x.AnnouncePublishDate)
                                             .Skip(startItem)
                                             .Take(dataCount)
                                             .Select(c => new ViewAnnounce(FindTable.Car)
                                             {
                                                 Id = c.Id,
                                                 Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                                 Price = c.Price,
                                                 City = c.City.Name,
                                                 AnnounceUnicode = c.AnnounceUniqueCode,
                                                 AddedPublishDate = c.AnnouncePublishDate.Value,
                                                 SelectedAnnounce = SelectedAnnounce(viewPage.announceIds, c.Id, FindTable.Car),
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
                    var datap = await _dbContext.Cars
                                             .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                             //search conditionBarter
                                             .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                             //search conditionCredit
                                             .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                             //search name
                                             .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                             //search city
                                             .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                             ////search model
                                             .Where(c => modelId == 0 ? true : c.CarModelId == modelId)
                                             //search price
                                             .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                             //search year
                                             .Where(c => bYear == 0 ? sYear == 0 ? true : (c.CarYear >= sYear) : (c.CarYear <= bYear && c.CarYear >= sYear))
                                             //search kilometer
                                             .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.CarKilometer >= sKilometer) : (c.CarKilometer <= bKilometer && c.CarKilometer >= sKilometer))
                                             //search motor
                                             .Where(c => bMotor == 0 ? sMotor == 0 ? true : (c.CarMotor >= sMotor) : (c.CarMotor <= bMotor && c.CarMotor >= sMotor))
                                             .OrderByDescending(x => x.AnnouncePublishDate)
                                             .Skip(startItem)
                                             .Take(dataCount)
                                             .Select(c => new ViewAnnounce(FindTable.Car)
                                             {
                                                 Id = c.Id,
                                                 Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                                 Price = c.Price,
                                                 City = c.City.Name,
                                                 AnnounceUnicode = c.AnnounceUniqueCode,
                                                 AddedPublishDate = c.AnnouncePublishDate.Value,
                                                 SelectedAnnounce = SelectedAnnounce(viewPage.announceIds, c.Id, FindTable.Car),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                    
                }
                else
                {
                   var datas = await _dbContext.Cars
                                             .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                            .OrderByDescending(x => x.AnnouncePublishDate)
                                             .Skip(startItem)
                                            .Take(dataCount)
                                            .Select(c => new ViewAnnounce(FindTable.Car)
                                            {
                                                Id = c.Id,
                                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                                Price = c.Price,
                                                City = c.City.Name,
                                                AnnounceUnicode = c.AnnounceUniqueCode,
                                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                                SelectedAnnounce = SelectedAnnounce(viewPage.announceIds, c.Id, FindTable.Car),
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
                    var datap = await _dbContext.Cars
                                             .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                            .OrderByDescending(x => x.AnnouncePublishDate)
                                             .Skip(startItem)
                                            .Take(dataCount)
                                            .Select(c => new ViewAnnounce(FindTable.Car)
                                            {
                                                Id = c.Id,
                                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                                Price = c.Price,
                                                City = c.City.Name,
                                                AnnounceUnicode = c.AnnounceUniqueCode,
                                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                                SelectedAnnounce = SelectedAnnounce(viewPage.announceIds, c.Id, FindTable.Car),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int sYear;
                    int bYear;
                    if (viewPage.SYear == null || viewPage.SYear == 0)
                        sYear = 0;
                    else
                        sYear = viewPage.SYear.Value;
                    if (viewPage.BYear == null || viewPage.BYear == 0)
                        bYear = 0;
                    else
                        bYear = viewPage.BYear.Value;

                    int sKilometer;
                    int bKilometer;
                    if (viewPage.SKilometer == null || viewPage.SKilometer == 0)
                        sKilometer = 0;
                    else
                        sKilometer = viewPage.SKilometer.Value;
                    if (viewPage.BKilometer == null || viewPage.BKilometer == 0)
                        bKilometer = 0;
                    else
                        bKilometer = viewPage.BKilometer.Value;

                    int sMotor;
                    int bMotor;
                    if (viewPage.SMotor == null || viewPage.SMotor == 0)
                        sMotor = 0;
                    else
                        sMotor = viewPage.SMotor.Value;
                    if (viewPage.BMotor == null || viewPage.BMotor == 0)
                        bMotor = 0;
                    else
                        bMotor = viewPage.BMotor.Value;

                    int modelId;
                    if (viewPage.CarModelId == null || viewPage.CarModelId == 0)
                        modelId = 0;
                    else
                        modelId = viewPage.CarModelId.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;

                     data = await _dbContext.Cars
                                             .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                             //search conditionBarter
                                             .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                             //search conditionCredit
                                             .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                             //search name
                                             .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                             //search city
                                             .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                             ////search model
                                             .Where(c => modelId == 0 ? true : c.CarModelId == modelId)
                                             //search price
                                             .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                             //search year
                                             .Where(c => bYear == 0 ? sYear == 0 ? true : (c.CarYear >= sYear) : (c.CarYear <= bYear && c.CarYear >= sYear))
                                             //search kilometer
                                             .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.CarKilometer >= sKilometer) : (c.CarKilometer <= bKilometer && c.CarKilometer >= sKilometer))
                                             //search motor
                                             .Where(c => bMotor == 0 ? sMotor == 0 ? true : (c.CarMotor >= sMotor) : (c.CarMotor <= bMotor && c.CarMotor >= sMotor))
                                             .OrderByDescending(x => x.AnnouncePublishDate)
                                             .Skip(startItem)
                                             .Take(dataCount)

                                             .Select(c => new ViewAnnounce(FindTable.Car)
                                             {
                                                 Id = c.Id,
                                                 Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                                 Price = c.Price,
                                                 City = c.City.Name,
                                                 AnnounceUnicode = c.AnnounceUniqueCode,
                                                 AddedPublishDate = c.AnnouncePublishDate.Value,
                                                 SelectedAnnounce = SelectedAnnounce(viewPage.announceIds, c.Id, FindTable.Car),
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
                else
                {
                    data = await _dbContext.Cars
                                             .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())
                                            .OrderByDescending(x => x.AnnouncePublishDate)
                                             .Skip(startItem)
                                            .Take(dataCount)
                                            .Select(c => new ViewAnnounce(FindTable.Car)
                                            {
                                                Id = c.Id,
                                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                                Price = c.Price,
                                                City = c.City.Name,
                                                AnnounceUnicode = c.AnnounceUniqueCode,
                                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                                SelectedAnnounce = SelectedAnnounce(viewPage.announceIds, c.Id, FindTable.Car),
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
            }

            return data.OrderByDescending(x=>x.AddedPublishDate);
        }

        public async Task<CarView> GetCar(int id, string unicode, bool view = true)
        {
            CarView car = await _dbContext
           .Cars
           .Where(c => c.Id == id && c.AnnouncePublished)
           .Select(c => new CarView
           {
               Id = c.Id,
               AnounceName = c.AnnounceName,
               AnnounceAddedDate = c.AnnounceAddedDate,
               AnnouncePinCode = c.AnnouncePinCode,
               AnnouncePublishDate = c.AnnouncePublishDate.Value,
               AnnounceType = c.AnnounceType,
               AnnounceUniqueCode = c.AnnounceUniqueCode,
               AnnounceViewCount = c.AnnounceViewCount,
               Condition = c.Condition,
               ConditionBarter = c.ConditionBarter,
               ConditionCredit = c.ConditionCredit,
               Description = c.Description,
               Email = c.Email,
               Kilometer = c.CarKilometer,
               MakeName = c.CarModel.CarMake.Name,
               ModelName = c.CarModel.Name,
               Motor = c.CarMotor,
               PhoneNumber = c.PhoneNumber,
               Price = c.Price,
               Year = c.CarYear,
               PersonType = c.PersonType,
               Photos = c.CarPhotos.ToList(),
               City = c.City,
               CarBodyType = c.CarBodyType,
               CarMotorStrength = c.CarMotorStrength,
               SpeedBox = c.SpeedBox,
               Transmission = c.Transmission,
               Color = c.Color,
               FuelType = c.FuelType,
               FindTable=FindTable.Car,

           })
           .SingleOrDefaultAsync();
            if (view)
            {
                Car viewCar = await _dbContext.Cars.FindAsync(id);
                viewCar.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            var autoEquipments = await _dbContext.CarAutoEquipments.Include(x => x.AutoEquipment).Where(c => c.CarId == car.Id).Select(x => new AutoEquipment
            {
                Id = x.AutoEquipment.Id,
                Name = x.AutoEquipment.Name
            }).ToListAsync();
            car.AutoEquipment = autoEquipments;
            return car;

        }
        // car find data end


        // bus find data start
        public async Task<IEnumerable<ViewAnnounce>> GetBuses(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();

            if (announceName == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int sYear;
                    int bYear;
                    if (viewPage.SYear == null || viewPage.SYear == 0)
                        sYear = 0;
                    else
                        sYear = viewPage.SYear.Value;
                    if (viewPage.BYear == null || viewPage.BYear == 0)
                        bYear = 0;
                    else
                        bYear = viewPage.BYear.Value;

                    int sKilometer;
                    int bKilometer;
                    if (viewPage.SKilometer == null || viewPage.SKilometer == 0)
                        sKilometer = 0;
                    else
                        sKilometer = viewPage.SKilometer.Value;
                    if (viewPage.BKilometer == null || viewPage.BKilometer == 0)
                        bKilometer = 0;
                    else
                        bKilometer = viewPage.BKilometer.Value;

                    int sMotor;
                    int bMotor;
                    if (viewPage.SMotor == null || viewPage.SMotor == 0)
                        sMotor = 0;
                    else
                        sMotor = viewPage.SMotor.Value;
                    if (viewPage.BMotor == null || viewPage.BMotor == 0)
                        bMotor = 0;
                    else
                        bMotor = viewPage.BMotor.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int bodyTypeId;
                    if (viewPage.BusBodyTypeId == null || viewPage.BusBodyTypeId == 0)
                        bodyTypeId = 0;
                    else
                        bodyTypeId = viewPage.BusBodyTypeId.Value;
                    int makeId;
                    if (viewPage.MakeId == null || viewPage.MakeId == 0)
                        makeId = 0;
                    else
                        makeId = viewPage.MakeId.Value;
                    var datas = await _dbContext.Buses
                                                .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                                //search conditionBarter
                                                .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                                //search conditionCredit
                                                .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search bodyType
                                                .Where(c => makeId == 0 ? true : c.BusMakeId == makeId)
                                                //search city
                                                .Where(c => bodyTypeId == 0 ? true : c.BusBodyTypeId == bodyTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search year
                                                .Where(c => bYear == 0 ? sYear == 0 ? true : (c.BusYear >= sYear) : (c.BusYear <= bYear && c.BusYear >= sYear))
                                                //search kilometer
                                                .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.BusKilometer >= sKilometer) : (c.BusKilometer <= bKilometer && c.BusKilometer >= sKilometer))
                                             //search motor
                                             .OrderByDescending(c => c.AnnouncePublishDate)
                                                .Skip(startItem)
                                                .Take(dataCount)
                                                .Select(c => new ViewAnnounce(FindTable.Bus)
                                                {
                                                    Id = c.Id,
                                                    Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                                    Price = c.Price,
                                                    City = c.City.Name,
                                                    AnnounceUnicode = c.AnnounceUniqueCode,
                                                    AddedPublishDate = c.AnnouncePublishDate.Value,
                                                    SelectedAnnounce = SelectedAnnounce(viewPage.announceBusIds, c.Id, FindTable.Bus),
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
                    var datap = await _dbContext.Buses
                                                .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                                //search conditionBarter
                                                .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                                //search conditionCredit
                                                .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search bodyType
                                                .Where(c => makeId == 0 ? true : c.BusMakeId == makeId)
                                                //search city
                                                .Where(c => bodyTypeId == 0 ? true : c.BusBodyTypeId == bodyTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search year
                                                .Where(c => bYear == 0 ? sYear == 0 ? true : (c.BusYear >= sYear) : (c.BusYear <= bYear && c.BusYear >= sYear))
                                                //search kilometer
                                                .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.BusKilometer >= sKilometer) : (c.BusKilometer <= bKilometer && c.BusKilometer >= sKilometer))
                                             //search motor
                                             .OrderByDescending(c => c.AnnouncePublishDate)
                                                .Skip(startItem)
                                                .Take(dataCount)
                                                .Select(c => new ViewAnnounce(FindTable.Bus)
                                                {
                                                    Id = c.Id,
                                                    Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                                    Price = c.Price,
                                                    City = c.City.Name,
                                                    AnnounceUnicode = c.AnnounceUniqueCode,
                                                    AddedPublishDate = c.AnnouncePublishDate.Value,
                                                    SelectedAnnounce = SelectedAnnounce(viewPage.announceBusIds, c.Id, FindTable.Bus),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                      var datas = await _dbContext.Buses
                                                .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .Skip(startItem)
                                                .Take(dataCount)
                                                .Select(c => new ViewAnnounce(FindTable.Bus)
                                                {
                                                    Id = c.Id,
                                                    Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                                    Price = c.Price,
                                                    City = c.City.Name,
                                                    AnnounceUnicode = c.AnnounceUniqueCode,
                                                    AddedPublishDate = c.AnnouncePublishDate.Value,
                                                    SelectedAnnounce = SelectedAnnounce(viewPage.announceBusIds, c.Id, FindTable.Bus),
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
                    var datap = await _dbContext.Buses
                                                .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .Skip(startItem)
                                                .Take(dataCount)
                                                .Select(c => new ViewAnnounce(FindTable.Bus)
                                                {
                                                    Id = c.Id,
                                                    Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                                    Price = c.Price,
                                                    City = c.City.Name,
                                                    AnnounceUnicode = c.AnnounceUniqueCode,
                                                    AddedPublishDate = c.AnnouncePublishDate.Value,
                                                    SelectedAnnounce = SelectedAnnounce(viewPage.announceBusIds, c.Id, FindTable.Bus),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int sYear;
                    int bYear;
                    if (viewPage.SYear == null || viewPage.SYear == 0)
                        sYear = 0;
                    else
                        sYear = viewPage.SYear.Value;
                    if (viewPage.BYear == null || viewPage.BYear == 0)
                        bYear = 0;
                    else
                        bYear = viewPage.BYear.Value;

                    int sKilometer;
                    int bKilometer;
                    if (viewPage.SKilometer == null || viewPage.SKilometer == 0)
                        sKilometer = 0;
                    else
                        sKilometer = viewPage.SKilometer.Value;
                    if (viewPage.BKilometer == null || viewPage.BKilometer == 0)
                        bKilometer = 0;
                    else
                        bKilometer = viewPage.BKilometer.Value;

                    int sMotor;
                    int bMotor;
                    if (viewPage.SMotor == null || viewPage.SMotor == 0)
                        sMotor = 0;
                    else
                        sMotor = viewPage.SMotor.Value;
                    if (viewPage.BMotor == null || viewPage.BMotor == 0)
                        bMotor = 0;
                    else
                        bMotor = viewPage.BMotor.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int bodyTypeId;
                    if (viewPage.BusBodyTypeId == null || viewPage.BusBodyTypeId == 0)
                        bodyTypeId = 0;
                    else
                        bodyTypeId = viewPage.BusBodyTypeId.Value;
                    int makeId;
                    if (viewPage.MakeId == null || viewPage.MakeId == 0)
                        makeId = 0;
                    else
                        makeId = viewPage.MakeId.Value;
                    data = await _dbContext.Buses
                                                .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                                //search conditionBarter
                                                .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                                //search conditionCredit
                                                .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search bodyType
                                                .Where(c => makeId == 0 ? true : c.BusMakeId == makeId)
                                                //search city
                                                .Where(c => bodyTypeId == 0 ? true : c.BusBodyTypeId == bodyTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search year
                                                .Where(c => bYear == 0 ? sYear == 0 ? true : (c.BusYear >= sYear) : (c.BusYear <= bYear && c.BusYear >= sYear))
                                                //search kilometer
                                                .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.BusKilometer >= sKilometer) : (c.BusKilometer <= bKilometer && c.BusKilometer >= sKilometer))
                                             //search motor
                                             .OrderByDescending(c => c.AnnouncePublishDate)
                                                .Skip(startItem)
                                                .Take(dataCount)
                                                .Select(c => new ViewAnnounce(FindTable.Bus)
                                                {
                                                    Id = c.Id,
                                                    Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                                    Price = c.Price,
                                                    City = c.City.Name,
                                                    AnnounceUnicode = c.AnnounceUniqueCode,
                                                    AddedPublishDate = c.AnnouncePublishDate.Value,
                                                    SelectedAnnounce = SelectedAnnounce(viewPage.announceBusIds, c.Id, FindTable.Bus),
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
                else
                {
                    data = await _dbContext.Buses
                                                .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())
                                             .OrderByDescending(c => c.AnnouncePublishDate)
                                                .Skip(startItem)
                                                .Take(dataCount)
                                                .Select(c => new ViewAnnounce(FindTable.Bus)
                                                {
                                                    Id = c.Id,
                                                    Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                                    Price = c.Price,
                                                    City = c.City.Name,
                                                    AnnounceUnicode = c.AnnounceUniqueCode,
                                                    AddedPublishDate = c.AnnouncePublishDate.Value,
                                                    SelectedAnnounce = SelectedAnnounce(viewPage.announceBusIds, c.Id, FindTable.Bus),
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
            }
            return data;
        }

        public async Task<BusViewItem> GetBus(int id, string unicode, bool view = true)
        {
            BusViewItem bus = await _dbContext
                   .Buses
                   .Where(b => b.Id == id && b.AnnouncePublished)
                   .Select(b => new BusViewItem
                   {
                       Id = b.Id,
                       AnounceName = b.AnnounceName,
                       AnnounceAddedDate = b.AnnounceAddedDate,
                       AnnouncePinCode = b.AnnouncePinCode,
                       AnnouncePublishDate = b.AnnouncePublishDate.Value,
                       AnnounceType = b.AnnounceType,
                       AnnounceUniqueCode = b.AnnounceUniqueCode,
                       AnnounceViewCount = b.AnnounceViewCount,
                       Condition = b.Condition,
                       ConditionBarter = b.ConditionBarter,
                       ConditionCredit = b.ConditionCredit,
                       Description = b.Description,
                       Email = b.Email,
                       PhoneNumber = b.PhoneNumber,
                       Price = b.Price,
                       Year = b.BusYear,
                       PersonType = b.PersonType,
                       Photos = b.BusPhotos.ToList(),
                       City = b.City,
                       BodyType = b.BusBodyType,
                       BusKilometer = b.BusKilometer,
                       Make = b.BusMake,
               FindTable=FindTable.Bus,
                   })
                   .FirstOrDefaultAsync();
            if (view)
            {
                Bus viewA = await _dbContext.Buses.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return bus;
        }
        // car find data end

        // motocycle find data start
        public async Task<IEnumerable<ViewAnnounce>> GetMotocycles(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();

            if (announceName.ToLower() == "last")
            {
                if (viewPage != null)
                {

                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int sYear;
                    int bYear;
                    if (viewPage.SYear == null || viewPage.SYear == 0)
                        sYear = 0;
                    else
                        sYear = viewPage.SYear.Value;
                    if (viewPage.BYear == null || viewPage.BYear == 0)
                        bYear = 0;
                    else
                        bYear = viewPage.BYear.Value;

                    int sKilometer;
                    int bKilometer;
                    if (viewPage.SKilometer == null || viewPage.SKilometer == 0)
                        sKilometer = 0;
                    else
                        sKilometer = viewPage.SKilometer.Value;
                    if (viewPage.BKilometer == null || viewPage.BKilometer == 0)
                        bKilometer = 0;
                    else
                        bKilometer = viewPage.BKilometer.Value;

                    int sMotor;
                    int bMotor;
                    if (viewPage.SMotor == null || viewPage.SMotor == 0)
                        sMotor = 0;
                    else
                        sMotor = viewPage.SMotor.Value;
                    if (viewPage.BMotor == null || viewPage.BMotor == 0)
                        bMotor = 0;
                    else
                        bMotor = viewPage.BMotor.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;

                    int bodyTypeId;
                    if (viewPage.MotocycleBodyTypeId == null || viewPage.MotocycleBodyTypeId == 0)
                        bodyTypeId = 0;
                    else
                        bodyTypeId = viewPage.BusBodyTypeId.Value;
                    int makeId;
                    if (viewPage.MotocycleMakeId == null || viewPage.MotocycleMakeId == 0)
                        makeId = 0;
                    else
                        makeId = viewPage.MotocycleMakeId.Value;
                    var datas = await _dbContext.Motocycles
                                              .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                               //search conditionBarter
                                               .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                               //search conditionCredit
                                               .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                               //search name
                                               .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                               //search city
                                               .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                               //search city
                                               .Where(c => bodyTypeId == 0 ? true : c.MotocycleBodyTypeId == bodyTypeId)
                                               //search price
                                               .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               //search year
                                               .Where(c => bYear == 0 ? sYear == 0 ? true : (c.MotocycleYear >= sYear) : (c.MotocycleYear <= bYear && c.MotocycleYear >= sYear))
                                               //search kilometer
                                               .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.MotocycleKilometer >= sKilometer) : (c.MotocycleKilometer <= bKilometer && c.MotocycleKilometer >= sKilometer))
                                                //search motor
                                                .Where(c => bMotor == 0 ? sMotor == 0 ? true : (c.MotocycleMotor >= sMotor) : (c.MotocycleMotor <= bMotor && c.MotocycleMotor >= sMotor))
                                              .OrderByDescending(c => c.AnnouncePublishDate)
                                              .Skip(startItem)
                                              .Take(dataCount)
                                              .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                              {
                                                  Id = c.Id,
                                                  Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                                  Price = c.Price,
                                                  City = c.City.Name,
                                                  AnnounceUnicode = c.AnnounceUniqueCode,
                                                  AddedPublishDate = c.AnnouncePublishDate.Value,
                                                  SelectedAnnounce = SelectedAnnounce(viewPage.announceMotocycleIds, c.Id, FindTable.Motocycle),
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
                    var datap = await _dbContext.Motocycles
                                              .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                               //search conditionBarter
                                               .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                               //search conditionCredit
                                               .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                               //search name
                                               .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                               //search city
                                               .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                               //search city
                                               .Where(c => bodyTypeId == 0 ? true : c.MotocycleBodyTypeId == bodyTypeId)
                                               //search price
                                               .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               //search year
                                               .Where(c => bYear == 0 ? sYear == 0 ? true : (c.MotocycleYear >= sYear) : (c.MotocycleYear <= bYear && c.MotocycleYear >= sYear))
                                               //search kilometer
                                               .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.MotocycleKilometer >= sKilometer) : (c.MotocycleKilometer <= bKilometer && c.MotocycleKilometer >= sKilometer))
                                                //search motor
                                                .Where(c => bMotor == 0 ? sMotor == 0 ? true : (c.MotocycleMotor >= sMotor) : (c.MotocycleMotor <= bMotor && c.MotocycleMotor >= sMotor))
                                              .OrderByDescending(c => c.AnnouncePublishDate)
                                              .Skip(startItem)
                                              .Take(dataCount)
                                              .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                              {
                                                  Id = c.Id,
                                                  Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                                  Price = c.Price,
                                                  City = c.City.Name,
                                                  AnnounceUnicode = c.AnnounceUniqueCode,
                                                  AddedPublishDate = c.AnnouncePublishDate.Value,
                                                  SelectedAnnounce = SelectedAnnounce(viewPage.announceMotocycleIds, c.Id, FindTable.Motocycle),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Motocycles
                                              .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                              .OrderByDescending(c => c.AnnouncePublishDate)
                                              .Skip(startItem)
                                              .Take(dataCount)
                                              .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                              {
                                                  Id = c.Id,
                                                  Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                                  Price = c.Price,
                                                  City = c.City.Name,
                                                  AnnounceUnicode = c.AnnounceUniqueCode,
                                                  AddedPublishDate = c.AnnouncePublishDate.Value,
                                                  SelectedAnnounce = SelectedAnnounce(viewPage.announceMotocycleIds, c.Id, FindTable.Motocycle),
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
                    var datap = await _dbContext.Motocycles
                                              .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                              .OrderByDescending(c => c.AnnouncePublishDate)
                                              .Skip(startItem)
                                              .Take(dataCount)
                                              .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                              {
                                                  Id = c.Id,
                                                  Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                                  Price = c.Price,
                                                  City = c.City.Name,
                                                  AnnounceUnicode = c.AnnounceUniqueCode,
                                                  AddedPublishDate = c.AnnouncePublishDate.Value,
                                                  SelectedAnnounce = SelectedAnnounce(viewPage.announceMotocycleIds, c.Id, FindTable.Motocycle),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {

                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int sYear;
                    int bYear;
                    if (viewPage.SYear == null || viewPage.SYear == 0)
                        sYear = 0;
                    else
                        sYear = viewPage.SYear.Value;
                    if (viewPage.BYear == null || viewPage.BYear == 0)
                        bYear = 0;
                    else
                        bYear = viewPage.BYear.Value;

                    int sKilometer;
                    int bKilometer;
                    if (viewPage.SKilometer == null || viewPage.SKilometer == 0)
                        sKilometer = 0;
                    else
                        sKilometer = viewPage.SKilometer.Value;
                    if (viewPage.BKilometer == null || viewPage.BKilometer == 0)
                        bKilometer = 0;
                    else
                        bKilometer = viewPage.BKilometer.Value;

                    int sMotor;
                    int bMotor;
                    if (viewPage.SMotor == null || viewPage.SMotor == 0)
                        sMotor = 0;
                    else
                        sMotor = viewPage.SMotor.Value;
                    if (viewPage.BMotor == null || viewPage.BMotor == 0)
                        bMotor = 0;
                    else
                        bMotor = viewPage.BMotor.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;

                    int bodyTypeId;
                    if (viewPage.MotocycleBodyTypeId == null || viewPage.MotocycleBodyTypeId == 0)
                        bodyTypeId = 0;
                    else
                        bodyTypeId = viewPage.BusBodyTypeId.Value;
                    int makeId;
                    if (viewPage.MotocycleMakeId == null || viewPage.MotocycleMakeId == 0)
                        makeId = 0;
                    else
                        makeId = viewPage.MotocycleMakeId.Value;
                    data = await _dbContext.Motocycles
                                              .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())
                                             //search condition
                                             .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                               //search conditionBarter
                                               .Where(c => viewPage.ConditionBarter == false ? true : viewPage.ConditionBarter == c.ConditionBarter)
                                               //search conditionCredit
                                               .Where(c => viewPage.ConditionCredit == false ? true : viewPage.ConditionCredit == c.ConditionCredit)
                                               //search name
                                               .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                               //search city
                                               .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                               //search city
                                               .Where(c => bodyTypeId == 0 ? true : c.MotocycleBodyTypeId == bodyTypeId)
                                               //search price
                                               .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               //search year
                                               .Where(c => bYear == 0 ? sYear == 0 ? true : (c.MotocycleYear >= sYear) : (c.MotocycleYear <= bYear && c.MotocycleYear >= sYear))
                                               //search kilometer
                                               .Where(c => bKilometer == 0 ? sKilometer == 0 ? true : (c.MotocycleKilometer >= sKilometer) : (c.MotocycleKilometer <= bKilometer && c.MotocycleKilometer >= sKilometer))
                                                //search motor
                                                .Where(c => bMotor == 0 ? sMotor == 0 ? true : (c.MotocycleMotor >= sMotor) : (c.MotocycleMotor <= bMotor && c.MotocycleMotor >= sMotor))
                                              .OrderByDescending(c => c.AnnouncePublishDate)
                                              .Skip(startItem)
                                              .Take(dataCount)
                                              .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                              {
                                                  Id = c.Id,
                                                  Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                                  Price = c.Price,
                                                  City = c.City.Name,
                                                  AnnounceUnicode = c.AnnounceUniqueCode,
                                                  AddedPublishDate = c.AnnouncePublishDate.Value,
                                                  SelectedAnnounce = SelectedAnnounce(viewPage.announceMotocycleIds, c.Id, FindTable.Motocycle),
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
                else
                {
                    data = await _dbContext.Motocycles
                                              .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())
                                              .OrderByDescending(c => c.AnnouncePublishDate)
                                              .Skip(startItem)
                                              .Take(dataCount)
                                              .Select(c => new ViewAnnounce(FindTable.Motocycle)
                                              {
                                                  Id = c.Id,
                                                  Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                                  Price = c.Price,
                                                  City = c.City.Name,
                                                  AnnounceUnicode = c.AnnounceUniqueCode,
                                                  AddedPublishDate = c.AnnouncePublishDate.Value,
                                                  SelectedAnnounce = SelectedAnnounce(viewPage.announceMotocycleIds, c.Id, FindTable.Motocycle),
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
            }
            return data;
        }

        public async Task<MotocycleViewItem> GetMotocycle(int id, string unicode, bool view = true)
        {
            MotocycleViewItem motocycle = await _dbContext
               .Motocycles
               .Where(m => m.Id == id && m.AnnouncePublished)

               .Select(m => new MotocycleViewItem
               {
                   Id = m.Id,
                   AnounceName = m.AnnounceName,
                   AnnounceAddedDate = m.AnnounceAddedDate,
                   AnnouncePinCode = m.AnnouncePinCode,
                   AnnouncePublishDate = m.AnnouncePublishDate.Value,
                   AnnounceType = m.AnnounceType,
                   AnnounceUniqueCode = m.AnnounceUniqueCode,
                   AnnounceViewCount = m.AnnounceViewCount,
                   Condition = m.Condition,
                   ConditionBarter = m.ConditionBarter,
                   ConditionCredit = m.ConditionCredit,
                   Description = m.Description,
                   Email = m.Email,
                   PhoneNumber = m.PhoneNumber,
                   Price = m.Price,
                   PersonType = m.PersonType,
                   Photos = m.MotocyclePhotos.ToList(),
                   City = m.City,
                   MotocycleKilometer = m.MotocycleKilometer,
                   MotocycleMotor = m.MotocycleMotor,
                   MotocycleBodyType = m.MotocycleBodyType,
                   MotocycleModel = m.MotocycleModel,
                   MotocycleYear = m.MotocycleYear,
               FindTable=FindTable.Motocycle,
               })
               .SingleOrDefaultAsync();
            if (view)
            {
                Motocycle viewA = await _dbContext.Motocycles.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return motocycle;
        }
        // motocycle find data end

        // accessory find data start
        public async Task<IEnumerable<ViewAnnounce>> GetAccessories(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (announceName.ToLower()=="last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int bodyTypeId;
                    if (viewPage.BusBodyTypeId == null || viewPage.BusBodyTypeId == 0)
                        bodyTypeId = 0;
                    else
                        bodyTypeId = viewPage.BusBodyTypeId.Value;

                    int typeId;
                    if (viewPage.AccessoryTypeId == null || viewPage.AccessoryTypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.AccessoryTypeId.Value;
                    var datas = await _dbContext.Accessories
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")

                                                //search condition
                                                .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search city
                                                .Where(c => typeId == 0 ? true : c.AccessoryTypeId == bodyTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Accessory)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceAccessoryIds, c.Id, FindTable.Accessory),
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
                    var datap = await _dbContext.Accessories
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")

                                                //search condition
                                                .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search city
                                                .Where(c => typeId == 0 ? true : c.AccessoryTypeId == bodyTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Accessory)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceAccessoryIds, c.Id, FindTable.Accessory),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Accessories
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Accessory)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceAccessoryIds, c.Id, FindTable.Accessory),
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
                    var datap = await _dbContext.Accessories
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Accessory)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceAccessoryIds, c.Id, FindTable.Accessory),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int bodyTypeId;
                    if (viewPage.BusBodyTypeId == null || viewPage.BusBodyTypeId == 0)
                        bodyTypeId = 0;
                    else
                        bodyTypeId = viewPage.BusBodyTypeId.Value;

                    int typeId;
                    if (viewPage.AccessoryTypeId == null || viewPage.AccessoryTypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.AccessoryTypeId.Value;
                    data = await _dbContext.Accessories
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())

                                                //search condition
                                                .Where(c => (viewPage.Condition == 0 || viewPage.Condition == 100000) ? true : viewPage.Condition == 1 ? c.Condition == true : c.Condition == false)
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search city
                                                .Where(c => typeId == 0 ? true : c.AccessoryTypeId == bodyTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Accessory)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceAccessoryIds, c.Id, FindTable.Accessory),
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
                else
                {
                    data = await _dbContext.Accessories
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == announceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Accessory)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceAccessoryIds, c.Id, FindTable.Accessory),
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
            }
            return data;
        }

        public async Task<AccessoryViewItem> GetAccessory(int id, string unicode, bool view = true)
        {
            AccessoryViewItem accessory = await _dbContext
               .Accessories
               .Where(m => m.Id == id && m.AnnouncePublished)

               .Select(m => new AccessoryViewItem
               {
                   Id = m.Id,
                   AnounceName = m.AnnounceName,
                   AnnounceAddedDate = m.AnnounceAddedDate,
                   AnnouncePinCode = m.AnnouncePinCode,
                   AnnouncePublishDate = m.AnnouncePublishDate.Value,
                   AnnounceType = m.AnnounceType,
                   AnnounceUniqueCode = m.AnnounceUniqueCode,
                   AnnounceViewCount = m.AnnounceViewCount,
                   Condition = m.Condition,
                   Description = m.Description,
                   Email = m.Email,
                   PhoneNumber = m.PhoneNumber,
                   Price = m.Price,
                   PersonType = m.PersonType,
                   Photos = m.AccessoryPhotos.ToList(),
                   AccessoryType = m.AccessoryType,
                   City = m.City,
                   FindTable = FindTable.Accessory,

               })
               .FirstOrDefaultAsync();
            if (view)
            {
                Accessory viewA = await _dbContext.Accessories.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return accessory;
        }
        // accessory find data end

        //===============real estate
        public async Task<IEnumerable<ViewAnnounce>> GetRealEstates(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {
            List<ViewAnnounce> commomtData = new List<ViewAnnounce>();
            if (announceName.ToLower() == "last")
            {
                var apartmentData = await GetApartments(viewPage, announceName);
                var apartmentpData = await GetApartments(viewPage, "premium elan");
                var houseData = await GetHouses(viewPage, announceName);
                var housepData = await GetHouses(viewPage, "premium elan");
                var officeData = await GetOffices(viewPage, announceName);
                var officepData = await GetOffices(viewPage, "premium elan");
                var landData = await GetLands(viewPage, announceName);
                var landpData = await GetLands(viewPage, "premium elan");
                var garageData = await GetGarages(viewPage, announceName);
                var garagepData = await GetGarages(viewPage, "premium elan");
                commomtData.AddRange(apartmentData);
                commomtData.AddRange(apartmentpData);
                commomtData.AddRange(housepData);
                commomtData.AddRange(houseData);
                commomtData.AddRange(officepData);
                commomtData.AddRange(officeData);
                commomtData.AddRange(landData);
                commomtData.AddRange(landpData);
                commomtData.AddRange(garagepData);
                commomtData.AddRange(garageData);
                commomtData = commomtData.OrderByDescending(t => t.AddedPublishDate)
                    .Skip(startItem)
                    .Take(dataCount)
                    .ToList();
            }
            else
            {
                var apartmentData = await GetApartments(viewPage, announceName);
                var houseData = await GetHouses(viewPage, announceName);
                var officeData = await GetOffices(viewPage, announceName);
                var landData = await GetLands(viewPage, announceName);
                var garageData = await GetGarages(viewPage, announceName);
                commomtData.AddRange(apartmentData);
                commomtData.AddRange(houseData);
                commomtData.AddRange(officeData);
                commomtData.AddRange(landData);
                commomtData.AddRange(garageData);
                commomtData = commomtData.OrderByDescending(t => t.AddedPublishDate)
                    .Skip(startItem)
                    .Take(dataCount)
                    .ToList();
            }


            return commomtData;
        }
        //apartment find data start
        public async Task<IEnumerable<ViewAnnounce>> GetApartments(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;
                    int sArea;
                    int bArea;
                    if (viewPage.SArea == null || viewPage.SArea == 0)
                        sArea = 0;
                    else
                        sArea = viewPage.SArea.Value;
                    if (viewPage.BArea == null || viewPage.BArea == 0)
                        bArea = 0;
                    else
                        bArea = viewPage.BArea.Value;
                    int sRoomCount;
                    int bRoomCount;
                    if (viewPage.SRoomCount == null || viewPage.SRoomCount == 0)
                        sRoomCount = 0;
                    else
                        sRoomCount = viewPage.SRoomCount.Value;
                    if (viewPage.BRoomCount == null || viewPage.BRoomCount == 0)
                        bRoomCount = 0;
                    else
                        bRoomCount = viewPage.BRoomCount.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    int reTypeId;
                    if (viewPage.RETypeId == null || viewPage.RETypeId == 0)
                        reTypeId = 0;
                    else
                        reTypeId = viewPage.RETypeId.Value;
                    var datas = await _dbContext.Apartments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.ApartmentTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search area
                                                .Where(c => bArea == 0 ? sArea == 0 ? true : (c.Area >= sArea) : (c.Area <= bArea && c.Area >= sArea))
                                                //search roomcount
                                                .Where(c => bRoomCount == 0 ? sRoomCount == 0 ? true : (c.RoomCount >= sRoomCount) : (c.RoomCount <= bRoomCount && c.RoomCount >= sRoomCount))
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Apartment)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.RoomCount + "/" + c.Area, FindTable.Apartment),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceApartmentIds, c.Id, FindTable.Apartment),
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
                    var datap = await _dbContext.Apartments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.ApartmentTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search area
                                                .Where(c => bArea == 0 ? sArea == 0 ? true : (c.Area >= sArea) : (c.Area <= bArea && c.Area >= sArea))
                                                //search roomcount
                                                .Where(c => bRoomCount == 0 ? sRoomCount == 0 ? true : (c.RoomCount >= sRoomCount) : (c.RoomCount <= bRoomCount && c.RoomCount >= sRoomCount))
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Apartment)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.RoomCount + "/" + c.Area, FindTable.Apartment),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceApartmentIds, c.Id, FindTable.Apartment),
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
                    data.AddRange(datas);
                    data.AddRange(datap);

                }
                else
                {
                    var datas = await _dbContext.Apartments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Apartment)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.RoomCount + "/" + c.Area, FindTable.Bus),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceApartmentIds, c.Id, FindTable.Apartment),
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
                    var datap = await _dbContext.Apartments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Apartment)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.RoomCount + "/" + c.Area, FindTable.Bus),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceApartmentIds, c.Id, FindTable.Apartment),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }


            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;
                    int sArea;
                    int bArea;
                    if (viewPage.SArea == null || viewPage.SArea == 0)
                        sArea = 0;
                    else
                        sArea = viewPage.SArea.Value;
                    if (viewPage.BArea == null || viewPage.BArea == 0)
                        bArea = 0;
                    else
                        bArea = viewPage.BArea.Value;
                    int sRoomCount;
                    int bRoomCount;
                    if (viewPage.SRoomCount == null || viewPage.SRoomCount == 0)
                        sRoomCount = 0;
                    else
                        sRoomCount = viewPage.SRoomCount.Value;
                    if (viewPage.BRoomCount == null || viewPage.BRoomCount == 0)
                        bRoomCount = 0;
                    else
                        bRoomCount = viewPage.BRoomCount.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    int reTypeId;
                    if (viewPage.RETypeId == null || viewPage.RETypeId == 0)
                        reTypeId = 0;
                    else
                        reTypeId = viewPage.RETypeId.Value;
                    data = await _dbContext.Apartments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.ApartmentTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search area
                                                .Where(c => bArea == 0 ? sArea == 0 ? true : (c.Area >= sArea) : (c.Area <= bArea && c.Area >= sArea))
                                                //search roomcount
                                                .Where(c => bRoomCount == 0 ? sRoomCount == 0 ? true : (c.RoomCount >= sRoomCount) : (c.RoomCount <= bRoomCount && c.RoomCount >= sRoomCount))
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Apartment)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.RoomCount + "/" + c.Area, FindTable.Apartment),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceApartmentIds, c.Id, FindTable.Apartment),
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
                else
                {
                    data = await _dbContext.Apartments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Apartment)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.RoomCount + "/" + c.Area, FindTable.Bus),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceApartmentIds, c.Id, FindTable.Apartment),
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
            }

            return data;

        }

        public async Task<ApartmentView> GetApartment(int id, string unicode, bool view = true)
        {
            ApartmentView apartment = await _dbContext
                .Apartments
                .Where(m => m.Id == id && m.AnnouncePublished)

                .Select(m => new ApartmentView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.ApartmentPhotos.ToList(),
                    ApartmentType = m.ApartmentType,
                    ApartamentLocation = m.ApartamentLocation,
                    RSAnnounceType = m.RSAnnounceType,
                    Area = m.Area,
                    RoomCount = m.RoomCount,
                    City = m.City,
                    FindTable = FindTable.Apartment,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                Apartment viewA = await _dbContext.Apartments.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return apartment;
        }
        //apartment find data start

        //house find data start
        public async Task<IEnumerable<ViewAnnounce>> GetHouses(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;
                    int sArea;
                    int bArea;
                    if (viewPage.SArea == null || viewPage.SArea == 0)
                        sArea = 0;
                    else
                        sArea = viewPage.SArea.Value;
                    if (viewPage.BArea == null || viewPage.BArea == 0)
                        bArea = 0;
                    else
                        bArea = viewPage.BArea.Value;
                    int sRoomCount;
                    int bRoomCount;
                    if (viewPage.SRoomCount == null || viewPage.SRoomCount == 0)
                        sRoomCount = 0;
                    else
                        sRoomCount = viewPage.SRoomCount.Value;
                    if (viewPage.BRoomCount == null || viewPage.BRoomCount == 0)
                        bRoomCount = 0;
                    else
                        bRoomCount = viewPage.BRoomCount.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    int reTypeId;
                    if (viewPage.RETypeId == null || viewPage.RETypeId == 0)
                        reTypeId = 0;
                    else
                        reTypeId = viewPage.RETypeId.Value;
                    var datas = await _dbContext.Houses
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.HouseTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search area
                                                .Where(c => bArea == 0 ? sArea == 0 ? true : (c.Area >= sArea) : (c.Area <= bArea && c.Area >= sArea))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.House)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.HouseType.Name, FindTable.House),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceHouseIds, c.Id, FindTable.House),
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
                    var datap = await _dbContext.Houses
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.HouseTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search area
                                                .Where(c => bArea == 0 ? sArea == 0 ? true : (c.Area >= sArea) : (c.Area <= bArea && c.Area >= sArea))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.House)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.HouseType.Name, FindTable.House),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceHouseIds, c.Id, FindTable.House),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Houses
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.House)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.HouseType.Name, FindTable.House),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceHouseIds, c.Id, FindTable.House),
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
                    var datap = await _dbContext.Houses
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.House)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.HouseType.Name, FindTable.House),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceHouseIds, c.Id, FindTable.House),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;
                    int sArea;
                    int bArea;
                    if (viewPage.SArea == null || viewPage.SArea == 0)
                        sArea = 0;
                    else
                        sArea = viewPage.SArea.Value;
                    if (viewPage.BArea == null || viewPage.BArea == 0)
                        bArea = 0;
                    else
                        bArea = viewPage.BArea.Value;
                    int sRoomCount;
                    int bRoomCount;
                    if (viewPage.SRoomCount == null || viewPage.SRoomCount == 0)
                        sRoomCount = 0;
                    else
                        sRoomCount = viewPage.SRoomCount.Value;
                    if (viewPage.BRoomCount == null || viewPage.BRoomCount == 0)
                        bRoomCount = 0;
                    else
                        bRoomCount = viewPage.BRoomCount.Value;
                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    int reTypeId;
                    if (viewPage.RETypeId == null || viewPage.RETypeId == 0)
                        reTypeId = 0;
                    else
                        reTypeId = viewPage.RETypeId.Value;
                    data = await _dbContext.Houses
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.HouseTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                                //search area
                                                .Where(c => bArea == 0 ? sArea == 0 ? true : (c.Area >= sArea) : (c.Area <= bArea && c.Area >= sArea))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.House)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.HouseType.Name, FindTable.House),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceHouseIds, c.Id, FindTable.House),
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
                else
                {
                    data = await _dbContext.Houses
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.House)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.HouseType.Name, FindTable.House),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceHouseIds, c.Id, FindTable.House),
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
            }
        

            return data;
        }

        public async Task<HouseView> GetHouse(int id, string unicode, bool view = true)
        {
            HouseView house = await _dbContext
                .Houses
                .Where(m => m.Id == id && m.AnnouncePublished)

                .Select(m => new HouseView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.HousePhotos.ToList(),
                    HouseType = m.HouseType,
                    Location = m.HouseLocation,
                    Area = m.Area,
                    RSAnnounceType = m.RSAnnounceType,
                    City = m.City,
                    FindTable = FindTable.House,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                House viewA = await _dbContext.Houses.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return house;
        }
        //house find data end

        //office find data start
        public async Task<IEnumerable<ViewAnnounce>> GetOffices(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    int reTypeId;
                    if (viewPage.RETypeId == null || viewPage.RETypeId == 0)
                        reTypeId = 0;
                    else
                        reTypeId = viewPage.RETypeId.Value;
                    var datas = await _dbContext.Offices
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.AnnounceTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Office)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.OfficeType.Name, FindTable.Office),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceOfficeIds, c.Id, FindTable.Office),
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
                    var datap = await _dbContext.Offices
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.AnnounceTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Office)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.OfficeType.Name, FindTable.Office),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceOfficeIds, c.Id, FindTable.Office),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Offices
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Office)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.OfficeType.Name, FindTable.Office),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceOfficeIds, c.Id, FindTable.Office),
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
                    var datap = await _dbContext.Offices
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Office)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.OfficeType.Name, FindTable.Office),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceOfficeIds, c.Id, FindTable.Office),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    int reTypeId;
                    if (viewPage.RETypeId == null || viewPage.RETypeId == 0)
                        reTypeId = 0;
                    else
                        reTypeId = viewPage.RETypeId.Value;
                    data = await _dbContext.Offices
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.AnnounceTypeId == typeId)
                                                //search reType
                                                .Where(c => reTypeId == 0 ? true : c.RSAnnounceTypeId == reTypeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Office)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.OfficeType.Name, FindTable.Office),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceOfficeIds, c.Id, FindTable.Office),
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
                else
                {
                    data = await _dbContext.Offices
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Office)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.OfficeType.Name, FindTable.Office),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceOfficeIds, c.Id, FindTable.Office),
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
            }
         
            return data;
        }

        public async Task<OfficeView> GetOffice(int id, string unicode, bool view = true)
        {
            OfficeView office = await _dbContext
                .Offices
                .Where(m => m.Id == id && m.AnnouncePublished)

                .Select(m => new OfficeView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.OfficePhotos.ToList(),
                    Location = m.OfficeLocation,
                    Area = m.OfficeArea,
                    OfficeType = m.OfficeType,
                    RSAnnounceType = m.RSAnnounceType,
                    City = m.City,
                    FindTable = FindTable.Office,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                Office viewA = await _dbContext.Offices.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return office;
        }
        //office find data end

        //garage find data start
        public async Task<IEnumerable<ViewAnnounce>> GetGarages(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    var datas = await _dbContext.Garages
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Garage)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceGarageIds, c.Id, FindTable.Garage),
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
                    var datap = await _dbContext.Garages
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Garage)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceGarageIds, c.Id, FindTable.Garage),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Garages
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Garage)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceGarageIds, c.Id, FindTable.Garage),
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
                    var datap = await _dbContext.Garages
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Garage)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceGarageIds, c.Id, FindTable.Garage),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    data = await _dbContext.Garages
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Garage)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceGarageIds, c.Id, FindTable.Garage),
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
                else
                {
                    data = await _dbContext.Garages
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Garage)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceGarageIds, c.Id, FindTable.Garage),
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
            }
           

            return data;
        }

        public async Task<GarageView> GetGarage(int id, string unicode, bool view = true)
        {
            GarageView garage = await _dbContext
                .Garages
                .Where(m => m.Id == id && m.AnnouncePublished)

                .Select(m => new GarageView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.GaragePhotos.ToList(),
                    Location = m.GarageLocation,
                    Area = m.Area,
                    City = m.City,
                    FindTable = FindTable.Garage,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                Garage viewA = await _dbContext.Garages.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return garage;
        }
        //garage find data end

        //land find data start
        public async Task<IEnumerable<ViewAnnounce>> GetLands(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    var datas = await _dbContext.Lands
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Land)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceLandIds, c.Id, FindTable.Land),
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
                    var datap = await _dbContext.Lands
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Land)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceLandIds, c.Id, FindTable.Land),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Lands
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Land)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceLandIds, c.Id, FindTable.Land),
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
                    var datap = await _dbContext.Lands
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Land)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceLandIds, c.Id, FindTable.Land),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    data = await _dbContext.Lands
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Land)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceLandIds, c.Id, FindTable.Land),
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
                else
                {
                    data = await _dbContext.Lands
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Land)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceLandIds, c.Id, FindTable.Land),
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
            }
           
            return data;
        }

        public async Task<LandView> GetLand(int id, string unicode, bool view = true)
        {
            LandView land = await _dbContext
                .Lands
                .Where(m => m.Id == id)

                .Select(m => new LandView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.LandPhotos.ToList(),
                    Location = m.LandLocation,
                    Area = m.Area,
                    City = m.City,
                    FindTable = FindTable.Land,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                Land viewA = await _dbContext.Lands.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return land;
        }
        //land find data end

        //==================jobs

        public async Task<IEnumerable<ViewAnnounce>> GetJobAlls(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue)
        {
            List<ViewAnnounce> commomtData = new List<ViewAnnounce>();
            if (announceName.ToLower() == "last")
            {
                var jobData = await GetJobs(viewPage, announceName);
                var jobpData = await GetJobs(viewPage, "premium elan");
                var businessData = await GetBusinesses(viewPage, announceName);
                var businesspData = await GetBusinesses(viewPage, "premium elan");
                var foodData = await GetFoods(viewPage, announceName);
                var foodpData = await GetFoods(viewPage, "premium elan");
                commomtData.AddRange(jobData);
                commomtData.AddRange(jobpData);
                commomtData.AddRange(businesspData);
                commomtData.AddRange(businessData);
                commomtData.AddRange(foodpData);
                commomtData.AddRange(foodData);
                commomtData = commomtData.OrderByDescending(t => t.AddedPublishDate)
                    .Skip(startItem)
                    .Take(dataCount)
                    .ToList();
            }
            else
            {
                var jobData = await GetJobs(viewPage, announceName);
                var businessData = await GetBusinesses(viewPage, announceName);
                var foodData = await GetFoods(viewPage, announceName);
                commomtData.AddRange(jobData);
                commomtData.AddRange(businessData);
                commomtData.AddRange(foodData);
                commomtData = commomtData.OrderByDescending(t => t.AddedPublishDate)
                    .Skip(startItem)
                    .Take(dataCount)
                    .ToList();
            }

            return commomtData;
        }
        //job find data start
        public async Task<IEnumerable<ViewAnnounce>> GetJobs(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    var datas = await _dbContext.Jobs
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.JobTypeId == typeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Job)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceJobIds, c.Id, FindTable.Job),
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
                    var datap = await _dbContext.Jobs
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.JobTypeId == typeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Job)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceJobIds, c.Id, FindTable.Job),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Jobs
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Job)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceJobIds, c.Id, FindTable.Job),
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
                    var datap = await _dbContext.Jobs
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Job)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceJobIds, c.Id, FindTable.Job),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    data = await _dbContext.Jobs
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search type
                                                .Where(c => typeId == 0 ? true : c.JobTypeId == typeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Job)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceJobIds, c.Id, FindTable.Job),
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
                else
                {
                    data = await _dbContext.Jobs
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Job)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceJobIds, c.Id, FindTable.Job),
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
            }
            
            return data;
        }

        public async Task<JobView> GetJob(int id, string unicode, bool view = true)
        {
            JobView job = await _dbContext
                .Jobs
                .Where(m => m.Id == id && m.AnnouncePublished)

                .Select(m => new JobView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.JobPhotos.ToList(),
                    JobType = m.JobType,
                    City = m.City,
                    FindTable = FindTable.Job,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                Job viewA = await _dbContext.Jobs.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return job;
        }
        //job find data end

        //business find data start
        public async Task<IEnumerable<ViewAnnounce>> GetBusinesses(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    var datas = await _dbContext.BusinessEquipments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                 //search type
                                                 .Where(c => typeId == 0 ? true : c.BusinessTypeId == typeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Business)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceBusinessIds, c.Id, FindTable.Business),
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
                    var datap = await _dbContext.BusinessEquipments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                 //search type
                                                 .Where(c => typeId == 0 ? true : c.BusinessTypeId == typeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Business)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceBusinessIds, c.Id, FindTable.Business),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.BusinessEquipments
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Business)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceBusinessIds, c.Id, FindTable.Business),
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
                    var datap = await _dbContext.BusinessEquipments
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Business)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceBusinessIds, c.Id, FindTable.Business),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    int typeId;
                    if (viewPage.TypeId == null || viewPage.TypeId == 0)
                        typeId = 0;
                    else
                        typeId = viewPage.TypeId.Value;
                    data = await _dbContext.BusinessEquipments
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                 //search type
                                                 .Where(c => typeId == 0 ? true : c.BusinessTypeId == typeId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Business)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceBusinessIds, c.Id, FindTable.Business),
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
                else
                {
                    data = await _dbContext.BusinessEquipments
                                               .Where(c => c.AnnounceCheckIn && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Business)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceBusinessIds, c.Id, FindTable.Business),
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
            }
          
            return data;
        }

        public async Task<BusinessView> GetBusiness(int id, string unicode, bool view = true)
        {
            BusinessView business = await _dbContext
                .BusinessEquipments
                .Where(m => m.Id == id && m.AnnouncePublished)

                .Select(m => new BusinessView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.BusinessEPhotos.ToList(),
                    BusinessType = m.BusinessType,
                    City = m.City,
                    FindTable = FindTable.Business,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                BusinessEquipment viewA = await _dbContext.BusinessEquipments.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return business;
        }
        //business find data end

        //food find data start
        public async Task<IEnumerable<ViewAnnounce>> GetFoods(ViewPage viewPage, string AnnounceName, int startItem = 0, int dataCount = int.MaxValue)
        {

            List<ViewAnnounce> data = new List<ViewAnnounce>();
            if (AnnounceName.ToLower() == "last")
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    var datas = await _dbContext.Foods
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Food)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceFoodIds, c.Id, FindTable.Food),
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
                    var datap = await _dbContext.Foods
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Food)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceFoodIds, c.Id, FindTable.Food),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
                else
                {
                    var datas = await _dbContext.Foods
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "sade elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Food)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceFoodIds, c.Id, FindTable.Food),
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
                    var datap = await _dbContext.Foods
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == "premium elan")
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Food)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceFoodIds, c.Id, FindTable.Food),
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
                    data.AddRange(datas);
                    data.AddRange(datap);
                }
            }
            else
            {
                if (viewPage != null)
                {
                    int sPrice;
                    int bPrice;
                    if (viewPage.SPrice == null || viewPage.SPrice == 0)
                        sPrice = 0;
                    else
                        sPrice = viewPage.SPrice.Value;
                    if (viewPage.BPrice == null || viewPage.BPrice == 0)
                        bPrice = 0;
                    else
                        bPrice = viewPage.BPrice.Value;

                    int cityId;
                    if (viewPage.CityId == null || viewPage.CityId == 0)
                        cityId = 0;
                    else
                        cityId = viewPage.CityId.Value;
                    data = await _dbContext.Foods
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                //search name
                                                .Where(c => String.IsNullOrEmpty(viewPage.Name) ? true : c.AnnounceName.Contains(viewPage.Name))
                                                //search city
                                                .Where(c => cityId == 0 ? true : c.CityId == cityId)
                                                //search price
                                                .Where(c => bPrice == 0 ? sPrice == 0 ? true : (c.Price >= sPrice) : (c.Price <= bPrice && c.Price >= sPrice))
                                               .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Food)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceFoodIds, c.Id, FindTable.Food),
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
                else
                {
                    data = await _dbContext.Foods
                                               .Where(c => c.AnnounceCheckIn && c.AnnouncePublished && c.AnnounceType.Name.ToLower() == AnnounceName.ToLower())
                                                .OrderByDescending(c => c.AnnouncePublishDate)
                                               .Skip(startItem)
                                               .Take(dataCount)
                                               .Select(c => new ViewAnnounce(FindTable.Food)
                                               {
                                                   Id = c.Id,
                                                   Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                                   Price = c.Price,
                                                   City = c.City.Name,
                                                   AnnounceUnicode = c.AnnounceUniqueCode,
                                                   AddedPublishDate = c.AnnouncePublishDate.Value,
                                                   SelectedAnnounce = SelectedAnnounce(viewPage.announceFoodIds, c.Id, FindTable.Food),
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
            }
           
            return data;
        }

        public async Task<FoodView> GetFood(int id, string unicode, bool view = true)
        {
            FoodView food = await _dbContext
                .Foods
                .Where(m => m.Id == id && m.AnnouncePublished)

                .Select(m => new FoodView
                {
                    Id = m.Id,
                    AnounceName = m.AnnounceName,
                    AnnounceAddedDate = m.AnnounceAddedDate,
                    AnnouncePinCode = m.AnnouncePinCode,
                    AnnouncePublishDate = m.AnnouncePublishDate.Value,
                    AnnounceType = m.AnnounceType,
                    AnnounceUniqueCode = m.AnnounceUniqueCode,
                    AnnounceViewCount = m.AnnounceViewCount,
                    Description = m.Description,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    Price = m.Price,
                    PersonType = m.PersonType,
                    Photos = m.FoodPhotos.ToList(),
                    City = m.City,
                    FindTable = FindTable.Food,

                })
                .SingleOrDefaultAsync();
            if (view)
            {
                Food viewA = await _dbContext.Foods.FindAsync(id);
                viewA.AnnounceViewCount++;
                await _dbContext.SaveChangesAsync();
            }
            return food;
        }
        //food find data end



        //=======================New Announce=====================
        public async Task<SettingModel> SettingDataAsync(string categoryName, int makeId)
        {
            return new SettingModel
            {
                City = await _dbContext.Cities.ToListAsync(),
                AutoEquipments = await _dbContext.AutoEquipments.ToListAsync(),
                CarBodyTypes = await _dbContext.CarBodyTypes.ToListAsync(),
                CarMakes = await _dbContext.CarMakes.ToListAsync(),
                CarModels = await _dbContext.CarModels.Where(x => x.CarMakeId == makeId).ToListAsync(),
                FuelTypes = await _dbContext.FuelTypes.ToListAsync(),
                SpeedBoxes = await _dbContext.SpeedBoxes.ToListAsync(),
                Transmissions = await _dbContext.Transmissions.ToListAsync(),
                PersonTypes = await _dbContext.PersonTypes.ToListAsync(),
                AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync(),
                AccessoryTypes = await _dbContext.AccessoryTypes.ToListAsync(),
                ActivityAreas = await _dbContext.ActivityAreas.ToListAsync(),
                ApartmentTypes = await _dbContext.ApartmentTypes.ToListAsync(),
                BusBodyTypes = await _dbContext.BusBodyTypes.ToListAsync(),
                BusinessTypes = await _dbContext.BusinessTypes.ToListAsync(),
                BusMakes = await _dbContext.BusMakes.ToListAsync(),
                HouseTypes = await _dbContext.HouseTypes.ToListAsync(),
                JobTypes = await _dbContext.JobTypes.ToListAsync(),
                MotocycleBodyTypes = await _dbContext.MotocycleBodyTypes.ToListAsync(),
                MotocycleMakes = await _dbContext.MotocycleMakes.ToListAsync(),
                OfficeTypes = await _dbContext.OfficeTypes.ToListAsync(),
                RSAnnounceTypes = await _dbContext.RSAnnounceTypes.ToListAsync(),
                VipPrice = await _dbContext.AnnounceTypes.Where(at => at.Name.ToLower() == "vip elan").FirstOrDefaultAsync(),
            };
        }

        //===============================find user data===========================


        public async Task<UserViewModel> FindUserDataAsync(string id)
        {
            AppUser user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

            UserViewModel viewModel = new UserViewModel(user.Id,user.UserName, user.Email, user.PhoneNumber);
            DateTime date = DateTime.Now;
            user.Cars.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Car)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,
                                AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Car)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Car)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Car)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Car),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Buses.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Bus)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Bus)
                        {

                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Bus)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Bus)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Bus),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Motocycles.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Motocycle)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Motocycle)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Motocycle)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Motocycle)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Motocycle),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Accessories.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Accessory)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Accessory)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Accessory)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Accessory)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Accessory),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Apartments.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Apartment)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Apartment),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Apartment)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Apartment),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Apartment)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Apartment),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Apartment)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Apartment),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Houses.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.House)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.House),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.House)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.House),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.House)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.House),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.House)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.House),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });
                }
            });
            user.Offices.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Office)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Office),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Office)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Office),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Office)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Office),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Office)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Office),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Garages.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Garage)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Garage)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Garage)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Garage)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Garage),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Lands.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Land)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Land)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Land)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Land)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Land),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });
                }
            });
            user.Jobs.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Job)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Job)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Job)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Job)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Job),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.BusinessEquipments.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Business)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Business)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Business)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Business)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Business),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });

                }
            });
            user.Foods.ToList().ForEach(c =>
            {

                if (c.AnnounceCheckIn)
                {
                    if (c.AnnouncePublished)
                    {
                        if (c.AnnounceEndedDate > date)
                        {
                            viewModel.EndedAnnounces.Add(new ViewAnnounce(FindTable.Food)
                            {
                                Id = c.Id,
                                Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                                Price = c.Price,
                                City = c.City.Name,
                                AnnounceUnicode = c.AnnounceUniqueCode,
                                AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                                }).ToList()
                            });
                        }
                        viewModel.PublishedAnnounces.Add(new ViewAnnounce(FindTable.Food)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                    else
                    {
                        viewModel.NonPublishedAnnounces.Add(new ViewAnnounce(FindTable.Food)
                        {
                            Id = c.Id,
                            Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                            Price = c.Price,
                            City = c.City.Name,
                            AnnounceUnicode = c.AnnounceUniqueCode,
                            AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                            }).ToList()
                        });
                    }
                }
                else
                {
                    viewModel.CheckInAnnounces.Add(new ViewAnnounce(FindTable.Food)
                    {
                        Id = c.Id,
                        Name = _settingAnnounce.GenerateAnnounceName(c.AnnounceName, FindTable.Food),
                        Price = c.Price,
                        City = c.City.Name,
                        AnnounceUnicode = c.AnnounceUniqueCode,
                        AddedPublishDate = c.AnnouncePublishDate.Value,
                                AddedDate=c.AnnounceAddedDate,AnnouncePinCode =c.AnnouncePinCode==null?"---":c.AnnouncePinCode,
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

                        }).ToList()
                    });
                }
            });

            return viewModel;
        }

        public bool SelectedAnnounce(string announceIds, int announceId, FindTable find)
        {
            bool selected = false;

            if (!String.IsNullOrEmpty(announceIds))
            {
                switch (find)
                {
                    case FindTable.Car:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Bus:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Accessory:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Motocycle:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Apartment:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.House:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Office:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Garage:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Land:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Job:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Business:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    case FindTable.Food:
                        foreach (var item in announceIds.Split(','))
                        {
                            if (item.Trim() == announceId.ToString())
                                selected = true;
                        }
                        break;
                    default:
                        break;
                }
            }

            return selected;
        }



        //============================Admin Panel find start=======================================

        public async Task<AppUser> GetAppUsers(RoleType roleType)
        {
            return null;
        }
        public async Task<IEnumerable<ViewAnnounceA>> GetAnnouncesA(FindTableA findTable, FindStatusAnnounceA findStatusAnnounce, int startItem = 0, int dataCount = int.MaxValue)
        {
            List<ViewAnnounceA> data = new List<ViewAnnounceA>();

            switch (findTable)
            {
                case FindTableA.Common:
                    var carData = await _dbContext.Cars
                .Select(c => new ViewAnnounceA(FindTable.Car, "Nəqliyyat", "Avtomobil")
                {
                    Id = c.Id,
                    Name = c.AnnounceName,
                    Price = c.Price,
                    City = c.City.Name,
                    AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                    AnnounceType = c.AnnounceType,
                    AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                    Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                    FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                    AddedDate = c.AnnounceAddedDate,
                    EditAction = "CarEdit",
                    Controller= "Transport",
                    ReadAction = "CarRead",
                    Photos = c.CarPhotos.Select(p => new ViewPhoto
                    {
                        Id = p.Id,
                        Path = p.Path,
                        AnnounceId = c.Id,

                    }).ToList(),
                }).ToListAsync();
                    var busData = await _dbContext.Buses
                        .Select(c => new ViewAnnounceA(FindTable.Bus, "Nəqliyyat", "Avtobuslar")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "BusEdit",
                            Controller= "Transport",
                            ReadAction = "BusRead",
                            Photos = c.BusPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var motocycleData = await _dbContext.Motocycles
                        .Select(c => new ViewAnnounceA(FindTable.Motocycle, "Nəqliyyat", "Motosikletər və Mopedlər")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "MotorcycleEdit",
                            Controller= "Transport",
                            ReadAction = "MotorcycleRead",
                            Photos = c.MotocyclePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var accessoryData = await _dbContext.Accessories
                        .Select(c => new ViewAnnounceA(FindTable.Accessory, "Nəqliyyat", "Aksesuarlar")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "AccessoryEdit",
                            Controller= "Transport",
                            ReadAction = "AccessoryRead",
                            Photos = c.AccessoryPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var apartmentData = await _dbContext.Apartments
                        .Select(c => new ViewAnnounceA(FindTable.Apartment, "Daşınmaz əmlak", "Mənzil")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "ApartmentEdit",
                            Controller= "RealEstate",
                            ReadAction = "ApartmentRead",
                            Photos = c.ApartmentPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var houseData = await _dbContext.Houses
                        .Select(c => new ViewAnnounceA(FindTable.House, "Daşınmaz əmlak", "Bağ evi və ya Villa")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "HouseVillaEdit",
                            Controller= "RealEstate",
                            ReadAction = "HouseVillaRead",
                            Photos = c.HousePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var officeData = await _dbContext.Offices
                        .Select(c => new ViewAnnounceA(FindTable.Office, "Daşınmaz əmlak", "Ofis")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "CommercialEdit",
                            Controller= "RealEstate",
                            ReadAction = "CommercialRead",
                            Photos = c.OfficePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var garageData = await _dbContext.Garages
                        .Select(c => new ViewAnnounceA(FindTable.Garage, "Daşınmaz əmlak", "Qaraj")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "GarageEdit",
                            Controller= "RealEstate",
                            ReadAction = "GarageRead",
                            Photos = c.GaragePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var landData = await _dbContext.Lands
                        .Select(c => new ViewAnnounceA(FindTable.Land, "Daşınmaz əmlak", "Torpaq")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "LandEdit",
                            Controller= "RealEstate",
                            ReadAction = "LandRead",
                            Photos = c.LandPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var jobData = await _dbContext.Jobs
                        .Select(c => new ViewAnnounceA(FindTable.Job, "İş və Biznes", "İş")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "JobEdit",
                            Controller= "Job",
                            ReadAction = "JobRead",
                            Photos = c.JobPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var businessData = await _dbContext.BusinessEquipments
                        .Select(c => new ViewAnnounceA(FindTable.Business, "İş və Biznes", "Biznes üçün avadanlıq")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "BusinessEdit",
                            Controller= "Job",
                            ReadAction = "BusinessRead",
                            Photos = c.BusinessEPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    var foodData = await _dbContext.Foods
                        .Select(c => new ViewAnnounceA(FindTable.Food, "İş və Biznes", "Ərzaq")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "FoodEdit",
                            Controller= "Job",
                            ReadAction = "FoodRead",
                            Photos = c.FoodPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();

                    data.AddRange(carData);
                    data.AddRange(busData);
                    data.AddRange(motocycleData);
                    data.AddRange(accessoryData);
                    data.AddRange(apartmentData);
                    data.AddRange(houseData);
                    data.AddRange(officeData);
                    data.AddRange(garageData);
                    data.AddRange(landData);
                    data.AddRange(jobData);
                    data.AddRange(businessData);
                    data.AddRange(foodData);
                    break;
                case FindTableA.Car:
                    var carDataa = await _dbContext.Cars
                .Select(c => new ViewAnnounceA(FindTable.Car, "Nəqliyyat", "Avtomobil")
                {
                    Id = c.Id,
                    Name = c.AnnounceName,
                    Price = c.Price,
                    City = c.City.Name,
                    AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                    AnnounceType = c.AnnounceType,
                    AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                    Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                    FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                    AddedDate = c.AnnounceAddedDate,
                    EditAction = "CarEdit",
                    Controller= "Transport",
                    ReadAction = "CarRead",
                    Photos = c.CarPhotos.Select(p => new ViewPhoto
                    {
                        Id = p.Id,
                        Path = p.Path,
                        AnnounceId = c.Id,

                    }).ToList(),
                }).ToListAsync();
                    data.AddRange(carDataa);
                    break;
                case FindTableA.Bus:
                    var busDataa = await _dbContext.Buses
                        .Select(c => new ViewAnnounceA(FindTable.Bus, "Nəqliyyat", "Avtomobil")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "BusEdit",
                            Controller= "Transport",
                            ReadAction = "BusRead",
                            Photos = c.BusPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(busDataa);
                    break;
                case FindTableA.Accessory:
                    var accessoryDataa = await _dbContext.Accessories
                        .Select(c => new ViewAnnounceA(FindTable.Accessory, "Nəqliyyat", "Avtomobil")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "AccessoryEdit",
                            Controller= "Transport",
                            ReadAction = "AccessoryRead",
                            Photos = c.AccessoryPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(accessoryDataa);
                    break;
                case FindTableA.Motocycle:
                    var motocycleDataa = await _dbContext.Motocycles
                        .Select(c => new ViewAnnounceA(FindTable.Motocycle, "Nəqliyyat", "Avtomobil")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "MotorcycleEdit",
                            Controller= "Transport",
                            ReadAction = "MotorcycleRead",
                            Photos = c.MotocyclePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(motocycleDataa);
                    break;
                case FindTableA.Apartment:
                    var apartmentDataa = await _dbContext.Apartments
                        .Select(c => new ViewAnnounceA(FindTable.Apartment, "Daşınmaz əmlak", "Mənzil")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "ApartmentEdit",
                            Controller= "RealEstate",
                            ReadAction = "ApartmentRead",
                            Photos = c.ApartmentPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(apartmentDataa);
                    break;
                case FindTableA.House:
                    var houseDataa = await _dbContext.Houses
                        .Select(c => new ViewAnnounceA(FindTable.House, "Daşınmaz əmlak", "Bağ evi və ya Villa")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "HouseVillaEdit",
                            Controller= "RealEstate",
                            ReadAction = "HouseVillaRead",
                            Photos = c.HousePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(houseDataa);
                    break;
                case FindTableA.Office:
                    var officeDataa = await _dbContext.Offices
                        .Select(c => new ViewAnnounceA(FindTable.Office, "Daşınmaz əmlak", "Ofis")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "CommercialEdit",
                            Controller= "RealEstate",
                            ReadAction = "CommercialRead",
                            Photos = c.OfficePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(officeDataa);
                    break;
                case FindTableA.Garage:
                    var garageDataa = await _dbContext.Garages
                        .Select(c => new ViewAnnounceA(FindTable.Garage, "Daşınmaz əmlak", "Qaraj")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "GarageEdit",
                            Controller= "RealEstate",
                            ReadAction = "GarageRead",
                            Photos = c.GaragePhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(garageDataa);
                    break;
                case FindTableA.Land:
                    var landDataa = await _dbContext.Lands
                        .Select(c => new ViewAnnounceA(FindTable.Land, "Daşınmaz əmlak", "Torpaq")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "LandEdit",
                            Controller= "RealEstate",
                            ReadAction = "LandRead",
                            Photos = c.LandPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(landDataa);
                    break;
                case FindTableA.Job:
                    var jobDataa = await _dbContext.Jobs
                        .Select(c => new ViewAnnounceA(FindTable.Job, "İş və Biznes", "İş")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "JobEdit",
                            Controller= "Job",
                            ReadAction = "JobRead",
                            Photos = c.JobPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(jobDataa);
                    break;
                case FindTableA.Business:
                    var businessDataa = await _dbContext.BusinessEquipments
                        .Select(c => new ViewAnnounceA(FindTable.Business, "İş və Biznes", "Biznes üçün avadanlıq")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "BusinessEdit",
                            Controller= "Job",
                            ReadAction = "BusinessRead",
                            Photos = c.BusinessEPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(businessDataa);
                    break;
                case FindTableA.Food:
                    var foodDataa = await _dbContext.Foods
                        .Select(c => new ViewAnnounceA(FindTable.Food, "İş və Biznes", "Ərzaq")
                        {
                            Id = c.Id,
                            Name = c.AnnounceName,
                            Price = c.Price,
                            City = c.City.Name,
                            AnnouncePinCode = String.IsNullOrEmpty(c.AnnouncePinCode) ? "---" : c.AnnouncePinCode,
                            AnnounceType = c.AnnounceType,
                            AnnounceTypeFind = FindAnnounceType(c.AnnounceType),
                            Status = CheckInStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            FindStatus = GetFindStatus(c.AnnouncePublished, c.AnnounceCheckIn),
                            AddedDate = c.AnnounceAddedDate,
                            EditAction = "FoodEdit",
                            Controller= "Job",
                            ReadAction = "FoodRead",
                            Photos = c.FoodPhotos.Select(p => new ViewPhoto
                            {
                                Id = p.Id,
                                Path = p.Path,
                                AnnounceId = c.Id,

                            }).ToList(),
                        }).ToListAsync();
                    data.AddRange(foodDataa);
                    break;
                default:
                    break;
            }



            IEnumerable<ViewAnnounceA> finishData = new List<ViewAnnounceA>();
            switch (findStatusAnnounce)
            {
                case FindStatusAnnounceA.Common:
                    finishData = data.OrderByDescending(c => c.AddedDate)
                                                .Skip(startItem * dataCount)
                                                .Take(dataCount).ToList();
                    break;
                case FindStatusAnnounceA.NonCheckIn:
                    finishData = data.Where(a => a.FindStatus == FindStatus.Yoxlama)
                                        .OrderByDescending(c => c.AddedDate)
                                        .Skip(startItem * dataCount)
                                        .Take(dataCount).ToList();
                    break;
                case FindStatusAnnounceA.Published:
                    finishData = data.Where(a => a.FindStatus == FindStatus.Derc)
                                            .OrderByDescending(c => c.AddedDate)
                                            .Skip(startItem * dataCount)
                                            .Take(dataCount).ToList();
                    break;
                case FindStatusAnnounceA.NonPublished:
                    finishData = data.Where(a => a.FindStatus == FindStatus.Redd)
                                         .OrderByDescending(c => c.AddedDate)
                                         .Skip(startItem * dataCount)
                                         .Take(dataCount).ToList();
                    break;
                default:
                    finishData = null;
                    break;
            }

            return finishData;
        }

        private FindStatus GetFindStatus(bool announcePublished, bool announceCheckIn)
        {
            if (announceCheckIn)
            {
                if (announcePublished)
                    return FindStatus.Derc;
                else
                    return FindStatus.Redd;
            }
            else
                return FindStatus.Yoxlama;
        }

        private AnnounceTypeFind FindAnnounceType(AnnounceType announceType)
        {
            return announceType.Name.ToLower().Contains("sad") ? AnnounceTypeFind.Sade : announceType.Name.ToLower().Contains("premium") ? AnnounceTypeFind.Premium : AnnounceTypeFind.Vip;
        }

        private string CheckInStatus(bool announcePublished, bool announceCheckIn)
        {
            string status;

            if (announceCheckIn)
            {
                if (announcePublished)
                    status = "Dərc olunub";
                else
                    status = "Rədd olunub";
            }
            else
                status = "Yoxlanılmayıb";

            return status;

        }


        //car 
        public async Task<CarEditModel> GetCarA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Cars.Where(c => c.Id == id)
                                                .Select(c => new CarEditModel
                                                {
                                                     MakeId=c.CarModel.CarMakeId,
                                                      ModelId=c.CarModelId,
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Condition = c.Condition,
                                                    ConditionBarter = c.ConditionBarter,
                                                    ConditionCredit = c.ConditionCredit,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    Kilometer = c.CarKilometer,
                                                    Motor = c.CarMotor,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    Year = c.CarYear,
                                                    Photos = c.CarPhotos.ToList(),
                                                    BodyTypeId = c.CarBodyTypeId,
                                                    MotorStrength = c.CarMotorStrength,
                                                    SpeedBoxId = c.SpeedBoxId,
                                                    TransmissionId = c.TransmissionId,
                                                    Color = c.Color,
                                                    FuelTypeId = c.FuelTypeId,
                                                    FindTable = FindTable.Car,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                }).SingleOrDefaultAsync();

            announce.SelectedAutoEquipments = await _dbContext.CarAutoEquipments.Where(c => c.CarId == announce.Id).Select(c => c.AutoEquipment).ToListAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.BodyTypes = await _dbContext.CarBodyTypes.ToListAsync();
            announce.AutoEquipments = await _dbContext.AutoEquipments.ToListAsync();
            announce.FuelTypes = await _dbContext.FuelTypes.ToListAsync();
            announce.Makes = await _dbContext.CarMakes.ToListAsync();
            announce.Models = await _dbContext.CarModels.Where(c=>c.CarMakeId==announce.MakeId).ToListAsync();
            announce.SpeedBoxes = await _dbContext.SpeedBoxes.ToListAsync();
            announce.Transmissions = await _dbContext.Transmissions.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;

        }

        public async Task<BusEditModel> GetBusA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Buses.Where(c => c.Id == id)
                                                .Select(c => new BusEditModel
                                                {
                                                    AnnounceName=c.AnnounceName,
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Condition = c.Condition,
                                                    ConditionBarter = c.ConditionBarter,
                                                    ConditionCredit = c.ConditionCredit,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    BusKilometer = c.BusKilometer,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    BusYear = c.BusYear,
                                                    BusPhotos = c.BusPhotos.ToList(),
                                                    BusBodyTypeId = c.BusBodyTypeId,
                                                    FindTable = FindTable.Bus,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                     BusMakeId=c.BusMakeId,
                                                }).SingleOrDefaultAsync();


            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.BusMakes = await _dbContext.BusMakes.ToListAsync();
            announce.BusBodyTypes = await _dbContext.BusBodyTypes.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<MotorcycleEditModel> GetMotocycleA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Motocycles.Where(c => c.Id == id)
                                                .Select(c => new MotorcycleEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Condition = c.Condition,
                                                    ConditionBarter = c.ConditionBarter,
                                                    ConditionCredit = c.ConditionCredit,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    MotocycleKilometer = c.MotocycleKilometer,
                                                    MotocycleMotor = c.MotocycleMotor,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    MotocycleYear = c.MotocycleYear,
                                                    MotocyclePhotos = c.MotocyclePhotos.ToList(),
                                                    MotocycleBodyTypeId = c.MotocycleBodyTypeId,
                                                    MotocycleModel=c.MotocycleModel,
                                                     AnnounceName=c.AnnounceName,
                                                      AppUser=c.AppUser,
                                                       
                                                    FindTable = FindTable.Motocycle,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    MotocycleMakeId=c.MotocycleMakeId,
                                                }).SingleOrDefaultAsync();


            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.MotocycleMakes = await _dbContext.MotocycleMakes.ToListAsync();
            announce.MotocycleBodyTypes = await _dbContext.MotocycleBodyTypes.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<AccessoryEditModel> GetAccessoryA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Accessories.Where(c => c.Id == id)
                                                .Select(c => new AccessoryEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Condition = c.Condition,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Accessory,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                     AppUser=c.AppUser,
                                                      AnnounceName=c.AnnounceName,
                                                       AccessoryTypeId=c.AccessoryTypeId,
                                                        AccessoryPhotos=c.AccessoryPhotos.ToList(),
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.AccessoryTypes = await _dbContext.AccessoryTypes.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            announce.ControllerName = "transport";
            announce.ActionName = "accessory";
            return announce;
        }

        public async Task<ApartmentEditModel> GetApartmentA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Apartments.Where(c => c.Id == id)
                                                .Select(c => new ApartmentEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Apartment,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                     ApartamentLocation=c.ApartamentLocation,
                                                      ApartmentPhotos=c.ApartmentPhotos.ToList(),
                                                       ApartmentTypeId=c.ApartmentTypeId,
                                                        Area=c.Area,
                                                         RoomCount=c.RoomCount,
                                                          RSAnnounceTypeId=c.RSAnnounceTypeId,
                                                           
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.RSAnnounceTypes = await _dbContext.RSAnnounceTypes.ToListAsync();
            announce.ApartmentTypes = await _dbContext.ApartmentTypes.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<HouseVillaEditModel> GetHouseA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Houses.Where(c => c.Id == id)
                                                .Select(c => new HouseVillaEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    Area=c.Area,
                                                     HouseLocation=c.HouseLocation,
                                                    PhoneNumber = c.PhoneNumber,
                                                     RSAnnounceTypeId=c.RSAnnounceTypeId,
                                                    Price = c.Price,
                                                    FindTable = FindTable.House,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                     HouseTypeId=c.HouseTypeId,

                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.HouseTypes = await _dbContext.HouseTypes.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.RSAnnounceTypes = await _dbContext.RSAnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<GarageEditModel> GetGarageA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Garages.Where(c => c.Id == id)
                                                .Select(c => new GarageEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Garage,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                     GarageLocation=c.GarageLocation,
                                                      Area=c.Area,
                                                       
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<CommercialEditModel> GetOfficeA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Offices.Where(c => c.Id == id)
                                                .Select(c => new CommercialEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Office,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                    OfficeLocation = c.OfficeLocation,
                                                    OfficeArea = c.OfficeArea,
                                                     OfficeTypeId=c.OfficeTypeId,
                                                      RSAnnounceTypeId=c.RSAnnounceTypeId,
                                                       OfficePhotos=c.OfficePhotos.ToList(),
                                                        

                                                       
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.RSAnnounceTypes = await _dbContext.RSAnnounceTypes.ToListAsync();
            announce.OfficeTypes = await _dbContext.OfficeTypes.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<LandEditModel> GetLandA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Lands.Where(c => c.Id == id)
                                                .Select(c => new LandEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Land,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                     Area=c.Area,
                                                      LandLocation=c.LandLocation,
                                                       LandPhotos=c.LandPhotos.ToList(),
                                                        
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<JobEditModel> GetJobA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Jobs.Where(c => c.Id == id)
                                                .Select(c => new JobEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Job,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                     ActivityAreaId=c.ActivityAreaId,
                                                      JobTypeId=c.JobTypeId,
                                                       JobPhotos=c.JobPhotos.ToList(),
                                                        
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.JobTypes = await _dbContext.JobTypes.ToListAsync();
            announce.ActivityAreas = await _dbContext.ActivityAreas.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<BusinessEditModel> GetBusinessA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.BusinessEquipments.Where(c => c.Id == id)
                                                .Select(c => new BusinessEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Business,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                     BusinessTypeId=c.BusinessTypeId,
                                                      BusinessEPhotos=c.BusinessEPhotos.ToList(),
                                                       
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.BusinessTypes = await _dbContext.BusinessTypes.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        public async Task<FoodEditModel> GetFoodA(int? id)
        {
            if (id == null && id == 0)
                return null;

            var announce = await _dbContext.Foods.Where(c => c.Id == id)
                                                .Select(c => new FoodEditModel()
                                                {
                                                    Id = c.Id,
                                                    AnnounceViewCount = c.AnnounceViewCount,
                                                    Description = c.Description,
                                                    Email = c.Email,
                                                    PhoneNumber = c.PhoneNumber,
                                                    Price = c.Price,
                                                    FindTable = FindTable.Food,
                                                    AnnouncePublished = c.AnnouncePublished,
                                                    AnnounceCheckIn = c.AnnounceCheckIn,
                                                    AppUserId = c.AppUserId,
                                                    CityId = c.CityId,
                                                    AnnounceEndedDate = c.AnnounceEndedDate,
                                                    AnnounceEnded = c.AnnounceEnded,
                                                    PaymentTypeId = c.PaymentTypeId,
                                                    AnnounceTypeId = c.AnnounceTypeId,
                                                    PersonTypeId = c.PersonTypeId,
                                                    AppUser = c.AppUser,
                                                    AnnounceName = c.AnnounceName,
                                                     FoodPhotos=c.FoodPhotos.ToList(),
                                                }).SingleOrDefaultAsync();

            announce.Cities = await _dbContext.Cities.ToListAsync();
            announce.AnnounceTypes = await _dbContext.AnnounceTypes.ToListAsync();
            announce.PersonTypes = await _dbContext.PersonTypes.ToListAsync();
            announce.PaymentTypes = await _dbContext.PaymentTypes.ToListAsync();
            return announce;
        }

        //============================Admin Panel find end=========================================
    }
}
