using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Areas.Admin.Models.Settings;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForJob;
using FirstRealProject.Models.PagesModels;
using FirstRealProject.Models.Real_Estates.ApartmentModels;
using FirstRealProject.Models.Real_Estates.Commons;
using FirstRealProject.Models.Real_Estates.HouseModels;
using FirstRealProject.Models.Real_Estates.OfficeModels;
using FirstRealProject.Models.Transports.AccessoryModels;
using FirstRealProject.Models.Transports.BusModels;
using FirstRealProject.Models.Transports.CarModels;
using FirstRealProject.Models.Transports.MotocycleModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SettingController : Controller
    {
        public FirstRealProjectDbContext _dbContext { get; set; }
        public SettingController(FirstRealProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            SettingModel setting = new SettingModel
            {
                CarMakes = await _dbContext.CarMakes.ToListAsync(),
                CarModels = await _dbContext.CarModels.ToListAsync(),
                CarBodyTypes = await _dbContext.CarBodyTypes.ToListAsync(),
                BusMakes = await _dbContext.BusMakes.ToListAsync(),
                BusBodyTypes = await _dbContext.BusBodyTypes.ToListAsync(),
                MotocycleMakes = await _dbContext.MotocycleMakes.ToListAsync(),
                MotocycleBodyTypes = await _dbContext.MotocycleBodyTypes.ToListAsync(),
                AccessoryTypes = await _dbContext.AccessoryTypes.ToListAsync(),
                JobActivityAreas = await _dbContext.ActivityAreas.ToListAsync(),
                ApartmentTypes = await _dbContext.ApartmentTypes.ToListAsync(),
                HouseTypes = await _dbContext.HouseTypes.ToListAsync(),
                OfficeTypes = await _dbContext.OfficeTypes.ToListAsync(),
                JobTypes = await _dbContext.JobTypes.ToListAsync(),
                BusinessTypes = await _dbContext.BusinessTypes.ToListAsync(),
                Cities = await _dbContext.Cities.ToListAsync(),
                RETypes = await _dbContext.RSAnnounceTypes.ToListAsync(),
            };
            return View(setting);
        }
        //==================common start===================
        [HttpPost]
        public async Task<IActionResult> AddCity(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var city = new City
                    {
                        Name = name,
                    };

                    await _dbContext.Cities.AddAsync(city);

                    await _dbContext.SaveChangesAsync();

                    return Json(city);
                }
                catch (Exception)
                {
                    return Json("fail");
                }

            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCity(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var city = await _dbContext.Cities.FindAsync(id);

            if (city == null)
                return Json("fail");

            _dbContext.Cities.Remove(city);
            await _dbContext.SaveChangesAsync();
            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> AddREType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var rS = new RSAnnounceType
                    {
                        Name = name,
                    };

                    await _dbContext.RSAnnounceTypes.AddAsync(rS);

                    await _dbContext.SaveChangesAsync();

                    return Json(rS);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteREType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var rS = await _dbContext.RSAnnounceTypes.FindAsync(id);

            if (rS == null)
                return Json("fail");

            _dbContext.RSAnnounceTypes.Remove(rS);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================common end===================

        //==================car start===================
        [HttpPost]
        public async Task<IActionResult> AddCarMake(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var carMake = new CarMake
                    {
                        Name = name,
                    };

                    await _dbContext.CarMakes.AddAsync(carMake);

                    await _dbContext.SaveChangesAsync();

                    return Json(carMake);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
               
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCarMake(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var carMake = await _dbContext.CarMakes.FindAsync(id);

            if (carMake == null)
                return Json("fail");

            _dbContext.CarMakes.Remove(carMake);
            await _dbContext.SaveChangesAsync();
            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> AddCarModel(string name ,int makeId)
        {
            if(!String.IsNullOrEmpty(name) && makeId != 0)
            {
                try
                {
                    var carModel = new CarModel
                    {
                        Name = name,
                        CarMakeId = makeId,
                    };

                    await _dbContext.CarModels.AddAsync(carModel);

                    await _dbContext.SaveChangesAsync();

                    return Json(carModel);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCarModel(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var carModel = await _dbContext.CarModels.FindAsync(id);

            if (carModel == null)
                return Json("fail");

            _dbContext.CarModels.Remove(carModel);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> AddCarBodyType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var carBody = new CarBodyType
                    {
                        Name = name,
                    };

                    await _dbContext.CarBodyTypes.AddAsync(carBody);

                    await _dbContext.SaveChangesAsync();

                    return Json(carBody);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCarBodyType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var carBody = await _dbContext.CarBodyTypes.FindAsync(id);

            if (carBody == null)
                return Json("fail");

            _dbContext.CarBodyTypes.Remove(carBody);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================car end===================

        //==================bus start===================
       
             [HttpPost]
        public async Task<IActionResult> AddBusMake(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var busMake = new BusMake
                    {
                        Name = name,
                    };

                    await _dbContext.BusMakes.AddAsync(busMake);

                    await _dbContext.SaveChangesAsync();

                    return Json(busMake);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBusMake(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var busMake = await _dbContext.BusMakes.FindAsync(id);

            if (busMake == null)
                return Json("fail");

            _dbContext.BusMakes.Remove(busMake);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> AddBusBodyType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var busBody = new BusBodyType
                    {
                        Name = name,
                    };

                    await _dbContext.BusBodyTypes.AddAsync(busBody);

                    await _dbContext.SaveChangesAsync();

                    return Json(busBody);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBusBodyType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var busBody = await _dbContext.BusBodyTypes.FindAsync(id);

            if (busBody == null)
                return Json("fail");

            _dbContext.BusBodyTypes.Remove(busBody);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================bus end===================
        //==================motocycle start===================

        [HttpPost]
        public async Task<IActionResult> AddMotocycleBodyType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var motocycleBody = new MotocycleBodyType
                    {
                        Name = name,
                    };

                    await _dbContext.MotocycleBodyTypes.AddAsync(motocycleBody);

                    await _dbContext.SaveChangesAsync();

                    return Json(motocycleBody);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMotocycleBodyType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var motocycleBody = await _dbContext.MotocycleBodyTypes.FindAsync(id);

            if (motocycleBody == null)
                return Json("fail");

            _dbContext.MotocycleBodyTypes.Remove(motocycleBody);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        [HttpPost]
        public async Task<IActionResult> AddMotocycleMake(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var motocycleMake = new MotocycleMake
                    {
                        Name = name,
                    };

                    await _dbContext.MotocycleMakes.AddAsync(motocycleMake);

                    await _dbContext.SaveChangesAsync();

                    return Json(motocycleMake);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMotocycleMake(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var motocycleMake = await _dbContext.MotocycleMakes.FindAsync(id);

            if (motocycleMake == null)
                return Json("fail");

            _dbContext.MotocycleMakes.Remove(motocycleMake);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================motocycle end===================
        //==================accessory end===================
        [HttpPost]
        public async Task<IActionResult> AddAccessoryType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var accessoryType = new AccessoryType
                    {
                        Name = name,
                    };

                    await _dbContext.AccessoryTypes.AddAsync(accessoryType);

                    await _dbContext.SaveChangesAsync();

                    return Json(accessoryType);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAccessoryType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var accessoryType = await _dbContext.AccessoryTypes.FindAsync(id);

            if (accessoryType == null)
                return Json("fail");

            _dbContext.AccessoryTypes.Remove(accessoryType);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================accessory end===================

        //==================apartment start===================
        [HttpPost]
        public async Task<IActionResult> AddApartmentType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var apartmentType = new ApartmentType
                    {
                        Name = name,
                    };

                    await _dbContext.ApartmentTypes.AddAsync(apartmentType);

                    await _dbContext.SaveChangesAsync();

                    return Json(apartmentType);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteApartmentType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var apartmentType = await _dbContext.ApartmentTypes.FindAsync(id);

            if (apartmentType == null)
                return Json("fail");

            _dbContext.ApartmentTypes.Remove(apartmentType);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================apartment end===================

        //==================house start===================
        [HttpPost]
        public async Task<IActionResult> AddHouseType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var houseType = new HouseType
                    {
                        Name = name,
                    };

                    await _dbContext.HouseTypes.AddAsync(houseType);

                    await _dbContext.SaveChangesAsync();

                    return Json(houseType);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteHouseType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var houseType = await _dbContext.HouseTypes.FindAsync(id);

            if (houseType == null)
                return Json("fail");

            _dbContext.HouseTypes.Remove(houseType);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================house end===================

        //==================office start===================
        [HttpPost]
        public async Task<IActionResult> AddOfficeType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var officeType = new OfficeType
                    {
                        Name = name,
                    };

                    await _dbContext.OfficeTypes.AddAsync(officeType);

                    await _dbContext.SaveChangesAsync();

                    return Json(officeType);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteOfficeType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var officeType = await _dbContext.OfficeTypes.FindAsync(id);

            if (officeType == null)
                return Json("fail");

            _dbContext.OfficeTypes.Remove(officeType);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================office end===================

        //==================job start===================
        [HttpPost]
        public async Task<IActionResult> AddJobActivityArea(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var activityArea = new ActivityArea
                    {
                        Name = name,
                    };

                    await _dbContext.ActivityAreas.AddAsync(activityArea);

                    await _dbContext.SaveChangesAsync();

                    return Json(activityArea);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteJobActivityArea(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var activityArea = await _dbContext.ActivityAreas.FindAsync(id);

            if (activityArea == null)
                return Json("fail");

            _dbContext.ActivityAreas.Remove(activityArea);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }

        [HttpPost]
        public async Task<IActionResult> AddJobType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var jobType = new JobType
                    {
                        Name = name,
                    };

                    await _dbContext.JobTypes.AddAsync(jobType);

                    await _dbContext.SaveChangesAsync();

                    return Json(jobType);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteJobType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var jobType = await _dbContext.JobTypes.FindAsync(id);

            if (jobType == null)
                return Json("fail");

            _dbContext.JobTypes.Remove(jobType);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================job end===================


        //==================business start===================
        [HttpPost]
        public async Task<IActionResult> AddBusinessType(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    var businessType = new BusinessType
                    {
                        Name = name,
                    };

                    await _dbContext.BusinessTypes.AddAsync(businessType);

                    await _dbContext.SaveChangesAsync();

                    return Json(businessType);
                }
                catch (Exception)
                {
                    return Json("fail");
                }
            }
            return Json("fail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBusinessType(int? id)
        {
            if (id == 0 && id == null)
                return Json("fail");

            var businessType = await _dbContext.BusinessTypes.FindAsync(id);

            if (businessType == null)
                return Json("fail");

            _dbContext.BusinessTypes.Remove(businessType);
            await _dbContext.SaveChangesAsync();

            return Json("success");
        }
        //==================business end===================
    }
}