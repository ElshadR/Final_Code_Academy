using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Jobs;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Transports.CarModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Implementations
{
    public  class UpdateAnnounce : IUpdateAnnounce
    {
        public FirstRealProjectDbContext _dbContext { get; set; }

        public UpdateAnnounce(FirstRealProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> UpdateCarA(CarEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Cars.FindAsync(editModel.Id);

                var make = await _dbContext.CarMakes.FindAsync(editModel.MakeId);
                var model = await _dbContext.CarModels.FindAsync(editModel.ModelId);

                if (make != null && model != null && editModel.Year != 0)
                    editModel.AnnounceName = make.Name + " " + model.Name + ", " + editModel.Year;
                else
                    return false;

                if (editModel.AnnounceCheckIn == true)
                {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin= await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode= (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                    if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    {
                        announce.AnnouncePublished = editModel.AnnouncePublished;
                        announce.AnnouncePublishDate = DateTime.Now;
                    }


                }
                else
                {
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                    announce.AnnouncePublished = false;
                    announce.AnnouncePublishDate = null;
                }



                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.BodyTypeId != 0 && editModel.BodyTypeId != announce.CarBodyTypeId)
                    announce.CarBodyTypeId = editModel.BodyTypeId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Color != null && editModel.Color != announce.Color)
                    announce.Color = editModel.Color;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;

                if (editModel.FuelTypeId != 0 && editModel.FuelTypeId != announce.FuelTypeId)
                    announce.FuelTypeId = editModel.FuelTypeId;

                if (editModel.Kilometer != 0 && editModel.Kilometer != announce.CarKilometer)
                    announce.CarKilometer = editModel.Kilometer;

                if (editModel.ModelId != 0 && editModel.ModelId != announce.CarModelId)
                    announce.CarModelId = editModel.ModelId;


                if (editModel.Motor != 0 && editModel.Motor != announce.CarMotor)
                    announce.CarMotor = editModel.Motor;


                if (editModel.MotorStrength != 0 && editModel.MotorStrength != announce.CarMotorStrength)
                    announce.CarMotorStrength = editModel.MotorStrength;


                if (editModel.PaymentTypeId != 0 &&editModel.PaymentTypeId!=null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.SpeedBoxId != 0 && editModel.SpeedBoxId != announce.SpeedBoxId)
                    announce.SpeedBoxId = editModel.SpeedBoxId;

                if (editModel.TransmissionId != 0 && editModel.TransmissionId != announce.TransmissionId)
                    announce.TransmissionId = editModel.TransmissionId;

                if (editModel.Year != 0 && editModel.Year != announce.CarYear)
                    announce.CarYear = editModel.Year;


                if (editModel.ConditionCredit != announce.ConditionCredit)
                    announce.ConditionCredit = editModel.ConditionCredit;

                if (editModel.ConditionBarter != announce.ConditionBarter)
                    announce.ConditionBarter = editModel.ConditionBarter;

                if (editModel.Condition != announce.Condition)
                    announce.Condition = editModel.Condition;

                var autoEquipment = await _dbContext.CarAutoEquipments.Where(a => a.CarId == announce.Id).ToListAsync();

                _dbContext.CarAutoEquipments.RemoveRange(autoEquipment);

                if (editModel.AutoEquipmentId != null)
                {
                    foreach (var item in editModel.AutoEquipmentId)
                    {
                        await _dbContext.CarAutoEquipments.AddAsync(new CarAutoEquipment
                        {
                            AutoEquipmentId = item,
                            CarId = announce.Id,
                        });

                    }
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
               
            }

        }
        public async  Task<bool> UpdateBusA(BusEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Buses.FindAsync(editModel.Id);

                var bodyType = await _dbContext.BusBodyTypes.FindAsync(editModel.BusBodyTypeId);

                if (bodyType != null && editModel.BusYear != 0)
                    editModel.AnnounceName = bodyType.Name + ", " + editModel.BusYear;
                else
                    return false;

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.BusBodyTypeId != 0 && editModel.BusBodyTypeId != announce.BusBodyTypeId)
                    announce.BusBodyTypeId = editModel.BusBodyTypeId;


                if (editModel.BusKilometer != 0 && editModel.BusKilometer != announce.BusKilometer)
                    announce.BusKilometer = editModel.BusKilometer;

                if (editModel.BusMakeId != 0 && editModel.BusMakeId != announce.BusMakeId)
                    announce.BusMakeId = editModel.BusMakeId;

                if (editModel.BusYear != 0 && editModel.BusYear != announce.BusYear)
                    announce.BusYear = editModel.BusYear;


                if (editModel.ConditionCredit != announce.ConditionCredit)
                    announce.ConditionCredit = editModel.ConditionCredit;

                if (editModel.ConditionBarter != announce.ConditionBarter)
                    announce.ConditionBarter = editModel.ConditionBarter;

                if (editModel.Condition != announce.Condition)
                    announce.Condition = editModel.Condition;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }


        }
        public async Task<bool> UpdateMotocycleA(MotorcycleEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Motocycles.FindAsync(editModel.Id);

                var make = await _dbContext.MotocycleMakes.FindAsync(editModel.MotocycleMakeId);
                var bodyType = await _dbContext.MotocycleBodyTypes.FindAsync(editModel.MotocycleBodyTypeId);
                if (make != null && bodyType != null && editModel.MotocycleYear != 0)
                    announce.AnnounceName = bodyType.Name + " " + make.Name + ", " + editModel.MotocycleYear;
                else
                    return false;


                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.MotocycleMakeId != 0 && editModel.MotocycleMakeId != announce.MotocycleMakeId)
                    announce.MotocycleMakeId = editModel.MotocycleMakeId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.MotocycleBodyTypeId != 0 && editModel.MotocycleBodyTypeId != announce.MotocycleBodyTypeId)
                    announce.MotocycleBodyTypeId = editModel.MotocycleBodyTypeId;

                if (editModel.MotocycleKilometer != 0 && editModel.MotocycleKilometer != announce.MotocycleKilometer)
                    announce.MotocycleKilometer = editModel.MotocycleKilometer;

                if (editModel.MotocycleModel != null && editModel.MotocycleModel != announce.MotocycleModel)
                    announce.MotocycleModel = editModel.MotocycleModel;

                if (editModel.MotocycleMotor != 0 && editModel.MotocycleMotor != announce.MotocycleMotor)
                    announce.MotocycleMotor = editModel.MotocycleMotor;

                if (editModel.MotocycleYear != 0 && editModel.MotocycleYear != announce.MotocycleYear)
                    announce.MotocycleYear = editModel.MotocycleYear;

                if (editModel.ConditionCredit != announce.ConditionCredit)
                    announce.ConditionCredit = editModel.ConditionCredit;

                if (editModel.ConditionBarter != announce.ConditionBarter)
                    announce.ConditionBarter = editModel.ConditionBarter;

                if (editModel.Condition != announce.Condition)
                    announce.Condition = editModel.Condition;


                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateAccessoryA(AccessoryEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Accessories.FindAsync(editModel.Id);

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.AccessoryTypeId != 0 && editModel.AccessoryTypeId != announce.AccessoryTypeId)
                    announce.AccessoryTypeId = editModel.AccessoryTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.Condition != announce.Condition)
                    announce.Condition = editModel.Condition;


                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateApartmentA(ApartmentEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Apartments.FindAsync(editModel.Id);

                if (editModel.ApartamentLocation != null && editModel.RoomCount != 0 && editModel.Area != 0)
                    editModel.AnnounceName = editModel.RoomCount + "-otaqlı, " + editModel.ApartamentLocation.Trim() + ", " + editModel.Area;
                else
                    return false;

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.RoomCount != 0 )
                    announce.RoomCount = editModel.RoomCount;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.ApartamentLocation != null && editModel.ApartamentLocation != announce.ApartamentLocation)
                    announce.ApartamentLocation = editModel.ApartamentLocation;

                if (editModel.ApartmentTypeId != 0 && editModel.ApartmentTypeId != announce.ApartmentTypeId)
                    announce.ApartmentTypeId = editModel.ApartmentTypeId;

                if (editModel.Area != 0 && editModel.Area != announce.Area)
                    announce.Area = editModel.Area;

                if (editModel.RSAnnounceTypeId != 0 && editModel.RSAnnounceTypeId != announce.RSAnnounceTypeId)
                    announce.RSAnnounceTypeId = editModel.RSAnnounceTypeId;



                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        } 
        public async Task<bool> UpdateHouseA(HouseVillaEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Houses.FindAsync(editModel.Id);

                var houseType = await _dbContext.HouseTypes.FindAsync(editModel.HouseTypeId);

                if ( houseType != null  && editModel.HouseLocation != null && editModel.HouseLocation.Trim() != "")
                    announce.AnnounceName = houseType.Name + ", " + editModel.HouseLocation;
                else
                    return false;


                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }


                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.RSAnnounceTypeId != 0 && editModel.RSAnnounceTypeId != announce.RSAnnounceTypeId)
                    announce.RSAnnounceTypeId = editModel.RSAnnounceTypeId;

                if (editModel.HouseTypeId != 0 && editModel.HouseTypeId != announce.HouseTypeId)
                    announce.HouseTypeId = editModel.HouseTypeId;

                if (editModel.HouseLocation != null && editModel.HouseLocation != announce.HouseLocation)
                    announce.Price = editModel.Price;

                if (editModel.Area != 0 && editModel.Area != announce.Area)
                    announce.Area = editModel.Area;


                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateOfficeA(CommercialEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Offices.FindAsync(editModel.Id);

                var officeType = await _dbContext.OfficeTypes.FindAsync(editModel.OfficeTypeId);
                if ( officeType != null && editModel.OfficeLocation != null && editModel.OfficeLocation.Trim() != "")
                    announce.AnnounceName = officeType.Name + ", " + editModel.OfficeLocation.Trim();
                else
                    return false;

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.RSAnnounceTypeId != 0 && editModel.RSAnnounceTypeId != announce.RSAnnounceTypeId)
                    announce.RSAnnounceTypeId = editModel.RSAnnounceTypeId;

                if (editModel.OfficeTypeId != 0 && editModel.OfficeTypeId != announce.OfficeTypeId)
                    announce.OfficeTypeId = editModel.OfficeTypeId;

                if (editModel.OfficeLocation != null && editModel.OfficeLocation != announce.OfficeLocation)
                    announce.OfficeLocation = editModel.OfficeLocation;

                if (editModel.OfficeArea != 0 && editModel.OfficeArea != announce.OfficeArea)
                    announce.OfficeArea = editModel.OfficeArea;


                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateGarageA(GarageEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Garages.FindAsync(editModel.Id);

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.GarageLocation != null && editModel.GarageLocation != announce.GarageLocation)
                    announce.GarageLocation = editModel.GarageLocation;

                if (editModel.Area != 0 && editModel.Area != announce.Area)
                    announce.Area = editModel.Area;



                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateLandA(LandEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Lands.FindAsync(editModel.Id);

                if (editModel.Area != 0 && editModel.LandLocation != null && editModel.LandLocation.Trim() != "")
                    announce.AnnounceName = editModel.Area + "sot torpaq sahəsi, " + editModel.LandLocation.Trim();
                else
                    return false;

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;


                if (editModel.LandLocation != null && editModel.LandLocation != announce.LandLocation)
                    announce.LandLocation = editModel.LandLocation;

                if (editModel.Area != 0 && editModel.Area != announce.Area)
                    announce.Area = editModel.Area;



                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateJobA(JobEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Jobs.FindAsync(editModel.Id);

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.ActivityAreaId != 0 && editModel.ActivityAreaId != announce.ActivityAreaId)
                    announce.ActivityAreaId = editModel.ActivityAreaId;

                if (editModel.JobTypeId != 0 && editModel.JobTypeId != announce.JobTypeId)
                    announce.JobTypeId = editModel.JobTypeId;



                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateBusinessA(BusinessEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.BusinessEquipments.FindAsync(editModel.Id);

                
                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;
                

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                if (editModel.BusinessTypeId != 0 && editModel.BusinessTypeId != announce.BusinessTypeId)
                    announce.BusinessTypeId = editModel.BusinessTypeId;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public async Task<bool> UpdateFoodA(FoodEditModel editModel)
        {
            if (editModel.Id == 0)
                return false;

            try
            {
                var announce = await _dbContext.Foods.FindAsync(editModel.Id);

                    if (editModel.AnnounceCheckIn == true)
                    {
                    if (!announce.AppendedPinCode)
                    {
                        var lastPinCode = await _dbContext.Statics.LastOrDefaultAsync();

                        Int32.TryParse(lastPinCode.PinCode, out int pinCode);

                        if (pinCode != 0)
                        {
                            announce.AnnouncePinCode = (pinCode + 1).ToString();
                            var lastPin = await _dbContext.Statics.LastOrDefaultAsync();
                            announce.AppendedPinCode = true;

                            lastPin.PinCode = (pinCode + 1).ToString();
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        if (editModel.AnnouncePublished != announce.AnnouncePublished)
                        {
                            announce.AnnouncePublished = editModel.AnnouncePublished;
                            announce.AnnouncePublishDate = DateTime.Now;
                        }


                    }
                    else
                    {
                        announce.AnnounceCheckIn = editModel.AnnounceCheckIn;
                        announce.AnnouncePublished = false;
                        announce.AnnouncePublishDate = null;
                    }

                if (editModel.AnnounceEnded != announce.AnnounceEnded)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceEndedDate != null && editModel.AnnounceEndedDate != announce.AnnounceEndedDate)
                    announce.AnnounceEndedDate = editModel.AnnounceEndedDate;

                if (editModel.AnnounceName != null && editModel.AnnounceName != announce.AnnounceName)
                    announce.AnnounceName = editModel.AnnounceName;

                if (editModel.AnnouncePublished != announce.AnnouncePublished)
                    announce.AnnounceEnded = editModel.AnnounceEnded;

                if (editModel.AnnounceTypeId != null && editModel.AnnounceTypeId != announce.AnnounceTypeId)
                    announce.AnnounceTypeId = editModel.AnnounceTypeId;

                if (editModel.AppUserId != null && editModel.AppUserId != announce.AppUserId)
                    announce.AppUserId = editModel.AppUserId;

                if (editModel.CityId != 0 && editModel.CityId != announce.CityId)
                    announce.CityId = editModel.CityId;

                if (editModel.Description != null && editModel.Description != announce.Description)
                    announce.Description = editModel.Description;

                if (editModel.Email != null && editModel.Email != announce.Email)
                    announce.Email = editModel.Email;


                if (editModel.PaymentTypeId != 0 && editModel.PaymentTypeId != null && editModel.PaymentTypeId != announce.PaymentTypeId)
                    announce.PaymentTypeId = editModel.PaymentTypeId;

                if (editModel.PersonTypeId != 0 && editModel.PersonTypeId != announce.PersonTypeId)
                    announce.PersonTypeId = editModel.PersonTypeId;

                if (editModel.PhoneNumber != null && editModel.PhoneNumber != announce.PhoneNumber)
                    announce.PhoneNumber = editModel.PhoneNumber;

                if (editModel.Price != 0 && editModel.Price != announce.Price)
                    announce.Price = editModel.Price;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
       

       

       

       
    }
}
