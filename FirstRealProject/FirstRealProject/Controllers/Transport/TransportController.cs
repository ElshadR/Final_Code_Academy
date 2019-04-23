using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Implementations;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using FirstRealProject.Models.PagesModels.ViewModel.Transport;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Cars.Items;
using FirstRealProject.Models.Transports.CarModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Controllers.Transport
{
    public class TransportController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }
        private UserManager<AppUser> _userManager;

        public TransportController(FirstRealProjectDbContext dbContext,IFindAnnounce dataFind, UserManager<AppUser> userMgr)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
            _userManager = userMgr;
        }

        public async Task<IActionResult> Index(ViewPage viewSearch)
        {
            HttpContext.Session.SetString("compair", "");
            viewSearch.announceIds = Request.Cookies["carId"];
            viewSearch.announceBusIds = Request.Cookies["busId"];
            viewSearch.announceMotocycleIds = Request.Cookies["motocycleId"];
            viewSearch.announceAccessoryIds = Request.Cookies["accessoryId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetTransports(viewSearch, "vip elan", 0, 7),
                LastAnnounces = await _dataFind.GetTransports(viewSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
                ConditionCredit = viewSearch.ConditionCredit,
                ConditionBarter = viewSearch.ConditionBarter
            };
            return View(data);
        }
        [Route("all/[controller]/type-all")]
        public async Task<IActionResult> TypeAllAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceIds = Request.Cookies["carId"];
            commonData.announceBusIds = Request.Cookies["busId"];
            commonData.announceMotocycleIds = Request.Cookies["motocycleId"];
            commonData.announceAccessoryIds = Request.Cookies["accessoryId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetTransports(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetTransports(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetTransports(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetTransports(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetTransports(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetTransports(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                    }
                };
            }

            commonData.Pagination.ControllerName = "transport";
            commonData.Pagination.ActionName = "type-all";
            return View(commonData);
        }
        //==============index

        public async Task<IActionResult> Cars(ViewPage carsSearch)
        {

            HttpContext.Session.SetString("compair", "");
            carsSearch.announceIds = Request.Cookies["carId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetCars(carsSearch, "vip elan",0,3),
                LastAnnounces = await _dataFind.GetCars(carsSearch, "last",0,8),
                Cities=await _dbContext.Cities.ToListAsync(),
                CarMakes = await _dbContext.CarMakes.ToListAsync(),
                CarBodyTypes=await _dbContext.CarBodyTypes.ToListAsync(),
                ConditionCredit = carsSearch.ConditionCredit,
                ConditionBarter = carsSearch.ConditionBarter
            };

            return View(data);
        }
        //single
        [Route("all/[controller]/announce-car")]
        public async Task<IActionResult> AnnounceCar(int id, string unicode)
        {
            var car =await _dataFind.GetCar(id,unicode);
            
            return View(car);
        }

        [Route("all/[controller]/type-car")]
        public async Task<IActionResult> TypeCarAnnouence(string typeAnnounce,int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceIds= Request.Cookies["carId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetCars(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetCars(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetCars(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                    }
                };
            }

            commonData.Pagination.ControllerName = "transport";
            commonData.Pagination.ActionName = "type-car";
            return View(commonData);
        }
        //====================car end


        //====================bus start
        public async Task<IActionResult> Buses(ViewPage carsSearch)
        {
            HttpContext.Session.SetString("compair", "");
            carsSearch.announceBusIds = Request.Cookies["busId"];
            ViewPage data = new ViewPage
            {
                Cities = await _dbContext.Cities.ToListAsync(),
                ViewAnnouncesVip = await _dataFind.GetBuses(carsSearch, "vip elan", 0, 7),
                LastAnnounces = await _dataFind.GetBuses(carsSearch, "last", 0, 8),
                BusMakes = await _dbContext.BusMakes.ToListAsync(),
                BusBodyTypes = await _dbContext.BusBodyTypes.ToListAsync(),
                ConditionCredit = carsSearch.ConditionCredit,
                ConditionBarter = carsSearch.ConditionBarter
            };

            return View(data);
        }
        [Route("all/[controller]/announce-bus")]
        public async Task<IActionResult> AnnounceBus(int id, string unicode)
        {
            var motocycle = await _dataFind.GetBus(id,unicode);
            return View(motocycle);
        }
        [Route("all/[controller]/type-bus")]
        public async Task<IActionResult> TypeBusAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceBusIds= Request.Cookies["busId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetCars(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetCars(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetCars(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                    }
                };
            }

            commonData.Pagination.ControllerName = "transport";
            commonData.Pagination.ActionName = "type-bus";
            return View(commonData);
        }
        //====================bus end

        //====================Motocycle start
        public async Task<IActionResult> Motocycles(ViewPage carsSearch)
        {
            HttpContext.Session.SetString("compair", "");
            carsSearch.announceMotocycleIds = Request.Cookies["motocycleId"];
            ViewPage data = new ViewPage
            {
                Cities = await _dbContext.Cities.ToListAsync(),
                ViewAnnouncesVip = await _dataFind.GetMotocycles(carsSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetMotocycles(carsSearch, "last", 0, 16),
                MotocycleBodyTypes=await _dbContext.MotocycleBodyTypes.ToListAsync(),
                MotocycleMakes=await _dbContext.MotocycleMakes.ToListAsync(),
                ConditionCredit = carsSearch.ConditionCredit,
                ConditionBarter = carsSearch.ConditionBarter
            };

            return View(data);
        }
        [Route("all/[controller]/announce-motocycle")]
        public async Task<IActionResult> AnnounceMotocycle(int id, string unicode)
        {
            var motocycle = await _dataFind.GetMotocycle(id,unicode);
            return View(motocycle);
        }
        [Route("all/[controller]/type-motocycle")]
        public async Task<IActionResult> TypeMotocycleAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceMotocycleIds= Request.Cookies["motocycleId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetCars(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetCars(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetCars(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                    }
                };
            }

            commonData.Pagination.ControllerName = "transport";
            commonData.Pagination.ActionName = "type-motocycle";
            return View(commonData);
        }
        //====================motocycle end

        //====================accessory start
        public async Task<IActionResult> Accessories(ViewPage carsSearch)
        {
            HttpContext.Session.SetString("compair", "");
            carsSearch.announceAccessoryIds = Request.Cookies["accessoryId"];
            ViewPage data = new ViewPage
            {
                Cities = await _dbContext.Cities.ToListAsync(),
                ViewAnnouncesVip = await _dataFind.GetAccessories(carsSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetAccessories(carsSearch, "last", 0, 16),
                AccessoryTypes=await _dbContext.AccessoryTypes.ToListAsync(),
                ConditionCredit = carsSearch.ConditionCredit,
                ConditionBarter = carsSearch.ConditionBarter
            };

            return View(data);
        }
        [Route("all/[controller]/announce-accessory")]
        public async Task<IActionResult> AnnounceAccessory(int id, string unicode)
        {
            var accessory = await _dataFind.GetAccessory(id,unicode);
            return View(accessory);
        }
        [Route("all/[controller]/type-accessory")]
        public async Task<IActionResult> TypeAccessoryAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();

            commonData.announceAccessoryIds= Request.Cookies["accessoryId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetCars(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                    }
                };
            }

            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetCars(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                    }
                };
            }

            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetCars(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetCars(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                    }
                };
            }
            commonData.Pagination.ControllerName = "transport";
            commonData.Pagination.ActionName = "type-accessory";
            return View(commonData);
        }
        //====================accessory end
    }
}