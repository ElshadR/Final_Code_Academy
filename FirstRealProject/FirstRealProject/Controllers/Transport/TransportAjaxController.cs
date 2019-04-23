using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using FirstRealProject.Models.Transports.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Controllers.Transport
{
    public class TransportAjaxController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }

        public TransportAjaxController(FirstRealProjectDbContext dbContext, IFindAnnounce dataFind)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
        }

        [Route("all/[controller]/transport")]
        public async Task<IActionResult> TransportAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetTransports(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-car")]
        public async Task<IActionResult> SimpleAnnounce(ViewPage viewPage,int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetCars(viewPage,"last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }

        [Route("all/[controller]/simple-bus")]
        public async Task<IActionResult> SimpleBusAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetBuses(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-motocycle")]
        public async Task<IActionResult> SimpleMotocycleAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetMotocycles(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-accessory")]
        public async Task<IActionResult> SimpleAccessoryAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-apartment")]
        public async Task<IActionResult> SimpleApartmentAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-house")]
        public async Task<IActionResult> SimpleHouseAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-office")]
        public async Task<IActionResult> SimpleOfficeAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-garage")]
        public async Task<IActionResult> SimpleGarageAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-land")]
        public async Task<IActionResult> SimpleLandAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-job")]
        public async Task<IActionResult> SimpleJobAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-business")]
        public async Task<IActionResult> SimpleBusinessAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }
        [Route("all/[controller]/simple-food")]
        public async Task<IActionResult> SimpleFoodAnnounce(ViewPage viewPage, int page, int count)
        {
            IEnumerable<ViewAnnounce> data = await _dataFind.GetAccessories(viewPage, "last", page * count, count);

            if (data.Count() == 0)
                return Json("stop");

            return PartialView("~/Views/Shared/Partial/_AnnouncePartial.cshtml", data);
        }


        [HttpPost]
        [Route("all/[controller]/getmodel")]
        public async Task<IActionResult> Models(int makeId)
        {
            IEnumerable<CarModel> data = await _dbContext.CarModels.Where(c => c.CarMakeId == makeId).ToListAsync();
            if (data.Count() == 0)
                return Json("");
           

            return PartialView("~/Views/Shared/Partial/_CarModelPartial.cshtml", data);
        }
    }
}