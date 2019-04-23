using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForFoodModels;
using FirstRealProject.Models.Jobs.ForJob;
using FirstRealProject.Models.Real_Estates.ApartmentModels;
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

namespace FirstRealProject.Models.Accounts
{
	public class AppUser:IdentityUser
	{
        public AppUser()
        {
            Cars = new HashSet<Car>();
            Motocycles = new HashSet<Motocycle>();
            Accessories = new HashSet<Accessory>();
            Buses = new HashSet<Bus>();
            Apartments = new HashSet<Apartment>();
            Houses = new HashSet<House>();
            Offices = new HashSet<Office>();
            Garages = new HashSet<Garage>();
            Lands = new HashSet<Land>();
            Jobs = new HashSet<Job>();
            BusinessEquipments = new HashSet<BusinessEquipment>();
            Foods = new HashSet<Food>();
        }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Motocycle> Motocycles { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<House> Houses { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
        public virtual ICollection<Garage> Garages { get; set; }
        public virtual ICollection<Land> Lands { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<BusinessEquipment> BusinessEquipments { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
