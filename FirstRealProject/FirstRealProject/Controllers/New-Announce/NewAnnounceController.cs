using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForFoodModels;
using FirstRealProject.Models.Jobs.ForJobModels;
using FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce;
using FirstRealProject.Models.Real_Estates.ApartmentModels;
using FirstRealProject.Models.Real_Estates.GarageModels;
using FirstRealProject.Models.Real_Estates.HouseModels;
using FirstRealProject.Models.Real_Estates.LandModels;
using FirstRealProject.Models.Real_Estates.OfficeModels;
using FirstRealProject.Models.Transports.AccessoryModels;
using FirstRealProject.Models.Transports.BusModels;
using FirstRealProject.Models.Transports.CarModels;
using FirstRealProject.Models.Transports.MotocycleModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace FirstRealProject.Controllers.NewAnnounce
{
    [Route("all/new-announce/[action]")]
    public class NewAnnounceController : Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }
        private IAnnounceToAdd _announceToAdd { get; set; }
        public static List<string> filesPaths = new List<string>();
        private IHostingEnvironment _hostingEnvironment { get; set; }

        public NewAnnounceController(FirstRealProjectDbContext dbContext, IHostingEnvironment hostingEnvironment, IFindAnnounce dataFind, IAnnounceToAdd announceToAdd)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
            _announceToAdd = announceToAdd;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Index(NewAnnounceCreateModel mode)
        {
            if (ModelState.IsValid)
            {

            }
            return View(await _dataFind.SettingDataAsync());
        }

        public async Task<IActionResult> Car()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Car(CarAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddCar(announce);
                if (!t)
                {
                    DeleteFile(filesPaths);
                }

            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync("", announce.CarMakeId));
        }

        public async Task<IActionResult> Bus()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Bus(BusAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddBus(announce);
                if (!t)
                {
                DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }

            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Motocycle()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Motocycle(MotocycleAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddMotocycle(announce);
                if (!t)
                {
                DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Accessory()
        {

            return View(await _dataFind.SettingDataAsync());

        }


        [HttpPost]
        public async Task<IActionResult> Accessory(AccessoryAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddAccessory(announce);
                if (!t)
                {
                DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Apartment()
        {

            return View(await _dataFind.SettingDataAsync());

        }

       
        [HttpPost]
        public async Task<IActionResult> Apartment(ApartmentAnnounceModel announce,List<string> filess)
        {
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddApartment(announce);
                if (!t)
                {
                    DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View( _dataFind.SettingDataAsync());
        }
       

        public async Task<IActionResult> House()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> House(HouseAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddHouse(announce);
                if (!t)
                {
                    DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Office()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Office(OfficeAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddOffice(announce);
                if (!t)
                {
                    DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Land()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Land(LandAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddLand(announce);
                if (!t)
                {
                    DeleteFile(filesPaths);
                }
                
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Qarage()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Qarage(QarageAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddQarage(announce);
                if (!t)
                {
                DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Job()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Job(JobAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddJob(announce);
                if (!t)
                {
                DeleteFile(filesPaths);
                }
            filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Food()
        {

            return View(await _dataFind.SettingDataAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Food(FoodAnnounceModel announce)
        {
            
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddFood(announce);
                if (!t)
                {
                    DeleteFile(filesPaths);
                }
                filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }


        public async Task<IActionResult> Business()
        {


            return View(await _dataFind.SettingDataAsync());


        }

        [HttpPost]
        public async Task<IActionResult> Business(BusinessAnnounceModel announce)
        {
            if (ModelState.IsValid)
            {
                announce.Paths = filesPaths;
                var t = await _announceToAdd.AddBuisness(announce);
                if (!t)
                {
                    DeleteFile(filesPaths);
                }
                filesPaths.Clear();
                return RedirectToAction("Index", "Home");
            }
            DeleteFile(filesPaths);
            return View(await _dataFind.SettingDataAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> filess)
        {
            if (filess != null && filess.Count > 0)
            {
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                foreach (IFormFile item in filess)
                {
                    if (item.Length > 0)
                    {
                        string filesub = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_");
                        string fileName = filesub + ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        string fullPath = Path.Combine(newPath, fileName);
                        filesPaths.Add(fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                    }
                }
            }
            return Json("success");

        }

        public async void DeleteFile(List<string> deletePaths)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string path = Path.Combine(webRootPath,"Upload");
            foreach (var item in deletePaths)
            {
                var filePath = Path.Combine(path, item);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }
            filesPaths.Clear();
        }

        public async Task<IActionResult> Between()
        {

            return View(await _dataFind.SettingDataAsync());

        }


        [HttpPost]
        public async Task<IActionResult> Between(NewAnnounceCreateModel announce)
        {
            if (ModelState.IsValid)
            {

            }
            return View(await _dataFind.SettingDataAsync());
        }

    }
}