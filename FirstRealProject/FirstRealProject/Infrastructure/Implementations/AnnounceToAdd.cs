using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForFoodModels;
using FirstRealProject.Models.Jobs.ForJob;
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
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstRealProject.Models.Commons;

namespace FirstRealProject.Infrastructure.Implementations
{
    public class AnnounceToAdd : IAnnounceToAdd
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IHostingEnvironment _hostingEnvironment { get; set; }

        public AnnounceToAdd(FirstRealProjectDbContext dbContext,IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> AddCar(CarAnnounceModel announce)
        {
            try
            {
                CarMake carMake = await _dbContext.CarMakes.FindAsync(announce.CarMakeId);
                CarModel carModel = await _dbContext.CarModels.FindAsync(announce.CarModelId);
                DateTime addedDate = DateTime.Now;

                Car unicodeCar = await _dbContext.Cars.FindAsync(_dbContext.Cars.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeCar.AnnounceUniqueCode) + 1).ToString();

                Car car = new Car(carMake, carModel, announce.CarYear)
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    CarBodyTypeId = announce.CarBodyTypeId,
                    CarKilometer = announce.CarKilometer,
                    CarMotor = announce.CarMotor,
                    CarMotorStrength = announce.CarMotorStrength,
                    Color = announce.Color,
                    Condition = announce.CarCondition,
                    AnnounceUniqueCode = unicode,
                    TransmissionId = announce.TransmissionId,
                    SpeedBoxId = announce.SpeedBoxId,
                    FuelTypeId = announce.FuelTypeId,
                };
                await _dbContext.Cars.AddAsync(car);

                foreach (var autoEquipmentId in announce.AutoEquipmentId)
                {
                    CarAutoEquipment carAutoEquipment = new CarAutoEquipment
                    {
                        CarId = car.Id,
                        AutoEquipmentId = autoEquipmentId,
                    };
                    await _dbContext.CarAutoEquipments.AddAsync(carAutoEquipment);
                }

                //car files upload start
                AddDataPhoto(announce.Paths,car.Id,"lib/images/transport/car",FindTable.Car);

                
                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

      

        public async Task<bool> AddBus(BusAnnounceModel announce)
        {
            try
            {
                BusBodyType bodyType = await _dbContext.BusBodyTypes.FindAsync(announce.BusBodyTypeId);
                DateTime addedDate = DateTime.Now;

                Bus unicodeAnnounce = await _dbContext.Buses.FindAsync(_dbContext.Buses.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Bus bus = new Bus(bodyType, announce.BusYear)
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    BusKilometer = announce.BusKilometer,
                    BusMakeId = announce.BusMakeId,
                    Condition = announce.BusCondition,
                    AnnounceUniqueCode = unicode,
                };
                await _dbContext.Buses.AddAsync(bus);
                //car files upload start
                AddDataPhoto(announce.Paths, bus.Id, "lib/images/transport/car", FindTable.Bus);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddMotocycle(MotocycleAnnounceModel announce)
        {
            try
            {
                MotocycleBodyType bodyType = await _dbContext.MotocycleBodyTypes.FindAsync(announce.MotocycleBodyTypeId);
                MotocycleMake make = await _dbContext.MotocycleMakes.FindAsync(announce.MotocycleMakeId);
                DateTime addedDate = DateTime.Now;

                Motocycle unicodeAnnounce = await _dbContext.Motocycles.FindAsync(_dbContext.Motocycles.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Motocycle motocycle = new Motocycle(bodyType,make,announce.MotocycleYear)
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    Condition = announce.MotocycleCondition,
                    MotocycleBodyTypeId = announce.MotocycleBodyTypeId,
                    MotocycleKilometer = announce.MotocycleKilometer,
                    MotocycleModel = announce.MotocycleModel,
                    AnnounceUniqueCode = unicode,
                    MotocycleMotor = announce.MotocycleMotor,

                };
                await _dbContext.Motocycles.AddAsync(motocycle);
                //car files upload start
                AddDataPhoto(announce.Paths, motocycle.Id, "lib/images/transport/motocycle", FindTable.Motocycle);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddAccessory(AccessoryAnnounceModel announce)
        {
            try
            {
                DateTime addedDate = DateTime.Now;

                Accessory unicodeAnnounce = await _dbContext.Accessories.FindAsync(_dbContext.Accessories.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Accessory accessory = new Accessory
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    AccessoryTypeId = announce.AccessoryTypeId,
                    AnnounceName = announce.AccessoryName,
                    AnnounceUniqueCode = unicode,
                    Condition = announce.AccessoryCondition,
                };
                await _dbContext.Accessories.AddAsync(accessory);
                //car files upload start
                AddDataPhoto(announce.Paths, accessory.Id, "lib/images/transport/accessory", FindTable.Accessory);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddApartment(ApartmentAnnounceModel announce)
        {
            try
            {
                DateTime addedDate = DateTime.Now;

                Apartment unicodeAnnounce = await _dbContext.Apartments.FindAsync(_dbContext.Apartments.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Apartment apartment = new Apartment(announce.ApartmentRoomCount, announce.ApartamentLocation, announce.ApartmentArea)
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    ApartmentTypeId = announce.ApartmentTypeId,
                    AnnounceUniqueCode = unicode,
                    RSAnnounceTypeId = announce.RSAnnounceTypeId,

                };

                await _dbContext.Apartments.AddAsync(apartment);
                //car files upload start
                AddDataPhoto(announce.Paths, apartment.Id, "lib/images/realestate/apartment", FindTable.Apartment);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddHouse(HouseAnnounceModel announce)
        {
            try
            {
                HouseType houseType = await _dbContext.HouseTypes.FindAsync(announce.HouseTypeId);
                DateTime addedDate = DateTime.Now;

                House unicodeAnnounce = await _dbContext.Houses.FindAsync(_dbContext.Houses.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                House house = new House(houseType,announce.HouseLocation)
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    AnnounceUniqueCode = unicode,
                     RSAnnounceTypeId=announce.HouseRSAnnounceTypeId,


                };

                await _dbContext.Houses.AddAsync(house);
                //car files upload start
                AddDataPhoto(announce.Paths, house.Id, "lib/images/realestate/house", FindTable.House);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddQarage(QarageAnnounceModel announce)
        {
            try
            {
                DateTime addedDate = DateTime.Now;

                Garage unicodeAnnounce = await _dbContext.Garages.FindAsync(_dbContext.Garages.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Garage garage = new Garage
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    AnnounceUniqueCode = unicode,
                    AnnounceName=announce.GarageName,
                    GarageLocation=announce.GarageLocation
                };


                await _dbContext.Garages.AddAsync(garage);
                //car files upload start
                AddDataPhoto(announce.Paths, garage.Id, "lib/images/realestate/garage", FindTable.Garage);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddLand(LandAnnounceModel announce)
        {
            try
            {
                DateTime addedDate = DateTime.Now;

                Land unicodeAnnounce = await _dbContext.Lands.FindAsync(_dbContext.Lands.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Land land = new Land(announce.LandArea,announce.LandLocation)
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    AnnounceUniqueCode = unicode,
                    PhoneNumber = announce.PhoneNumber,
                };

                await _dbContext.Lands.AddAsync(land);
                //car files upload start
                AddDataPhoto(announce.Paths, land.Id, "lib/images/realestate/land", FindTable.Land);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddOffice(OfficeAnnounceModel announce)
        {
            try
            {
                OfficeType officeType = await _dbContext.OfficeTypes.FindAsync(announce.OfficeTypeId);
                DateTime addedDate = DateTime.Now;

                Office unicodeAnnounce = await _dbContext.Offices.FindAsync(_dbContext.Offices.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Office office = new Office(officeType,announce.OfficeLocation,51)
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    AnnounceUniqueCode = unicode,
                    PhoneNumber = announce.PhoneNumber,
                    RSAnnounceTypeId=announce.OfficeRSAnnounceTypeId

                };

                await _dbContext.Offices.AddAsync(office);
                //car files upload start
                AddDataPhoto(announce.Paths, office.Id, "lib/images/realestate/office", FindTable.Office);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddJob(JobAnnounceModel announce)
        {
            try
            {
                DateTime addedDate = DateTime.Now;

                Job unicodeAnnounce = await _dbContext.Jobs.FindAsync(_dbContext.Jobs.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Job job = new Job
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    AnnounceName=announce.JobName,
                    ActivityAreaId=announce.JobActivityAreaId,
                    AnnounceUniqueCode = unicode,
                    JobTypeId=announce.JobTypeId,
                };

                await _dbContext.Jobs.AddAsync(job);
                //car files upload start
                AddDataPhoto(announce.Paths, job.Id, "lib/images/jobs/job", FindTable.Job);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddBuisness(BusinessAnnounceModel announce)
        {
            try
            {
                DateTime addedDate = DateTime.Now;

                BusinessEquipment unicodeAnnounce = await _dbContext.BusinessEquipments.FindAsync(_dbContext.BusinessEquipments.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                BusinessEquipment businessEquipment = new BusinessEquipment
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                     AnnounceName=announce.BusinessName,
                     BusinessTypeId=announce.BusinessTypeId,
                    AnnounceUniqueCode = unicode,
                };

                await _dbContext.BusinessEquipments.AddAsync(businessEquipment);
                //car files upload start
                AddDataPhoto(announce.Paths, businessEquipment.Id, "lib/images/jobs/business", FindTable.Business);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public async Task<bool> AddFood(FoodAnnounceModel announce)
        {
            try
            {
                DateTime addedDate = DateTime.Now;

                Food unicodeAnnounce = await _dbContext.Foods.FindAsync(_dbContext.Foods.Max(c => c.Id));
                string unicode = (Int32.Parse(unicodeAnnounce.AnnounceUniqueCode) + 1).ToString();

                Food food = new Food
                {
                    AnnounceAddedDate = addedDate,
                    AnnounceTypeId = announce.AnnounceTypeId,
                    Price = announce.Price,
                    CityId = announce.CityId,
                    Description = announce.Description,
                    PersonTypeId = announce.PersonTypeId,
                    Email = announce.Email,
                    PhoneNumber = announce.PhoneNumber,
                    AnnounceName=announce.FoodName,
                    AnnounceUniqueCode = unicode,

                };

                await _dbContext.Foods.AddAsync(food);
                //car files upload start
                 AddDataPhoto(announce.Paths, food.Id, "lib/images/jobs/food", FindTable.Food);


                //car files upload end
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }



        //Upload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="id">required</param>
        /// <param name="addPath">example: lib/images/transport/car</param>
        /// <param name="announceName"></param>
        /// <returns></returns>
        public void AddDataPhoto(List<string> files, int id, string addPath, FindTable announceName)
        {
            addPath= "upload";
            foreach (var fileName in files)
            {
                switch (announceName.ToString().ToLower())
                {
                    case "car":
                        _dbContext.CarPhotos.Add(new CarPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            CarId = id,
                        });
                        break;
                    case "bus":
                        BusPhoto busPhoto = new BusPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            BusId = id,
                        };
                        _dbContext.BusPhotos.Add(busPhoto);
                        break;
                    case "motocycle":
                        _dbContext.MotocyclePhotos.Add(new MotocyclePhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            MotocycleId = id,
                        });
                        break;
                    case "accessory":
                        _dbContext.AccessoryPhotos.Add(new AccessoryPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            AccessoryId = id,
                        });
                        break;
                    case "apartment":
                        _dbContext.ApartmentPhotos.Add(new ApartmentPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            ApartmentId = id,
                        });
                        break;
                    case "house":
                        _dbContext.HousePhotos.Add(new HousePhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            HouseId = id,
                        });
                        break;
                    case "office":
                        _dbContext.OfficePhotos.Add(new OfficePhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            OfficeId = id,
                        });
                        break;
                    case "garage":
                        _dbContext.GaragePhotos.Add(new GaragePhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            GarageId = id,
                        });
                        break;
                    case "land":
                        _dbContext.LandPhotos.Add(new LandPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            LandId = id,
                        });
                        break;
                    case "job":
                        _dbContext.JobPhotos.Add(new JobPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            JobId = id,
                        });
                        break;
                    case "business":
                        _dbContext.BusinessEPhotos.Add(new BusinessEPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            BusinessEquipmentId = id,
                        });
                        break;
                    case "food":
                        _dbContext.FoodPhotos.Add(new FoodPhoto
                        {
                            Path = "/" + addPath + "/" + fileName,
                            FoodId = id,
                        });
                        break;
                    default:
                        break;
                }
            }
        }

        public async Task<bool> AddContact(Comment contact)
        {
            try
            {
                contact.SendDate = DateTime.Now;
                await _dbContext.Comments.AddAsync(contact);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public void UploadPhoto(ICollection<IFormFile> files,int id,string addPath,FindTable announceName)
        //{
        //    if (files != null && files.Count != 0)
        //    {
        //        string webRootPath = _hostingEnvironment.WebRootPath;

        //        string[] p = addPath.Split('/');
        //        string path = Path.Combine(webRootPath);
        //        foreach (var item in p)
        //        {
        //            path = Path.Combine(path,item);
        //        }

        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        foreach (IFormFile file in files)
        //        {
        //            if (file.Length > 0)
        //            {
        //                string filesub = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_");
        //                string fileName =filesub + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //                string fullPath = Path.Combine(path, fileName);

        //                using (FileStream fileStream = File.Create(fullPath))
        //                {
        //                    switch (announceName.ToString().ToLower())
        //                    {
        //                        case "car":
        //                             _dbContext.CarPhotos.Add(new CarPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                CarId = id,
        //                            });
        //                            break;
        //                        case "bus":
        //                            BusPhoto busPhoto = new BusPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                BusId = id,
        //                            };
        //                             _dbContext.BusPhotos.Add(busPhoto);
        //                            break;
        //                        case "motocycle":
        //                             _dbContext.MotocyclePhotos.Add(new MotocyclePhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                MotocycleId = id,
        //                            });
        //                            break;
        //                        case "accessory":
        //                             _dbContext.AccessoryPhotos.Add(new AccessoryPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                AccessoryId = id,
        //                            });
        //                            break;
        //                        case "apartment":
        //                             _dbContext.ApartmentPhotos.Add(new ApartmentPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                ApartmentId = id,
        //                            });
        //                            break;
        //                        case "house":
        //                             _dbContext.HousePhotos.Add(new HousePhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                HouseId = id,
        //                            });
        //                            break;
        //                        case "office":
        //                             _dbContext.OfficePhotos.Add(new OfficePhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                OfficeId = id,
        //                            });
        //                            break;
        //                        case "garage":
        //                             _dbContext.GaragePhotos.Add(new GaragePhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                GarageId = id,
        //                            });
        //                            break;
        //                        case "land":
        //                             _dbContext.LandPhotos.Add(new LandPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                LandId = id,
        //                            });
        //                            break;
        //                        case "job":
        //                             _dbContext.JobPhotos.Add(new JobPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                JobId = id,
        //                            });
        //                            break;
        //                        case "business":
        //                             _dbContext.BusinessEPhotos.Add(new BusinessEPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                BusinessEquipmentId = id,
        //                            });
        //                            break;
        //                        case "food":
        //                             _dbContext.FoodPhotos.Add(new FoodPhoto
        //                            {
        //                                Path = "/" + addPath + "/" + fileName,
        //                                FoodId = id,
        //                            });
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                    file.CopyTo(fileStream);
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
