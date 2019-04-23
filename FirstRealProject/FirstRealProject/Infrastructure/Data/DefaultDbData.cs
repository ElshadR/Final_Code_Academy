using FirstRealProject.Areas.Admin.Models.Enums;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForFoodModels;
using FirstRealProject.Models.Jobs.ForJob;
using FirstRealProject.Models.Jobs.ForJobModels;
using FirstRealProject.Models.PagesModels;
using FirstRealProject.Models.Real_Estates.ApartmentModels;
using FirstRealProject.Models.Real_Estates.Commons;
using FirstRealProject.Models.Real_Estates.GarageModels;
using FirstRealProject.Models.Real_Estates.HouseModels;
using FirstRealProject.Models.Real_Estates.LandModels;
using FirstRealProject.Models.Real_Estates.OfficeModels;
using FirstRealProject.Models.Transports.AccessoryModels;
using FirstRealProject.Models.Transports.BusModels;
using FirstRealProject.Models.Transports.CarModels;
using FirstRealProject.Models.Transports.MotocycleModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Data
{
    public class DefaultDbData
    {

        public static void Seed(FirstRealProjectDbContext dbContext, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (!dbContext.Roles.Any())
            {
                string[] roles = Enum.GetNames(typeof(RoleType));

                foreach (string role in roles)
                {
                    AppRole appRole = new AppRole(role);
                    roleManager.CreateAsync(appRole).GetAwaiter().GetResult();
                }
            }

            if (!dbContext.BasicMenus.Any())
            {
                BasicMenu basicMenuTransport = new BasicMenu()
                {
                    Name = "Nəqliyyat"
                };
                BasicMenu basicMenuRealEstate = new BasicMenu()
                {
                    Name = "Daşınmaz Əmlak"
                };
                BasicMenu basicMenuJobs = new BasicMenu()
                {
                    Name = "İş Elanları"
                };
                dbContext.BasicMenus.AddRangeAsync(basicMenuTransport, basicMenuRealEstate, basicMenuJobs);
                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
                if (!dbContext.Categories.Any())
                {
                    Category categoryCar = new Category
                    {
                        Name = "Avtomobiller",
                        BasicMenuId = basicMenuTransport.Id,
                        Controller = "transport",
                        Action = "cars"
                    };
                    Category categoryBus = new Category
                    {
                        Name = "Avtobus ve xususi texnika",
                        BasicMenuId = basicMenuTransport.Id,
                        Controller = "transport",
                        Action = "buses"
                    };
                    Category categoryMotocycle = new Category
                    {
                        Name = "Motosikletler ve mopedler",
                        BasicMenuId = basicMenuTransport.Id,
                        Controller = "transport",
                        Action = "motocycles"
                    };
                    Category categoryAccesory = new Category
                    {
                        Name = "Ehtiyat hisseleri ve aksesuarlar",
                        BasicMenuId = basicMenuTransport.Id,
                        Controller = "transport",
                        Action = "accessories"
                    };
                    Category categoryApartment = new Category
                    {
                        Name = "Mənzil",
                        BasicMenuId = basicMenuRealEstate.Id,
                        Controller = "real-estate",
                        Action = "apartments"
                    };
                    Category categoryHouse = new Category
                    {
                        Name = "Villalar, Bağ evləri",
                        BasicMenuId = basicMenuRealEstate.Id,
                        Controller = "real-estate",
                        Action = "houses-villas"
                    };
                    Category categoryOffice = new Category
                    {
                        Name = "Obyektlər və ofislər",
                        BasicMenuId = basicMenuRealEstate.Id,
                        Controller = "real-estate",
                        Action = "commercials"
                    };
                    Category categoryLand = new Category
                    {
                        Name = "Torpaq",
                        BasicMenuId = basicMenuRealEstate.Id,
                        Controller = "real-estate",
                        Action = "lands"
                    };
                    Category categoryGarage = new Category
                    {
                        Name = "Qarajlar",
                        BasicMenuId = basicMenuRealEstate.Id,
                        Controller = "real-estate",
                        Action = "garages"
                    };
                    Category categoryBusiness = new Category
                    {
                        Name = "Biznes üçün avadanliq",
                        BasicMenuId = basicMenuJobs.Id,
                        Controller = "jobs",
                        Action = "business"
                    };
                    Category categoryJob = new Category
                    {
                        Name = "İş",
                        BasicMenuId = basicMenuJobs.Id,
                        Controller = "jobs",
                        Action = "jobs"
                    };
                    Category categoryFood = new Category
                    {
                        Name = "Ərzaq",
                        BasicMenuId = basicMenuJobs.Id,
                        Controller = "jobs",
                        Action = "foods"
                    };
                    //Car category
                    dbContext.Categories.AddRange(categoryCar, categoryMotocycle, categoryBus, categoryAccesory);
                    //real estate category
                    dbContext.Categories.AddRange(categoryApartment, categoryGarage, categoryLand, categoryHouse, categoryOffice);
                    //jobs category
                    dbContext.Categories.AddRange(categoryJob, categoryFood, categoryBusiness);

                    dbContext.SaveChangesAsync().GetAwaiter().GetResult();


                }
            }

            if (!dbContext.Cars.Any())
            {
                //-------------
                CarMake carMake1 = new CarMake
                {
                    Name = "ABM"
                };
                // -------------
                CarMake carMake2 = new CarMake
                {
                    Name = "Acura"
                };
                CarMake carMake3 = new CarMake
                {
                    Name = "Alfa Romeo"
                };
                CarMake carMake4 = new CarMake
                {
                    Name = "Aprilia"
                };
                CarMake carMake5 = new CarMake
                {
                    Name = "ARO"
                };
                CarMake carMake6 = new CarMake
                {
                    Name = "Arora"
                };
                CarMake carMake7 = new CarMake
                {
                    Name = "Ashok Leyland"
                };
                CarMake carMake8 = new CarMake
                {
                    Name = "Asia"
                };
                CarMake carMake9 = new CarMake
                {
                    Name = "Aston Martin"
                };
                CarMake carMake10 = new CarMake
                {
                    Name = "Audi"
                };
                CarMake carMake11 = new CarMake
                {
                    Name = "Baic"
                };
                CarMake carMake12 = new CarMake
                {
                    Name = "Baotian"
                };
                CarMake carMake13 = new CarMake
                {
                    Name = "BAW"
                };
                CarMake carMake14 = new CarMake
                {
                    Name = "Belka"
                };
                CarMake carMake15 = new CarMake
                {
                    Name = "Bentley"
                };
                CarMake carMake16 = new CarMake
                {
                    Name = "BMC"
                };
                CarMake carMake17 = new CarMake
                {
                    Name = "BMW"
                };
                CarMake carMake18 = new CarMake
                {
                    Name = "BMW ALPINA"
                };
                CarMake carMake19 = new CarMake
                {
                    Name = "Brilliance"
                };
                CarMake carMake20 = new CarMake
                {
                    Name = "Buell"
                };
                dbContext.CarMakes.AddRange(carMake1, carMake2, carMake3, carMake4, carMake5, carMake6, carMake7, carMake8, carMake9, carMake10,
                    carMake11, carMake12, carMake13, carMake14, carMake15, carMake16, carMake17, carMake18, carMake19, carMake20);

                //---------------
                CarModel carModel1 = new CarModel
                {
                    CarMakeId = carMake1.Id,
                    Name = "Volcan 150"
                };
                dbContext.CarModels.AddRange(carModel1);

                //---------------
                CarModel carModel2 = new CarModel
                {
                    CarMakeId = carMake2.Id,
                    Name = "CA6100SH2"
                };
                CarModel carModel3 = new CarModel
                {
                    CarMakeId = carMake2.Id,
                    Name = "CA6350"
                };
                CarModel carModel4 = new CarModel
                {
                    CarMakeId = carMake2.Id,
                    Name = "Daily 35C12H"
                };
                CarModel carModel5 = new CarModel
                {
                    CarMakeId = carMake2.Id,
                    Name = "ILX"
                };
                CarModel carModel6 = new CarModel
                {
                    CarMakeId = carMake2.Id,
                    Name = "MDX"
                };
                CarModel carModel7 = new CarModel
                {
                    CarMakeId = carMake2.Id,
                    Name = "RDX"
                };
                CarModel carModel8 = new CarModel
                {
                    CarMakeId = carMake2.Id,
                    Name = "RSX"
                };
                dbContext.CarModels.AddRange(carModel2, carModel3, carModel4, carModel5, carModel6, carModel7, carModel8);
                //---------------
                CarModel carModel9 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "145"
                };
                CarModel carModel10 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "146"
                };
                CarModel carModel11 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "147"
                };
                CarModel carModel12 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "155"
                };
                CarModel carModel13 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "156"
                };
                CarModel carModel14 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "159"
                };
                CarModel carModel15 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "164"
                };
                CarModel carModel16 = new CarModel
                {
                    CarMakeId = carMake3.Id,
                    Name = "166"
                };
                dbContext.CarModels.AddRange(carModel9, carModel10, carModel11, carModel12, carModel13, carModel14, carModel15, carModel16);
                //---------------
                CarModel carModel17 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "Dorsoduro 1200 ABS"
                };
                CarModel carModel18 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "RS 125"
                };
                CarModel carModel19 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "RS4-125"
                };
                CarModel carModel20 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "RSV4"
                };
                CarModel carModel21 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "Shiver 750 ABS"
                };
                CarModel carModel22 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "SR 300 MAX"
                };
                CarModel carModel23 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "SR 50"
                };
                CarModel carModel24 = new CarModel
                {
                    CarMakeId = carMake4.Id,
                    Name = "SR MAX"
                };

                dbContext.CarModels.AddRange(carModel17, carModel18, carModel19, carModel20, carModel21, carModel22, carModel23, carModel24);
                //---------------
                CarModel carModel25 = new CarModel
                {
                    CarMakeId = carMake5.Id,
                    Name = "244"
                };
                dbContext.CarModels.AddRange(carModel25);
                //---------------
                CarModel carModel26 = new CarModel
                {
                    CarMakeId = carMake6.Id,
                    Name = "AR100-62 Kartal"
                };
                dbContext.CarModels.AddRange(carModel26);
                //---------------
                CarModel carModel27 = new CarModel
                {
                    CarMakeId = carMake7.Id,
                    Name = "Eagle 816"
                };
                dbContext.CarModels.AddRange(carModel27);
                //---------------
                CarModel carModel28 = new CarModel
                {
                    CarMakeId = carMake8.Id,
                    Name = "Topic"
                };
                dbContext.CarModels.AddRange(carModel28);
                //---------------
                CarModel carModel29 = new CarModel
                {
                    CarMakeId = carMake9.Id,
                    Name = "DB9"
                };
                CarModel carModel30 = new CarModel
                {
                    CarMakeId = carMake9.Id,
                    Name = "DBS"
                };
                CarModel carModel31 = new CarModel
                {
                    CarMakeId = carMake9.Id,
                    Name = "Rapide"
                };
                CarModel carModel32 = new CarModel
                {
                    CarMakeId = carMake9.Id,
                    Name = "Vantage"
                };
                dbContext.CarModels.AddRange(carModel29, carModel30, carModel31, carModel32);
                //---------------

                CarModel carModel33 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "100"
                };
                CarModel carModel34 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "80"
                };
                CarModel carModel35 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A1"
                };
                CarModel carModel36 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A2"
                };
                CarModel carModel37 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A3"
                };
                CarModel carModel38 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A4"
                };
                CarModel carModel39 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A5"
                };
                CarModel carModel40 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A6"
                };
                CarModel carModel41 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A7"
                };
                CarModel carModel42 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "A8"
                };
                CarModel carModel43 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "Q3"
                };
                CarModel carModel44 = new CarModel
                {
                    CarMakeId = carMake10.Id,
                    Name = "Q5"

                };
                dbContext.CarModels.AddRange(carModel33, carModel34, carModel35, carModel36, carModel37, carModel38, carModel39, carModel40, carModel41,
                     carModel42, carModel43, carModel44);
                //---------------
                CarModel carModel45 = new CarModel
                {
                    CarMakeId = carMake11.Id,
                    Name = "A113"

                };
                CarModel carModel46 = new CarModel
                {
                    CarMakeId = carMake11.Id,
                    Name = "A113/A115"

                };
                CarModel carModel47 = new CarModel
                {
                    CarMakeId = carMake11.Id,
                    Name = "A115"

                };
                dbContext.CarModels.AddRange(carModel45, carModel46, carModel47);
                dbContext.SaveChanges();


                //---------------
                AutoEquipment autoEquipment1 = new AutoEquipment
                {
                    Name = "Yüngül lehimli disklər"
                };
                AutoEquipment autoEquipment2 = new AutoEquipment
                {
                    Name = "Lyuk"
                };
                AutoEquipment autoEquipment3 = new AutoEquipment
                {
                    Name = "Mərkəzi qapanma"
                };
                AutoEquipment autoEquipment4 = new AutoEquipment
                {
                    Name = "Kondisioner"
                };
                AutoEquipment autoEquipment5 = new AutoEquipment
                {
                    Name = "Dəri salon"
                };
                AutoEquipment autoEquipment6 = new AutoEquipment
                {
                    Name = "Arxa görüntü kamerasi"
                };
                AutoEquipment autoEquipment7 = new AutoEquipment
                {
                    Name = "Oturacaqlarin ventilyasiyasi"
                };
                AutoEquipment autoEquipment8 = new AutoEquipment
                {
                    Name = "ABS"
                };
                AutoEquipment autoEquipment9 = new AutoEquipment
                {
                    Name = "Yagis sensoru"
                };
                AutoEquipment autoEquipment10 = new AutoEquipment
                {
                    Name = "Park radari"
                };
                AutoEquipment autoEquipment11 = new AutoEquipment
                {
                    Name = "Oturacaqlarin isidilməsi"
                };
                AutoEquipment autoEquipment12 = new AutoEquipment
                {
                    Name = "Ksenon lampalar"
                };
                AutoEquipment autoEquipment13 = new AutoEquipment
                {
                    Name = "Yan pərdələr"
                };
                dbContext.AutoEquipments.AddRange(autoEquipment1, autoEquipment2, autoEquipment3, autoEquipment4, autoEquipment5, autoEquipment6, autoEquipment7, autoEquipment8,
                    autoEquipment9, autoEquipment10, autoEquipment11, autoEquipment12, autoEquipment13);
                //---------------
                CarBodyType carBodyType1 = new CarBodyType
                {
                    Name = "Sedan"
                };
                CarBodyType carBodyType2 = new CarBodyType
                {
                    Name = "Universal"
                };
                CarBodyType carBodyType3 = new CarBodyType
                {
                    Name = "Hetçbek"
                };
                CarBodyType carBodyType4 = new CarBodyType
                {
                    Name = "Offroad"
                };
                CarBodyType carBodyType5 = new CarBodyType
                {
                    Name = "Kupe"
                };
                CarBodyType carBodyType6 = new CarBodyType
                {
                    Name = "Rodster"
                };
                CarBodyType carBodyType7 = new CarBodyType
                {
                    Name = "Mikroavtobus"
                };
                CarBodyType carBodyType8 = new CarBodyType
                {
                    Name = "Pikap"
                };
                CarBodyType carBodyType9 = new CarBodyType
                {
                    Name = "Limuzin"
                };
                dbContext.CarBodyTypes.AddRange(carBodyType1, carBodyType2, carBodyType3, carBodyType4, carBodyType5, carBodyType6, carBodyType7, carBodyType8,
                    carBodyType9);


                //---------------
                City city1 = new City
                {
                    Name = "Bakı"
                };
                City city2 = new City
                {
                    Name = "Şəmkir"
                };
                City city3 = new City
                {
                    Name = "Qazax"
                };
                City city4 = new City
                {
                    Name = "Gəncə"
                };
                City city5 = new City
                {
                    Name = "Tovuz"
                };
                City city6 = new City
                {
                    Name = "Sumqayıt"
                };
                City city7 = new City
                {
                    Name = "Şəki"
                };
                City city8 = new City
                {
                    Name = "Gədəbəy"
                };
                City city9 = new City
                {
                    Name = "Goranboy"
                };
                City city10 = new City
                {
                    Name = "Yevlax"
                };
                dbContext.Cities.AddRange(city1, city2, city3, city4, city5, city6, city7, city8, city9, city10);
                //---------------
                PersonType personType1 = new PersonType
                {
                    Name = "Şəxsi"
                };
                PersonType personType2 = new PersonType
                {
                    Name = "Şirkət"
                };
                dbContext.PersonTypes.AddRange(personType1, personType2);
                //---------------
                PaymentType paymentType1 = new PaymentType
                {
                    Name = "Operator"
                };
                PaymentType paymentType2 = new PaymentType
                {
                    Name = "Cart"
                };
                dbContext.PaymentTypes.AddRange(paymentType1, paymentType2);
                //---------------
                AnnounceType announceType1 = new AnnounceType
                {
                    Name = "Sade elan",
                };
                AnnounceType announceType2 = new AnnounceType
                {
                    Name = "Vip elan",
                    Price = 6,
                    Description = "Öz elanını VIP et və daha tez sat! VIP elanlara 10 dəfə çox baxılır!"
                };
                AnnounceType announceType3 = new AnnounceType
                {
                    Name = "Premium elan",
                    Price = 10,
                };
                dbContext.AnnounceTypes.AddRange(announceType1, announceType2, announceType3);


                //---------------

                SpeedBox speedBox1 = new SpeedBox
                {
                    Name = "Avtomat"
                };
                SpeedBox speedBox2 = new SpeedBox
                {
                    Name = "Mexanika"
                };
                dbContext.SpeedBoxes.AddRange(speedBox1, speedBox2);

                //---------------
                Transmission transmission1 = new Transmission
                {
                    Name = "Hər ikisi",
                };
                Transmission transmission2 = new Transmission
                {
                    Name = "Ön",
                };
                Transmission transmission3 = new Transmission
                {
                    Name = "Arxa",
                };
                dbContext.Transmissions.AddRange(transmission1, transmission2, transmission3);
                //---------------
                FuelType fuelType1 = new FuelType
                {
                    Name = "Benzin",
                };
                FuelType fuelType2 = new FuelType
                {
                    Name = "Dizel",
                };
                FuelType fuelType3 = new FuelType
                {
                    Name = "Qaz",
                };

                dbContext.FuelTypes.AddRange(fuelType1, fuelType2, fuelType3);
                //---------------
                AppUser appUser1 = new AppUser
                {
                    UserName = "shahin",
                    Email = "elshad@gmail.com"
                };
                IdentityResult result1 = userManager.CreateAsync(appUser1, "ilkin12").GetAwaiter().GetResult();

                List<string> roles = new List<string>();
                string[] rolesType = Enum.GetNames(typeof(RoleType));
                roles.AddRange(rolesType);
                if (result1.Succeeded)
                {
                    IdentityResult roleResult = userManager.AddToRolesAsync(appUser1, rolesType).GetAwaiter().GetResult();
                }
                AppUser appUser2 = new AppUser
                {
                    UserName = "nicat",
                    Email = "ilkin@gmail.com"
                };
                IdentityResult result2 = userManager.CreateAsync(appUser2, "elshad12").GetAwaiter().GetResult();
                if (result2.Succeeded)
                {
                    IdentityResult roleResult = userManager.AddToRoleAsync(appUser2, "User").GetAwaiter().GetResult();
                }

                Car car1 = new Car(carMake5, carModel1, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 4542,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 25000,
                    CityId = city1.Id,
                    Description = "rds, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of , comes from a line in section 1.10.32.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    PaymentTypeId = paymentType2.Id,
                    Email = "ilkin@code.edu.az",
                    PhoneNumber = "0512216651",
                    AnnounceViewCount = 0,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100000",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "1",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id,
                    AppUserId = appUser1.Id,

                };
                Car car2 = new Car(carMake5, carModel1, 1994)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100001",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "2",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car3 = new Car(carMake5, carModel14, 2012)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 23424,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 23432,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "fgdfd@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100002",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "3",
                    FuelTypeId = fuelType2.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id,
                    AppUserId = appUser1.Id,


                };
                Car car4 = new Car(carMake5, carModel12, 2015)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 2342,
                    CarMotorStrength = 454,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 213242,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100003",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "4",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    AppUserId = appUser1.Id,
                    PersonTypeId = personType1.Id

                };
                Car car5 = new Car(carMake5, carModel13, 2016)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100004",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "5",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car6 = new Car(carMake5, carModel14, 2016)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 8797,
                    CarMotorStrength = 45453,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 12312,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100005",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "6",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car7 = new Car(carMake5, carModel1, 2016)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 23223,
                    CarMotorStrength = 545,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 4332,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 423,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100006",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "7",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car8 = new Car(carMake15, carModel2, 2016)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 2342,
                    CarMotorStrength = 240,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 34242,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 23423,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100007",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "8",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car9 = new Car(carMake15, carModel33, 2016)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242234,
                    CarMotorStrength = 45,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 24234,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100008",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "9",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    AppUserId = appUser1.Id,
                    PersonTypeId = personType1.Id

                };
                Car car10 = new Car(carMake15, carModel13, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 23422,
                    CarMotorStrength = 45,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 3242342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 324432,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100009",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "10",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car11 = new Car(carMake15, carModel1, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 52,
                    CarMotorStrength = 45,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 1554,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2154,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100010",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "11",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car12 = new Car(carMake15, carModel5, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100011",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "12",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car13 = new Car(carMake18, carModel2, 2011)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 5646,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 3213,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 541616,
                    CityId = city1.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100012",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "13",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car14 = new Car(carMake18, carModel1, 2011)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 354561,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 5646,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 51651,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100013",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "14",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car15 = new Car(carMake18, carModel8, 2011)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100014",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "15",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car16 = new Car(carMake18, carModel1, 2011)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 11,
                    CarMotorStrength = 454,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 21122,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 21521,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100015",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "16",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car17 = new Car(carMake18, carModel1, 2011)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 11353,
                    CarMotorStrength = 454,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 1456,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54161,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100016",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "17",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    AppUserId = appUser1.Id,
                    PersonTypeId = personType1.Id

                };
                Car car18 = new Car(carMake18, carModel14, 2011)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100017",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "18",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car19 = new Car(carMake18, carModel42, 2011)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 316,
                    CarMotorStrength = 454,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 35165,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 31616,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100018",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "19",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car20 = new Car(carMake17, carModel41, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 545,
                    CarMotorStrength = 754,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54541,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 654,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100019",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "20",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car21 = new Car(carMake17, carModel1, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 654,
                    CarMotorStrength = 245440,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 1565,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 6546565,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100020",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "21",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car22 = new Car(carMake17, carModel1, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 24540,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 35465,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 6565,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100021",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "22",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    AppUserId = appUser2.Id,
                    PersonTypeId = personType1.Id

                };
                Car car23 = new Car(carMake17, carModel47, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 154,
                    CarMotorStrength = 879,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 245,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 1616,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100022",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "23",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car24 = new Car(carMake17, carModel45, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 155,
                    CarMotorStrength = 786,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 265,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 565665,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100023",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "24",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car25 = new Car(carMake17, carModel28, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 32161,
                    CarMotorStrength = 232,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 116,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 656,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100024",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "25",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car26 = new Car(carMake1, carModel24, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 16565,
                    CarMotorStrength = 342,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarModelId = carModel1.Id,
                    CarKilometer = 321365,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 21655,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100025",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "26",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car27 = new Car(carMake1, carModel1, 1992)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3216,
                    CarMotorStrength = 240,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 3,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5165,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100026",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "27",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    AppUserId = appUser2.Id,
                    PersonTypeId = personType1.Id

                };
                Car car28 = new Car(carMake1, carModel1, 1996)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 166,
                    CarMotorStrength = 3534,
                    TransmissionId = transmission2.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 1515,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 6649,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 15,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100027",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "28",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car29 = new Car(carMake1, carModel11, 1996)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100028",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "29",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car30 = new Car(carMake1, carModel18, 1996)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100029",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "30",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    AppUserId = appUser2.Id,
                    PersonTypeId = personType1.Id

                };
                Car car31 = new Car(carMake1, carModel17, 1996)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 6465,
                    CarMotorStrength = 35,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 5461,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 265,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100030",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "31",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car32 = new Car(carMake1, carModel31, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 21316,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 894,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 11411,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100031",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "32",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car33 = new Car(carMake1, carModel21, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 79979,
                    CarMotorStrength = 34553,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 9498,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 45214,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100032",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "33",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    AppUserId = appUser2.Id,
                    PersonTypeId = personType1.Id

                };
                Car car34 = new Car(carMake1, carModel1, 1996)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 448898,
                    CarMotorStrength = 354,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 664665,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 4879971,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100033",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "34",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car35 = new Car(carMake3, carModel19, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 49664,
                    CarMotorStrength = 34,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 6566,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100034",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "35",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car36 = new Car(carMake3, carModel14, 1996)
                {
                    CarBodyTypeId = carBodyType2.Id,
                    CarMotor = 41600,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 30050,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 515855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100035",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "36",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car37 = new Car(carMake3, carModel1, 1991)
                {
                    CarBodyTypeId = carBodyType2.Id,
                    CarMotor = 16500,
                    CarMotorStrength = 45,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 30500,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 512855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100036",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "37",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car38 = new Car(carMake3, carModel1, 1996)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 5675,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 302100,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 58155,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType2.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100037",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "38",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car39 = new Car(carMake3, carModel1, 1996)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 600,
                    CarMotorStrength = 5675,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100038",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "39",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car40 = new Car(carMake3, carModel2, 1994)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 16500,
                    CarMotorStrength = 5675,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 304500,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 58555,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType2.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100039",
                    AppendedPinCode = true,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnounceUniqueCode = "40",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car41 = new Car(carMake3, carModel1, 1994)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100040",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "41",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car42 = new Car(carMake4, carModel1, 2000)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 10000,
                    CarMotorStrength = 345,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 304500,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city1.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType2.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100041",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "42",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType2.Id

                };
                Car car43 = new Car(carMake4, carModel1, 1994)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 5000,
                    CarMotorStrength = 456,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 3131200,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city1.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100042",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "43",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car44 = new Car(carMake4, carModel1, 1994)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 231,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 302300,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100043",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "44",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car45 = new Car(carMake4, carModel44, 1994)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 253,
                    CarMotorStrength = 312,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 34334,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5345,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType3.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100044",
                    AppendedPinCode = true,
                    PersonTypeId = personType1.Id,
                    AnnounceUniqueCode = "45",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",

                };
                Car car46 = new Car(carMake4, carModel1, 1994)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100045",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "46",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car47 = new Car(carMake4, carModel13, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100046",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "47",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car48 = new Car(carMake4, carModel5, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100047",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "48",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car49 = new Car(carMake4, carModel8, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100048",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "49",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car50 = new Car(carMake4, carModel14, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100049",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "50",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car51 = new Car(carMake5, carModel11, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100050",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "51",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car52 = new Car(carMake5, carModel18, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100051",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "52",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car53 = new Car(carMake5, carModel1, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100052",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "53",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car54 = new Car(carMake5, carModel13, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100053",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "54",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car55 = new Car(carMake5, carModel5, 2017)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100054",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "55",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car56 = new Car(carMake5, carModel8, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100055",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "56",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car57 = new Car(carMake5, carModel14, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100056",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "57",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car58 = new Car(carMake5, carModel11, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100057",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "58",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car59 = new Car(carMake5, carModel18, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100058",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "59",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car60 = new Car(carMake6, carModel1, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100059",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "60",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car61 = new Car(carMake6, carModel13, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100060",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "61",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car62 = new Car(carMake6, carModel5, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100061",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "62",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car63 = new Car(carMake6, carModel8, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100062",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "63",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car64 = new Car(carMake6, carModel14, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100063",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "64",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car65 = new Car(carMake6, carModel11, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100064",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "65",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car66 = new Car(carMake6, carModel18, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100065",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "66",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car67 = new Car(carMake8, carModel1, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100066",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "67",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car68 = new Car(carMake8, carModel13, 1999)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100067",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "68",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car69 = new Car(carMake8, carModel5, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100068",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "69",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car70 = new Car(carMake8, carModel8, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100069",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "70",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car71 = new Car(carMake8, carModel14, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100070",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "71",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car72 = new Car(carMake8, carModel11, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100071",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "72",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car73 = new Car(carMake8, carModel18, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100072",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "73",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car74 = new Car(carMake8, carModel1, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100073",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "74",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car75 = new Car(carMake8, carModel13, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100074",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "75",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car76 = new Car(carMake1, carModel5, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100075",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "76",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car77 = new Car(carMake1, carModel8, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100076",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "77",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car78 = new Car(carMake1, carModel14, 2018)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100077",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "78",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car79 = new Car(carMake1, carModel11, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100078",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "79",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car80 = new Car(carMake1, carModel18, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100079",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "80",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car81 = new Car(carMake1, carModel1, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100080",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "81",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car82 = new Car(carMake1, carModel13, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100081",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "82",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car83 = new Car(carMake1, carModel5, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100082",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "83",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car84 = new Car(carMake1, carModel8, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100083",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "84",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car85 = new Car(carMake1, carModel14, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100084",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "85",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car86 = new Car(carMake1, carModel11, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100085",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "86",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car87 = new Car(carMake1, carModel18, 1990)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100086",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "87",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car88 = new Car(carMake1, carModel1, 2013)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100087",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "88",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car89 = new Car(carMake1, carModel13, 2013)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100088",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "89",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car90 = new Car(carMake1, carModel5, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100089",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "90",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car91 = new Car(carMake1, carModel8, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100090",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "91",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car92 = new Car(carMake1, carModel14, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100091",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "92",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car93 = new Car(carMake1, carModel11, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100092",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "93",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car94 = new Car(carMake1, carModel18, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 449,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 54998,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54136,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100093",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "94",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car95 = new Car(carMake1, carModel1, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 1600,
                    CarMotorStrength = 54,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox2.Id,
                    CarKilometer = 3000,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 5855,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100094",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "95",
                    FuelTypeId = fuelType1.Id,
                    Color = "Ağ",
                    PersonTypeId = personType1.Id

                };
                Car car96 = new Car(carMake1, carModel13, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 242,
                    CarMotorStrength = 240,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 342,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 42342,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100095",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "96",
                    FuelTypeId = fuelType3.Id,
                    Color = "Qirmizi",
                    PersonTypeId = personType1.Id

                };
                Car car97 = new Car(carMake1, carModel5, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 250,
                    CarMotorStrength = 546,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 346546,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2122,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 655,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100096",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "97",
                    FuelTypeId = fuelType2.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car98 = new Car(carMake1, carModel8, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 3133,
                    CarMotorStrength = 240,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 321313,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 2113132,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100097",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "98",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car99 = new Car(carMake1, carModel14, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 546,
                    CarMotorStrength = 4654,
                    TransmissionId = transmission3.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 6561,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100098",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "99",
                    FuelTypeId = fuelType3.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };
                Car car100 = new Car(carMake1, carModel11, 1991)
                {
                    CarBodyTypeId = carBodyType1.Id,
                    CarMotor = 65469,
                    CarMotorStrength = 353,
                    TransmissionId = transmission1.Id,
                    SpeedBoxId = speedBox1.Id,
                    CarKilometer = 2113,
                    Condition = false,
                    ConditionCredit = true,
                    ConditionBarter = true,
                    Price = 54646,
                    CityId = city2.Id,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = announceType1.Id,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0515945165",
                    AnnounceViewCount = 0,
                    PaymentTypeId = paymentType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100099",
                    AppendedPinCode = true,
                    AnnounceUniqueCode = "100",
                    FuelTypeId = fuelType1.Id,
                    Color = "qara",
                    PersonTypeId = personType1.Id

                };

                dbContext.Cars.AddRange(car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16, car17, car18, car19, car20,
                    car21, car22, car23, car24, car25, car26, car27, car28, car29, car30, car31, car32, car33, car34, car35, car36, car37, car38, car39, car40, car41, car42, car43, car44, car45,
                    car46, car47, car48, car49, car50, car51, car52, car53, car54, car55, car56, car57, car58, car59, car60, car61, car62, car63, car64, car65, car66, car67, car68, car69, car70, car71, car72
                    , car73, car74, car75, car76, car77, car78, car79, car80, car81, car82, car83, car84, car85, car86, car87, car88, car89, car90, car91, car92, car93, car94, car95, car96, car97, car98, car99, car100);
                //---------------
                CarPhoto carPhoto1 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car1.Id
                };
                CarPhoto carPhoto2 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car1.Id
                };
                CarPhoto carPhoto3 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car1.Id
                };
                CarPhoto carPhoto4 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car1.Id
                };
                //---------------
                CarPhoto carPhoto5 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car2.Id
                };
                CarPhoto carPhoto6 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car2.Id
                };
                CarPhoto carPhoto7 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car2.Id
                };
                CarPhoto carPhoto8 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car2.Id
                };
                CarPhoto carPhoto9 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car3.Id
                };
                CarPhoto carPhoto10 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car3.Id
                };
                CarPhoto carPhoto11 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car3.Id
                };
                CarPhoto carPhoto12 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car3.Id
                };
                CarPhoto carPhoto13 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car4.Id
                };
                CarPhoto carPhoto14 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car5.Id
                };
                CarPhoto carPhoto15 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car6.Id
                };
                CarPhoto carPhoto16 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car7.Id
                };
                CarPhoto carPhoto17 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car8.Id
                };
                CarPhoto carPhoto18 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car8.Id
                };
                CarPhoto carPhoto19 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car8.Id
                };
                CarPhoto carPhoto20 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car8.Id
                };
                CarPhoto carPhoto21 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car8.Id
                };
                CarPhoto carPhoto22 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car8.Id
                };
                CarPhoto carPhoto23 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car8.Id
                };
                CarPhoto carPhoto24 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car9.Id
                };
                CarPhoto carPhoto25 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car9.Id
                };
                CarPhoto carPhoto26 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car10.Id
                };
                CarPhoto carPhoto27 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car11.Id
                };
                CarPhoto carPhoto28 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car12.Id
                };
                CarPhoto carPhoto29 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car13.Id
                };
                CarPhoto carPhoto30 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car14.Id
                };
                CarPhoto carPhoto31 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car15.Id
                };
                CarPhoto carPhoto32 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car16.Id
                };
                CarPhoto carPhoto33 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car17.Id
                };
                CarPhoto carPhoto34 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car17.Id
                };
                CarPhoto carPhoto35 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car17.Id
                };
                CarPhoto carPhoto36 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car18.Id
                };
                CarPhoto carPhoto37 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car19.Id
                };
                CarPhoto carPhoto38 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car20.Id
                };
                CarPhoto carPhoto39 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car21.Id
                };
                CarPhoto carPhoto40 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car22.Id
                };
                CarPhoto carPhoto41 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car23.Id
                };
                CarPhoto carPhoto42 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car24.Id
                };
                CarPhoto carPhoto43 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car24.Id
                };
                CarPhoto carPhoto44 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car24.Id
                };
                CarPhoto carPhoto45 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car24.Id
                };
                CarPhoto carPhoto46 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car24.Id
                };
                CarPhoto carPhoto47 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car24.Id
                };
                CarPhoto carPhoto48 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car25.Id
                };
                CarPhoto carPhoto49 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car25.Id
                };
                CarPhoto carPhoto50 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car25.Id
                };
                CarPhoto carPhoto51 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car25.Id
                };
                CarPhoto carPhoto52 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car25.Id
                };
                CarPhoto carPhoto53 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car26.Id
                };
                CarPhoto carPhoto54 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car27.Id
                };
                CarPhoto carPhoto55 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car27.Id
                };
                CarPhoto carPhoto56 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car27.Id
                };
                CarPhoto carPhoto57 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car27.Id
                };
                CarPhoto carPhoto58 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car27.Id
                };
                CarPhoto carPhoto59 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car27.Id
                };
                CarPhoto carPhoto60 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car27.Id
                };
                CarPhoto carPhoto61 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car28.Id
                };
                CarPhoto carPhoto62 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car29.Id
                };
                CarPhoto carPhoto63 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car29.Id
                };
                CarPhoto carPhoto64 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car30.Id
                };
                CarPhoto carPhoto65 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car31.Id
                };
                CarPhoto carPhoto66 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car32.Id
                };
                CarPhoto carPhoto67 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car32.Id
                };
                CarPhoto carPhoto68 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car33.Id
                };
                CarPhoto carPhoto69 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car33.Id
                };
                CarPhoto carPhoto70 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto71 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto72 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto73 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto74 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto75 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto76 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto77 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto78 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto79 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car34.Id
                };
                CarPhoto carPhoto80 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car35.Id
                };
                CarPhoto carPhoto81 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car36.Id
                };
                CarPhoto carPhoto82 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car36.Id
                };
                CarPhoto carPhoto83 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car36.Id
                };
                CarPhoto carPhoto84 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car37.Id
                };
                CarPhoto carPhoto85 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car37.Id
                };
                CarPhoto carPhoto86 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car38.Id
                };
                CarPhoto carPhoto87 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car38.Id
                };
                CarPhoto carPhoto88 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car39.Id
                };
                CarPhoto carPhoto89 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car2.Id
                };
                CarPhoto carPhoto90 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car40.Id
                };
                CarPhoto carPhoto91 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car40.Id
                };
                CarPhoto carPhoto92 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car40.Id
                };
                CarPhoto carPhoto93 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car41.Id
                };
                CarPhoto carPhoto94 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car42.Id
                };
                CarPhoto carPhoto95 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car42.Id
                };
                CarPhoto carPhoto96 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car42.Id

                };
                CarPhoto carPhoto97 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car43.Id
                };
                CarPhoto carPhoto98 = new CarPhoto
                {

                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car43.Id
                };
                CarPhoto carPhoto99 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car44.Id
                };
                CarPhoto carPhoto100 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car45.Id
                };
                CarPhoto carPhoto101 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car45.Id
                };
                CarPhoto carPhoto102 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car46.Id
                };
                CarPhoto carPhoto103 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car47.Id
                };
                CarPhoto carPhoto104 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car48.Id
                };
                CarPhoto carPhoto105 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car49.Id
                };
                CarPhoto carPhoto106 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car50.Id
                };
                CarPhoto carPhoto107 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car51.Id
                };
                CarPhoto carPhoto108 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car52.Id
                };
                CarPhoto carPhoto109 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car53.Id
                };
                CarPhoto carPhoto110 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car53.Id
                };
                CarPhoto carPhoto111 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car54.Id
                };
                CarPhoto carPhoto112 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car55.Id
                };
                CarPhoto carPhoto113 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car56.Id
                };
                CarPhoto carPhoto114 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car56.Id
                };
                CarPhoto carPhoto115 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car56.Id
                };
                CarPhoto carPhoto116 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car57.Id
                };
                CarPhoto carPhoto117 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car58.Id
                };
                CarPhoto carPhoto118 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car59.Id
                };
                CarPhoto carPhoto119 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car60.Id
                };
                CarPhoto carPhoto120 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car61.Id
                };
                CarPhoto carPhoto121 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car62.Id
                };
                CarPhoto carPhoto122 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car63.Id
                };
                CarPhoto carPhoto123 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car63.Id
                };
                CarPhoto carPhoto124 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car64.Id
                };
                CarPhoto carPhoto125 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car65.Id
                };
                CarPhoto carPhoto126 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car66.Id
                };
                CarPhoto carPhoto127 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car66.Id
                };
                CarPhoto carPhoto128 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car67.Id
                };
                CarPhoto carPhoto129 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car68.Id
                };
                CarPhoto carPhoto130 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car69.Id
                };
                CarPhoto carPhoto131 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car70.Id
                };
                CarPhoto carPhoto132 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car71.Id
                };
                CarPhoto carPhoto133 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car71.Id
                };
                CarPhoto carPhoto134 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car72.Id
                };
                CarPhoto carPhoto135 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car73.Id
                };
                CarPhoto carPhoto136 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car74.Id
                };
                CarPhoto carPhoto137 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car74.Id
                };
                CarPhoto carPhoto138 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car74.Id
                };
                CarPhoto carPhoto139 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car75.Id
                };
                CarPhoto carPhoto140 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car76.Id
                };
                CarPhoto carPhoto141 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car77.Id
                };
                CarPhoto carPhoto142 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car77.Id
                };
                CarPhoto carPhoto143 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car78.Id
                };
                CarPhoto carPhoto144 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car79.Id
                };
                CarPhoto carPhoto145 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car80.Id
                };
                CarPhoto carPhoto146 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car81.Id
                };
                CarPhoto carPhoto147 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car82.Id
                };
                CarPhoto carPhoto148 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car82.Id
                };
                CarPhoto carPhoto149 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car83.Id
                };
                CarPhoto carPhoto150 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car83.Id
                };
                CarPhoto carPhoto151 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car84.Id
                };
                CarPhoto carPhoto152 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car85.Id
                };
                CarPhoto carPhoto153 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car85.Id
                };
                CarPhoto carPhoto154 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car86.Id
                };
                CarPhoto carPhoto155 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car87.Id
                };
                CarPhoto carPhoto156 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car88.Id
                };
                CarPhoto carPhoto157 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car89.Id
                };
                CarPhoto carPhoto158 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car90.Id
                };
                CarPhoto carPhoto159 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car90.Id
                };
                CarPhoto carPhoto160 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car91.Id
                };
                CarPhoto carPhoto161 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car92.Id
                };
                CarPhoto carPhoto162 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car92.Id
                };
                CarPhoto carPhoto163 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car93.Id
                };
                CarPhoto carPhoto164 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car94.Id
                };
                CarPhoto carPhoto165 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car95.Id
                };
                CarPhoto carPhoto166 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car95.Id
                };
                CarPhoto carPhoto167 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car96.Id
                };
                CarPhoto carPhoto168 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car97.Id
                };
                CarPhoto carPhoto169 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car98.Id
                };
                CarPhoto carPhoto170 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip1.jpg",
                    CarId = car99.Id
                };
                CarPhoto carPhoto171 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car99.Id
                };
                CarPhoto carPhoto172 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip4.jpg",
                    CarId = car100.Id
                };
                CarPhoto carPhoto173 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip2.jpg",
                    CarId = car100.Id
                };
                CarPhoto carPhoto174 = new CarPhoto
                {
                    Path = "/lib/images/transport/car/vip3.jpg",
                    CarId = car100.Id
                };
                dbContext.CarPhotos.AddRange(carPhoto1, carPhoto2, carPhoto3, carPhoto4, carPhoto5, carPhoto6, carPhoto7, carPhoto8, carPhoto9, carPhoto10,
                    carPhoto11, carPhoto12, carPhoto13, carPhoto14, carPhoto15, carPhoto16, carPhoto17, carPhoto18, carPhoto19, carPhoto20, carPhoto21, carPhoto22, carPhoto23,
                    carPhoto24, carPhoto25, carPhoto26, carPhoto27, carPhoto28, carPhoto29, carPhoto30, carPhoto31, carPhoto32, carPhoto33, carPhoto34, carPhoto35, carPhoto36,
                    carPhoto37, carPhoto38, carPhoto39, carPhoto40, carPhoto41, carPhoto42, carPhoto43, carPhoto44, carPhoto45, carPhoto46, carPhoto47, carPhoto48, carPhoto49,
                    carPhoto50, carPhoto51, carPhoto52, carPhoto53, carPhoto54, carPhoto55, carPhoto56, carPhoto57, carPhoto58, carPhoto59, carPhoto60, carPhoto61, carPhoto62,
                    carPhoto63, carPhoto64, carPhoto65, carPhoto66, carPhoto67, carPhoto68, carPhoto69, carPhoto70, carPhoto71, carPhoto72, carPhoto73, carPhoto74, carPhoto75,
                    carPhoto76, carPhoto77, carPhoto78, carPhoto79, carPhoto80, carPhoto81, carPhoto82, carPhoto83, carPhoto84, carPhoto85, carPhoto86, carPhoto87, carPhoto88,
                    carPhoto89, carPhoto90, carPhoto91, carPhoto92, carPhoto93, carPhoto94, carPhoto95, carPhoto96, carPhoto97, carPhoto98, carPhoto99, carPhoto100, carPhoto101,
                    carPhoto102, carPhoto103, carPhoto104, carPhoto105, carPhoto106, carPhoto107, carPhoto108, carPhoto109, carPhoto110, carPhoto111, carPhoto112, carPhoto113, carPhoto114,
                    carPhoto115, carPhoto116, carPhoto117, carPhoto118, carPhoto119, carPhoto120, carPhoto121, carPhoto122, carPhoto123, carPhoto124, carPhoto125, carPhoto126, carPhoto127,
                    carPhoto128, carPhoto129, carPhoto130, carPhoto131, carPhoto132, carPhoto133, carPhoto134, carPhoto135, carPhoto136, carPhoto137, carPhoto138, carPhoto139, carPhoto140,
                    carPhoto141, carPhoto142, carPhoto143, carPhoto144, carPhoto145, carPhoto146, carPhoto147, carPhoto148, carPhoto149, carPhoto150, carPhoto151, carPhoto152, carPhoto153,
                    carPhoto154, carPhoto155, carPhoto156, carPhoto157, carPhoto158, carPhoto159, carPhoto160, carPhoto161, carPhoto162, carPhoto163, carPhoto164, carPhoto165, carPhoto166,
                    carPhoto167, carPhoto168, carPhoto169, carPhoto170, carPhoto171, carPhoto172, carPhoto173, carPhoto174);

                CarAutoEquipment carAutoEquipment1 = new CarAutoEquipment
                {
                    AutoEquipmentId = autoEquipment1.Id,
                    CarId = car1.Id
                };
                CarAutoEquipment carAutoEquipment2 = new CarAutoEquipment
                {
                    AutoEquipmentId = autoEquipment2.Id,
                    CarId = car1.Id
                };
                CarAutoEquipment carAutoEquipment3 = new CarAutoEquipment
                {
                    AutoEquipmentId = autoEquipment8.Id,
                    CarId = car1.Id
                };
                CarAutoEquipment carAutoEquipment4 = new CarAutoEquipment
                {
                    AutoEquipmentId = autoEquipment12.Id,
                    CarId = car1.Id
                };
                CarAutoEquipment carAutoEquipment5 = new CarAutoEquipment
                {
                    AutoEquipmentId = autoEquipment1.Id,
                    CarId = car2.Id
                };
                CarAutoEquipment carAutoEquipment6 = new CarAutoEquipment
                {
                    AutoEquipmentId = autoEquipment6.Id,
                    CarId = car2.Id
                };
                dbContext.CarAutoEquipments.AddRange(carAutoEquipment1, carAutoEquipment2, carAutoEquipment3, carAutoEquipment4, carAutoEquipment5, carAutoEquipment6);
                dbContext.SaveChanges();
            }


            if (!dbContext.Buses.Any())
            {
                BusBodyType busBodyType1 = new BusBodyType
                {
                    Name = "Avtobuslar"
                };
                BusBodyType busBodyType2 = new BusBodyType
                {
                    Name = "Avtokranlar"
                };
                BusBodyType busBodyType3 = new BusBodyType
                {
                    Name = "Yük maşınları"
                };
                BusBodyType busBodyType4 = new BusBodyType
                {
                    Name = "Qoşqular"
                };
                BusBodyType busBodyType5 = new BusBodyType
                {
                    Name = "Tikinti texnikası"
                };
                BusBodyType busBodyType6 = new BusBodyType
                {
                    Name = "Traktorlar"
                };
                dbContext.BusBodyTypes.AddRange(busBodyType1, busBodyType2, busBodyType3, busBodyType4, busBodyType5, busBodyType6);

                BusMake busMake1 = new BusMake
                {
                    Name = "Belarus"
                };
                BusMake busMake2 = new BusMake
                {
                    Name = "Bobcat"
                };
                BusMake busMake3 = new BusMake
                {
                    Name = "Cat"
                };
                BusMake busMake4 = new BusMake
                {
                    Name = "Daf"
                };
                BusMake busMake5 = new BusMake
                {
                    Name = "FAW"
                };
                BusMake busMake6 = new BusMake
                {
                    Name = "Fiat"
                };
                BusMake busMake7 = new BusMake
                {
                    Name = "Ford"
                };
                BusMake busMake8 = new BusMake
                {
                    Name = "Foton"
                };
                BusMake busMake9 = new BusMake
                {
                    Name = "Howo"
                };
                BusMake busMake10 = new BusMake
                {
                    Name = "Hyundai"
                };
                BusMake busMake11 = new BusMake
                {
                    Name = "Iveco"
                };
                BusMake busMake12 = new BusMake
                {
                    Name = "JCB"
                };
                BusMake busMake13 = new BusMake
                {
                    Name = "Jungheinrich"
                };
                BusMake busMake14 = new BusMake
                {
                    Name = "Kamaz"
                };
                BusMake busMake15 = new BusMake
                {
                    Name = "Komatsu"
                };
                BusMake busMake16 = new BusMake
                {
                    Name = "Liebherr"
                };
                BusMake busMake17 = new BusMake
                {
                    Name = "MAN"
                };
                BusMake busMake18 = new BusMake
                {
                    Name = "Maz"
                };
                dbContext.BusMakes.AddRange(busMake1, busMake2, busMake3, busMake4, busMake5, busMake6, busMake7, busMake8, busMake9, busMake10, busMake11, busMake12,
                    busMake13, busMake14, busMake15, busMake16, busMake17, busMake18);

                Bus bus = new Bus(busBodyType1, 2014)
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 1,
                    Price = 4561,
                    CityId = 2,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    BusKilometer = 5415,
                    BusMakeId = busMake12.Id,
                    Condition = true,
                    AnnounceUniqueCode = "1",
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100100",
                    AppendedPinCode = true,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,

                };
                dbContext.Buses.AddRange(bus);

                BusPhoto busPhoto1 = new BusPhoto()
                {
                    Path = "/lib/images/transport/bus/vip1.jpg",
                    BusId = bus.Id
                };
                BusPhoto busPhoto2 = new BusPhoto()
                {
                    Path = "/lib/images/transport/bus/vip2.jpg",
                    BusId = bus.Id
                };
                dbContext.BusPhotos.AddRange(busPhoto1, busPhoto2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();

            }

            if (!dbContext.Motocycles.Any())
            {
                MotocycleBodyType bodyType1 = new MotocycleBodyType
                {
                    Name = "Baqqi"
                };
                MotocycleBodyType bodyType2 = new MotocycleBodyType
                {
                    Name = "Kvadrosikıllar",
                };
                MotocycleBodyType bodyType3 = new MotocycleBodyType
                {
                    Name = "Mopedlər"

                };
                MotocycleBodyType bodyType4 = new MotocycleBodyType
                {
                    Name = "motosikletlər"

                };
                MotocycleBodyType bodyType5 = new MotocycleBodyType
                {
                    Name = "Skuterlər"

                };
                dbContext.MotocycleBodyTypes.AddRange(bodyType1, bodyType2, bodyType3, bodyType4, bodyType5);

                MotocycleMake make1 = new MotocycleMake
                {
                    Name = "ABM"
                };
                MotocycleMake make2 = new MotocycleMake
                {
                    Name = "AMC"
                };
                MotocycleMake make3 = new MotocycleMake
                {
                    Name = "Aprilia"
                };
                MotocycleMake make4 = new MotocycleMake
                {
                    Name = "ATV"
                };
                MotocycleMake make5 = new MotocycleMake
                {
                    Name = "BMW"
                };
                MotocycleMake make6 = new MotocycleMake
                {
                    Name = "Can-Am"
                };
                MotocycleMake make7 = new MotocycleMake
                {
                    Name = "Chery"
                };
                MotocycleMake make8 = new MotocycleMake
                {
                    Name = "Chevrolet"
                };
                MotocycleMake make9 = new MotocycleMake
                {
                    Name = "Chituma"
                };
                MotocycleMake make10 = new MotocycleMake
                {
                    Name = "Dayun"
                };
                dbContext.MotocycleMakes.AddRange(make1, make2, make3, make4, make5, make6, make7, make8, make9, make10);

                Motocycle motocycle1 = new Motocycle(bodyType3, make10, 2015)
                {

                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 1,
                    Price = 5441,
                    CityId = 2,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    Condition = true,
                    MotocycleKilometer = 551,
                    MotocycleModel = "dasda",
                    AnnounceUniqueCode = "1",
                    MotocycleMotor = 5451,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100101",
                    AppendedPinCode = true,
                };
                dbContext.Motocycles.AddRange(motocycle1);

                MotocyclePhoto photo1 = new MotocyclePhoto()
                {
                    Path = "/lib/images/transport/motocycle/motocycle1.jpg",
                    MotocycleId = motocycle1.Id
                };
                MotocyclePhoto photo2 = new MotocyclePhoto()
                {
                    Path = "/lib/images/transport/motocycle/motocycle2.jpg",
                    MotocycleId = motocycle1.Id
                };
                dbContext.MotocyclePhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();


            }

            if (!dbContext.Accessories.Any())
            {
                AccessoryType accessoryType1 = new AccessoryType
                {
                    Name = "Aksesuarlar"
                };
                AccessoryType accessoryType2 = new AccessoryType
                {
                    Name = "Audio və video texnika"
                };
                AccessoryType accessoryType3 = new AccessoryType
                {
                    Name = "Avto kosmetika və kimya"
                };
                AccessoryType accessoryType4 = new AccessoryType
                {
                    Name = "Ehtiyyat hissələri"
                };
                AccessoryType accessoryType5 = new AccessoryType
                {
                    Name = "GPS-naviqatorları"
                };
                AccessoryType accessoryType6 = new AccessoryType
                {
                    Name = "Qeydiyyat nişanları"
                };
                AccessoryType accessoryType7 = new AccessoryType
                {
                    Name = "Siqnalizasiyalar"
                };

                dbContext.AccessoryTypes.AddRange(accessoryType1, accessoryType2, accessoryType3, accessoryType4, accessoryType5, accessoryType6, accessoryType7);

                Accessory accessory1 = new Accessory
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 1,
                    Price = 5448,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 2,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    AnnounceName = "Avtomobil fara və stop işığı",
                    AccessoryTypeId = accessoryType1.Id,
                    Condition = true,
                    AnnounceUniqueCode = "1",
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100102",
                    AppendedPinCode = true,

                };

                dbContext.Accessories.AddRange(accessory1);


                AccessoryPhoto photo1 = new AccessoryPhoto()
                {
                    Path = "/lib/images/transport/accessory/accessory1.jpg",
                    AccessoryId = accessory1.Id
                };
                AccessoryPhoto photo2 = new AccessoryPhoto()
                {
                    Path = "/lib/images/transport/accessory/accessory2.jpg",
                    AccessoryId = accessory1.Id
                };
                dbContext.AccessoryPhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();

            }

            if (!dbContext.Apartments.Any())
            {
                RSAnnounceType rSAnnounceType1 = new RSAnnounceType
                {
                    Name = "Satılır"
                };
                RSAnnounceType rSAnnounceType2 = new RSAnnounceType
                {
                    Name = "Kirayə verilir"
                };
                dbContext.RSAnnounceTypes.AddRange(rSAnnounceType1, rSAnnounceType2);

                ApartmentType apartmentType1 = new ApartmentType
                {
                    Name = "Yeni tikili"
                };
                ApartmentType apartmentType2 = new ApartmentType
                {
                    Name = "Köhnə tikili"
                };
                dbContext.ApartmentTypes.AddRange(apartmentType1, apartmentType2);

                Apartment apartment1 = new Apartment(3, "Nizami metrosu", 445)
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    ApartmentTypeId = apartmentType1.Id,
                    RSAnnounceTypeId = rSAnnounceType2.Id,
                    AnnounceUniqueCode = "1",
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100103",
                    AppendedPinCode = true,

                };
                dbContext.Apartments.AddRange(apartment1);

                ApartmentPhoto photo1 = new ApartmentPhoto()
                {
                    Path = "/lib/images/realestate/apartment/apartment1.jpg",
                    ApartmentId = apartment1.Id
                };
                ApartmentPhoto photo2 = new ApartmentPhoto()
                {
                    Path = "/lib/images/realestate/apartment/apartment2.jpg",
                    ApartmentId = apartment1.Id
                };
                dbContext.ApartmentPhotos.AddRange(photo1, photo2);


                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.Houses.Any())
            {
                HouseType houseType1 = new HouseType
                {
                    Name = "Bağ evi"
                };
                HouseType houseType2 = new HouseType
                {
                    Name = "Həyət evi"
                };
                HouseType houseType3 = new HouseType
                {
                    Name = "Villa"
                };

                dbContext.HouseTypes.AddRange(houseType1, houseType2, houseType3);

                House house = new House(houseType1, "28 may")
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    RSAnnounceTypeId = 1,
                    AnnounceUniqueCode = "1",
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100104",
                    AppendedPinCode = true,


                };

                dbContext.Houses.AddRange(house);


                HousePhoto photo1 = new HousePhoto()
                {
                    Path = "/lib/images/realestate/house/house1.jpg",
                    HouseId = house.Id
                };
                HousePhoto photo2 = new HousePhoto()
                {
                    Path = "/lib/images/realestate/house/house2.jpg",
                    HouseId = house.Id
                };
                dbContext.HousePhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.Offices.Any())
            {
                OfficeType officeType1 = new OfficeType
                {
                    Name = "Ofis"
                };
                OfficeType officeType2 = new OfficeType
                {
                    Name = "Obyekt"
                };
                OfficeType officeType3 = new OfficeType
                {
                    Name = "Mağaza"
                };

                dbContext.OfficeTypes.AddRange(officeType1, officeType2, officeType3);

                Office office = new Office(officeType1, "Sumqayit", 451)
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    RSAnnounceTypeId = 1,
                    AnnounceUniqueCode = "1",
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100105",
                    AppendedPinCode = true,

                };

                dbContext.Offices.AddRange(office);

                OfficePhoto photo1 = new OfficePhoto()
                {
                    Path = "/lib/images/realestate/office/office1.jpg",
                    OfficeId = office.Id
                };
                OfficePhoto photo2 = new OfficePhoto()
                {
                    Path = "/lib/images/realestate/office/office2.jpg",
                    OfficeId = office.Id
                };
                dbContext.OfficePhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.Garages.Any())
            {


                Garage garage = new Garage
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    AnnounceName = "Qaraj, Yeni Yasamal q.",
                    AnnounceUniqueCode = "1",
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100106",
                    AppendedPinCode = true,
                    Area = 5151,
                    GarageLocation = "Nizami metrosu",

                };


                dbContext.Garages.AddRange(garage);

                GaragePhoto photo1 = new GaragePhoto()
                {
                    Path = "/lib/images/realestate/garage/garage1.jpg",
                    GarageId = garage.Id
                };
                GaragePhoto photo2 = new GaragePhoto()
                {
                    Path = "/lib/images/realestate/garage/garage2.jpg",
                    GarageId = garage.Id
                };
                dbContext.GaragePhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.Lands.Any())
            {


                Land land = new Land(551, "Sahil metrosu")
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    AnnounceUniqueCode = "1",
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100107",
                    AppendedPinCode = true,
                };

                dbContext.Lands.AddRange(land);

                LandPhoto photo1 = new LandPhoto()
                {
                    Path = "/lib/images/realestate/land/land1.jpg",
                    LandId = land.Id
                };
                LandPhoto photo2 = new LandPhoto()
                {
                    Path = "/lib/images/realestate/land/land2.jpg",
                    LandId = land.Id
                };
                dbContext.LandPhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.Jobs.Any())
            {
                JobType jobType1 = new JobType
                {
                    Name = "İş axtarıram"
                };
                JobType jobType2 = new JobType
                {
                    Name = "İş təklif edirəm"
                };

                dbContext.JobTypes.AddRange(jobType1, jobType2);

                ActivityArea activityArea1 = new ActivityArea
                {
                    Name = "Maliyyə"
                };
                ActivityArea activityArea2 = new ActivityArea
                {
                    Name = "Marketinq"
                };
                ActivityArea activityArea3 = new ActivityArea
                {
                    Name = "İnzibati"
                };
                ActivityArea activityArea4 = new ActivityArea
                {
                    Name = "Satış"
                };
                ActivityArea activityArea5 = new ActivityArea
                {
                    Name = "Reklam və dizayn"
                };
                ActivityArea activityArea6 = new ActivityArea
                {
                    Name = "Hüquqşünaslıq"
                };

                dbContext.ActivityAreas.AddRange(activityArea1, activityArea2, activityArea3, activityArea4, activityArea5, activityArea6);

                Job job = new Job
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    AnnounceName = "Çilingər tələb olunur",
                    ActivityAreaId = activityArea4.Id,
                    AnnounceUniqueCode = "1",
                    JobTypeId = jobType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100108",
                    AppendedPinCode = true,
                };

                dbContext.Jobs.AddRange(job);

                JobPhoto photo1 = new JobPhoto()
                {
                    Path = "/lib/images/jobs/job/job1.jpg",
                    JobId = job.Id
                };
                JobPhoto photo2 = new JobPhoto()
                {
                    Path = "/lib/images/jobs/job/job2.jpg",
                    JobId = job.Id
                };
                dbContext.JobPhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.BusinessEquipments.Any())
            {
                BusinessType businessType1 = new BusinessType
                {
                    Name = "Mağaza üçün"
                };
                BusinessType businessType2 = new BusinessType
                {
                    Name = "Ofis üçün"
                };

                dbContext.BusinessTypes.AddRange(businessType1, businessType2);

                BusinessEquipment businessEquipment = new BusinessEquipment
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    PhoneNumber = "0566516512",
                    AnnounceUniqueCode = "1",
                    AnnounceName = "Vitrinlər",
                    BusinessTypeId = businessType1.Id,
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100109",
                    AppendedPinCode = true,
                };

                dbContext.BusinessEquipments.AddRange(businessEquipment);

                BusinessEPhoto photo1 = new BusinessEPhoto()
                {
                    Path = "/lib/images/jobs/business/business1.jpg",
                    BusinessEquipmentId = businessEquipment.Id
                };
                BusinessEPhoto photo2 = new BusinessEPhoto()
                {
                    Path = "/lib/images/jobs/business/business2.jpg",
                    BusinessEquipmentId = businessEquipment.Id
                };
                dbContext.BusinessEPhotos.AddRange(photo1, photo2);

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.Foods.Any())
            {
                Food food = new Food
                {
                    AnnounceAddedDate = DateTime.Now,
                    AnnounceTypeId = 2,
                    Price = 541,
                    CityId = 1,
                    Description = "Loremwas popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    PersonTypeId = 1,
                    Email = "elshad@code.edu.az",
                    AnnounceUniqueCode = "1",
                    PhoneNumber = "0566516512",
                    AnnounceName = "Süd və süd məhsulları",
                    AnnounceCheckIn = true,
                    AnnouncePublished = true,
                    AnnouncePublishDate = DateTime.Now,
                    AnnouncePinCode = "100110",
                    AppendedPinCode = true,
                };

                dbContext.Foods.AddRange(food);

                FoodPhoto photo1 = new FoodPhoto()
                {
                    Path = "/lib/images/jobs/food/food1.jpg",
                    FoodId = food.Id
                };
                FoodPhoto photo2 = new FoodPhoto()
                {
                    Path = "/lib/images/jobs/food/food2.jpg",
                    FoodId = food.Id
                };
                dbContext.FoodPhotos.AddRange(photo1, photo2);

                dbContext.Statics.Add(new Static
                {
                    PinCode = "100110"
                });

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }

            if (!dbContext.Users.Any())
            {
                AppUser appUser1 = new AppUser
                {
                    UserName = "shahin",
                    Email = "elshad@gmail.com"
                };
                IdentityResult result1 = userManager.CreateAsync(appUser1, "ilkin12").GetAwaiter().GetResult();

                List<string> roles = new List<string>();
                string[] rolesType = Enum.GetNames(typeof(RoleType));
                roles.AddRange(rolesType);
                if (result1.Succeeded)
                {
                    IdentityResult roleResult = userManager.AddToRolesAsync(appUser1, rolesType).GetAwaiter().GetResult();
                }
                AppUser appUser2 = new AppUser
                {
                    UserName = "nicat",
                    Email = "ilkin@gmail.com"
                };
                IdentityResult result2 = userManager.CreateAsync(appUser2, "elshad12").GetAwaiter().GetResult();
                if (result2.Succeeded)
                {
                    IdentityResult roleResult = userManager.AddToRoleAsync(appUser2, "User").GetAwaiter().GetResult();
                }
            }
        }
    }
}
