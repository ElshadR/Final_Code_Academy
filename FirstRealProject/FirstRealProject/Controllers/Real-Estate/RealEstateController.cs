using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Controllers.Real_Estate
{
    public class RealEstateController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }
        private UserManager<AppUser> _userManager;

        public RealEstateController(FirstRealProjectDbContext dbContext, IFindAnnounce dataFind, UserManager<AppUser> userMgr)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
            _userManager = userMgr;
        }

        [Route("all/real-estate/index")]
        public async Task<IActionResult> Index(ViewPage viewSearch)
        {
            HttpContext.Session.SetString("compair", "");
            viewSearch.announceApartmentIds = Request.Cookies["apartmentId"];
            viewSearch.announceHouseIds= Request.Cookies["houseId"];
            viewSearch.announceOfficeIds= Request.Cookies["officeId"];
            viewSearch.announceGarageIds= Request.Cookies["garageId"];
            viewSearch.announceLandIds= Request.Cookies["landId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetRealEstates(viewSearch, "vip elan", 0, 7),
                LastAnnounces = await _dataFind.GetRealEstates(viewSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
            };

            return View(data);
        }

        [Route("all/real-estate/type-all")]
        public async Task<IActionResult> TypeAllAnnounce(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceApartmentIds = Request.Cookies["apartmentId"];
            commonData.announceHouseIds = Request.Cookies["houseId"];
            commonData.announceOfficeIds = Request.Cookies["officeId"];
            commonData.announceGarageIds = Request.Cookies["garageId"];
            commonData.announceLandIds = Request.Cookies["landId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetRealEstates(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetRealEstates(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-all"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetRealEstates(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetRealEstates(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-all"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetRealEstates(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetRealEstates(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-all"
                    }
                };
            }

            commonData.Pagination.ControllerName = "real-estate";
            commonData.Pagination.ActionName = "type-all";
            return View(commonData);
        }
        //====================apartment start
        [Route("all/real-estate/apartments")]
        public async Task<IActionResult> Apartments(ViewPage viewSearch)
        {
            HttpContext.Session.SetString("compair", "");
            viewSearch.announceApartmentIds = Request.Cookies["apartmentId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetApartments(viewSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetRealEstates(viewSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
                ApartmentTypes = await _dbContext.ApartmentTypes.ToListAsync(),
                RSAnnounceTypes=await _dbContext.RSAnnounceTypes.ToListAsync(),
            };
            return View(data);
        }
        [Route("all/real-estate/announce-apartment")]
        public async Task<IActionResult> AnnounceApartment(int id, string unicode)
        {
            var data = await _dataFind.GetApartment(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-appartment")]
        public async Task<IActionResult> TypeApartmentAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceApartmentIds = Request.Cookies["apartmentId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetApartments(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetApartments(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-apartment"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetApartments(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetApartments(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-apartment"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetApartments(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetApartments(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-apartment"
                    }
                };
            }

            commonData.Pagination.ControllerName = "real-estate";
            commonData.Pagination.ActionName = "type-apartment";
            return View(commonData);
        }
        //====================apartment end

        //====================house start

        [Route("all/real-estate/houses-villas")]
        public async Task<IActionResult> HousesVillas(ViewPage viewSearch)
        {
            HttpContext.Session.SetString("compair", "");
            viewSearch.announceHouseIds = Request.Cookies["houseId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetHouses(viewSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetRealEstates(viewSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
                HouseTypes = await _dbContext.HouseTypes.ToListAsync(),
                RSAnnounceTypes = await _dbContext.RSAnnounceTypes.ToListAsync(),
            };
            return View(data);
        }
        [Route("all/real-estate/announce-house")]
        public async Task<IActionResult> AnnounceHouse(int id, string unicode)
        {
            var data = await _dataFind.GetHouse(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-house")]
        public async Task<IActionResult> TypeHouseAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceHouseIds= Request.Cookies["houseId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetHouses(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetHouses(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-house"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetHouses(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetHouses(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-house"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetHouses(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetHouses(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-house"
                    }
                };
            }

            commonData.Pagination.ControllerName = "real-estate";
            commonData.Pagination.ActionName = "type-house";
            return View(commonData);
        }
        //=================house end
        [Route("all/real-estate/commercials")]
        public async Task<IActionResult> Commercials(ViewPage viewSearch)
        {
            HttpContext.Session.SetString("compair", "");
            viewSearch.announceOfficeIds = Request.Cookies["officeId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetOffices(viewSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetRealEstates(viewSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
                OfficeTypes = await _dbContext.OfficeTypes.ToListAsync(),
                RSAnnounceTypes = await _dbContext.RSAnnounceTypes.ToListAsync(),
            };
            return View(data);
        }
        [Route("all/real-estate/announce-office")]
        public async Task<IActionResult> AnnounceOffice(int id, string unicode)
        {
            var data = await _dataFind.GetOffice(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-commercial")]
        public async Task<IActionResult> TypeCommercialAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceOfficeIds= Request.Cookies["officeId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetOffices(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetOffices(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-commercial"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetOffices(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetOffices(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-commercial"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetOffices(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetOffices(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-commercial"
                    }
                };
            }

            commonData.Pagination.ControllerName = "real-estate";
            commonData.Pagination.ActionName = "type-commercial";
            return View(commonData);
        }
        //=================commercial end

        [Route("all/real-estate/lands")]
        public async Task<IActionResult> Lands(ViewPage viewSearch)
        {
            HttpContext.Session.SetString("compair", "");
            viewSearch.announceLandIds = Request.Cookies["landId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetLands(viewSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetRealEstates(viewSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
            };
            return View(data);
        }
        [Route("all/real-estate/announce-land")]
        public async Task<IActionResult> AnnounceLand(int id, string unicode)
        {
            var data = await _dataFind.GetLand(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-land")]
        public async Task<IActionResult> TypelandAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceLandIds= Request.Cookies["landId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetLands(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetLands(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName="real-estate",
                        ActionName="type-land"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetLands(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetLands(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-land"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetLands(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetLands(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-land"
                    }
                };
            }

            commonData.Pagination.ControllerName = "real-estate";
            commonData.Pagination.ActionName = "type-land";
            return View(commonData);
        }
        //=================land end

        [Route("all/real-estate/garages")]
        public async Task<IActionResult> Garages(ViewPage viewSearch)
        {
            HttpContext.Session.SetString("compair", "");
            viewSearch.announceGarageIds = Request.Cookies["garageId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetGarages(viewSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetRealEstates(viewSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
            };
            return View(data);
        }
        [Route("all/real-estate/announce-garage")]
        public async Task<IActionResult> AnnounceGarage(int id, string unicode)
        {
            var data = await _dataFind.GetGarage(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-garage")]
        public async Task<IActionResult> TypeGarageAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceGarageIds= Request.Cookies["garageId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetGarages(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetGarages(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-garage"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetGarages(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetGarages(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-garage"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetGarages(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetGarages(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName="real-estate",
                        ActionName= "type-garage"
                    }
                };
            }

            commonData.Pagination.ControllerName = "real-estate";
            commonData.Pagination.ActionName = "type-garage";
            return View(commonData);
        }
        //=================garage end
    }
}