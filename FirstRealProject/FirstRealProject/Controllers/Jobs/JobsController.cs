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

namespace FirstRealProject.Controllers.Job
{
    public class JobsController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }
        private UserManager<AppUser> _userManager;

        public JobsController(FirstRealProjectDbContext dbContext, IFindAnnounce dataFind, UserManager<AppUser> userMgr)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
            _userManager = userMgr;
        }

        public async Task<IActionResult> Index(ViewPage carsSearch)
        {
            HttpContext.Session.SetString("compair", "");
            carsSearch.announceJobIds= Request.Cookies["jobId"];
            carsSearch.announceBusinessIds= Request.Cookies["businessId"];
            carsSearch.announceFoodIds= Request.Cookies["foodId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetJobAlls(carsSearch, "vip elan", 0, 7),
                LastAnnounces = await _dataFind.GetJobAlls(carsSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
            };

            return View(data);
        }
        [Route("all/jobs/type-all")]
        public async Task<IActionResult> TypeAllAnnounce(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceJobIds = Request.Cookies["jobId"];
            commonData.announceBusinessIds = Request.Cookies["businessId"];
            commonData.announceFoodIds = Request.Cookies["foodId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetJobAlls(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetJobAlls(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-all"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetJobAlls(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetJobAlls(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-all"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetJobAlls(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetJobAlls(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-all"
                    }
                };
            }

            commonData.Pagination.ControllerName = "jobs";
            commonData.Pagination.ActionName = "type-all";
            return View(commonData);
        }


        //==================job start
        public async Task<IActionResult> Jobs(ViewPage carsSearch)
        {
            HttpContext.Session.SetString("compair", "");
            carsSearch.announceJobIds = Request.Cookies["jobId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetJobs(carsSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetJobAlls(carsSearch, "last", 0, 8),
                ActivityAreas = await _dbContext.ActivityAreas.ToListAsync(),
                JobTypes = await _dbContext.JobTypes.ToListAsync(),
                Cities = await _dbContext.Cities.ToListAsync(),
            };

            return View(data);
        }
        [Route("all/jobs/announce-job")]
        public async Task<IActionResult> AnnounceJob(int id, string unicode)
        {
            var data = await _dataFind.GetJob(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-job")]
        public async Task<IActionResult> TypeJobAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceJobIds= Request.Cookies["jobId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetJobs(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetJobs(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-job"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetJobs(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetJobs(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-job"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetJobs(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetJobs(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-job"
                    }
                };
            }

            commonData.Pagination.ControllerName = "jobs";
            commonData.Pagination.ActionName = "type-job";
            return View(commonData);
        }
        //====================job end

        public async Task<IActionResult> Business(ViewPage carsSearch)
        {
            HttpContext.Session.SetString("compair", "");
            carsSearch.announceBusinessIds = Request.Cookies["businessId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetBusinesses(carsSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetJobAlls(carsSearch, "last", 0, 8),
                BusinessTypes=await _dbContext.BusinessTypes.ToListAsync(),
                Cities = await _dbContext.Cities.ToListAsync(),
            };

            return View(data);
        }
        [Route("all/jobs/announce-business")]
        public async Task<IActionResult> AnnounceBusiness(int id, string unicode)
        {
            var data = await _dataFind.GetBusiness(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-business")]
        public async Task<IActionResult> TypeBusinessAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceBusinessIds= Request.Cookies["businessId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetBusinesses(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetBusinesses(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-business"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetBusinesses(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetBusinesses(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-business"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetBusinesses(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetBusinesses(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-business"
                    }
                };
            }

            commonData.Pagination.ControllerName = "jobs";
            commonData.Pagination.ActionName = "type-business";
            return View(commonData);
        }
        //====================business end

        public async Task<IActionResult> Foods(ViewPage carsSearch)
        {
            HttpContext.Session.SetString("compair", "");
            carsSearch.announceFoodIds = Request.Cookies["foodId"];
            ViewPage data = new ViewPage
            {
                ViewAnnouncesVip = await _dataFind.GetFoods(carsSearch, "vip elan", 0, 3),
                LastAnnounces = await _dataFind.GetJobAlls(carsSearch, "last", 0, 8),
                Cities = await _dbContext.Cities.ToListAsync(),
            };

            return View(data);
        }
        [Route("all/jobs/announce-food")]
        public async Task<IActionResult> AnnounceFood(int id, string unicode)
        {
            var data = await _dataFind.GetFood(id,unicode);
            return View(data);
        }
        [Route("all/[controller]/type-food")]
        public async Task<IActionResult> TypeFoodAnnouence(string typeAnnounce, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = new List<ViewAnnounce>();
            IEnumerable<ViewAnnounce> data2 = new List<ViewAnnounce>();
            ViewPage commonData = new ViewPage();
            commonData.announceFoodIds= Request.Cookies["foodId"];
            if (typeAnnounce.ToLower().Trim() == "vip")
            {
                data = await _dataFind.GetFoods(commonData, "vip elan", page * count, count);
                data2 = await _dataFind.GetFoods(commonData, "vip elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesVip = data,
                    AnnounceTypeName = AnnounceTypeFind.Vip.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Vip.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-food"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "sade")
            {
                data = await _dataFind.GetFoods(commonData, "sade elan", page * count, count);
                data2 = await _dataFind.GetFoods(commonData, "sade elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesSimple = data,
                    AnnounceTypeName = AnnounceTypeFind.Sade.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Sade.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-food"
                    }
                };
            }
            else if (typeAnnounce.ToLower().Trim() == "premium")
            {
                data = await _dataFind.GetFoods(commonData, "premium elan", page * count, count);
                data2 = await _dataFind.GetFoods(commonData, "premium elan");
                commonData = new ViewPage
                {
                    ViewAnnouncesPremium = data,
                    AnnounceTypeName = AnnounceTypeFind.Premium.ToString(),
                    Pagination = new Pagination(data2.Count(), count, page)
                    {
                        AnnounceType = AnnounceTypeFind.Premium.ToString(),
                        ControllerName = "jobs",
                        ActionName = "type-food"
                    }
                };
            }

            commonData.Pagination.ControllerName = "jobs";
            commonData.Pagination.ActionName = "type-food";
            return View(commonData);
        }
        //====================food end
    }
}