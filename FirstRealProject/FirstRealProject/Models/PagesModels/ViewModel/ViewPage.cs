using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForJob;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using FirstRealProject.Models.Real_Estates.ApartmentModels;
using FirstRealProject.Models.Real_Estates.Commons;
using FirstRealProject.Models.Real_Estates.HouseModels;
using FirstRealProject.Models.Real_Estates.OfficeModels;
using FirstRealProject.Models.Transports.AccessoryModels;
using FirstRealProject.Models.Transports.BusModels;
using FirstRealProject.Models.Transports.CarModels;
using FirstRealProject.Models.Transports.MotocycleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel
{
    public class ViewPage
    {
        internal string announceFoodIds;

        public ViewPage()
        {
            ViewAnnouncesSimple = new List<ViewAnnounce>();
            ViewAnnouncesVip = new List<ViewAnnounce>();
            ViewAnnouncesPremium = new List<ViewAnnounce>();
            LastAnnounces = new List<ViewAnnounce>();
            //car
            CarMakes = new List<CarMake>();
            //bus
            BusBodyTypes = new List<BusBodyType>();
            BusMakes = new List<BusMake>();
        }
        public string announceIds { get; set; }

        public IEnumerable<ViewAnnounce> ViewAnnouncesSimple { get; set; }
        public IEnumerable<ViewAnnounce> ViewAnnouncesVip { get; set; }
        public IEnumerable<ViewAnnounce> ViewAnnouncesPremium { get; set; }
        public IEnumerable<ViewAnnounce> LastAnnounces { get; set; }

        public Pagination Pagination { get; set; }
        public string AnnounceTypeName { get; set; }
        //common
        public IEnumerable<City> Cities { get; set; }
        public int? CityId { get; set; }
        public int? BPrice { get; set; }
        public int? SPrice { get; set; }
        public string Name { get; set; }
        //transport
        public int Condition { get; set; }
        public bool ConditionCredit { get; set; }
        public bool ConditionBarter { get; set; }
        //Car
        public int? CarModelId { get; set; }
        public int? CarBodyTypeId { get; set; }
        public int? BYear { get; set; }
        public int? SYear { get; set; }
        public int? BKilometer { get; set; }
        public int? SKilometer { get; set; }
        public int? BMotor { get; set; }
        public int? SMotor { get; set; }
     
        public IEnumerable<CarMake> CarMakes { get; set; }
        public IEnumerable<CarBodyType> CarBodyTypes { get; set; }

        //bus
        public int? BusBodyTypeId { get; set; }
        public int? MakeId { get; set; }
        public IEnumerable<BusBodyType> BusBodyTypes { get; set; }
        public IEnumerable<BusMake> BusMakes { get; set; }

        //motocycle
        public int? MotocycleBodyTypeId { get; set; }
        public int? MotocycleMakeId { get; set; }
        public int? SMotorStrength { get; set; }
        public int? BMotorStrength { get; set; }
        public IEnumerable<MotocycleBodyType> MotocycleBodyTypes { get; set; }
        public IEnumerable<MotocycleMake> MotocycleMakes { get; set; }

        //accessory
        public int? AccessoryTypeId { get; set; }
        public IEnumerable<AccessoryType> AccessoryTypes { get; set; }


        //=============Real Estate
        public int? SArea { get; set; }
        public int? BArea { get; set; }
        public int? SRoomCount { get; set; }
        public int? BRoomCount { get; set; }
        public int? RETypeId { get; set; }
        public IEnumerable<RSAnnounceType> RSAnnounceTypes { get; set; }

        //Apartment
        public int? TypeId { get; set; }
        public IEnumerable<ApartmentType> ApartmentTypes { get; set; }

        //House
        public IEnumerable<HouseType> HouseTypes { get; set; }

        //Office
        public IEnumerable<OfficeType> OfficeTypes { get; set; }

        //Garage

        //Land

        // ===========jobs

        //job
        public int ActivityAreaId { get; set; }
        public IEnumerable<ActivityArea> ActivityAreas { get; set; }
        public IEnumerable<JobType> JobTypes { get; set; }
        //business
        public IEnumerable<BusinessType> BusinessTypes { get; set; }
        public string announceAccessoryIds { get;  set; }
        public string announceMotocycleIds { get;  set; }
        public string announceBusIds { get;  set; }
        public string announceApartmentIds { get;  set; }
        public string announceHouseIds { get;  set; }
        public string announceLandIds { get;  set; }
        public string announceGarageIds { get;  set; }
        public string announceJobIds { get;  set; }
        public string announceBusinessIds { get;  set; }
        public string announceOfficeIds { get; set; }

        //food

    }
}
