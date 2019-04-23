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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.Settings
{
    public class SettingModel
    {
        public SettingModel()
        {
            CarMakes = new HashSet<CarMake>();
            CarModels = new HashSet<CarModel>();
            CarBodyTypes = new HashSet<CarBodyType>();
            BusMakes = new HashSet<BusMake>();
            BusBodyTypes = new HashSet<BusBodyType>();
            AccessoryTypes = new HashSet<AccessoryType>();
            JobActivityAreas = new HashSet<ActivityArea>();
            JobTypes = new HashSet<JobType>();
            MotocycleBodyTypes = new HashSet<MotocycleBodyType>();
            MotocycleMakes = new HashSet<MotocycleMake>();
            ApartmentTypes = new HashSet<ApartmentType>();
            HouseTypes = new HashSet<HouseType>();
            OfficeTypes = new HashSet<OfficeType>();
            BusinessTypes = new HashSet<BusinessType>();
            Cities = new HashSet<City>();
            RETypes = new HashSet<RSAnnounceType>();
        }
        public ICollection<CarMake> CarMakes { get; set; }
        public ICollection<CarModel> CarModels { get;  set; }
        public ICollection<CarBodyType> CarBodyTypes { get;  set; }
        public ICollection<BusMake> BusMakes { get;  set; }
        public ICollection<BusBodyType> BusBodyTypes { get;  set; }
        public ICollection<MotocycleMake> MotocycleMakes { get;  set; }
        public ICollection<MotocycleBodyType> MotocycleBodyTypes { get;  set; }
        public ICollection<AccessoryType> AccessoryTypes { get;  set; }
        public ICollection<ActivityArea> JobActivityAreas { get;  set; }
        public ICollection<HouseType> HouseTypes { get;  set; }
        public ICollection<OfficeType> OfficeTypes { get;  set; }
        public ICollection<ApartmentType> ApartmentTypes { get;  set; }
        public ICollection<JobType> JobTypes { get;  set; }
        public ICollection<BusinessType> BusinessTypes { get;  set; }
        public ICollection<City> Cities { get; internal set; }
        public ICollection<RSAnnounceType> RETypes { get; internal set; }
    }
}
