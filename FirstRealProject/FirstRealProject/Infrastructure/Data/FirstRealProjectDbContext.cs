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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Data
{
    public class FirstRealProjectDbContext:IdentityDbContext<AppUser, AppRole, string>
    {
        public FirstRealProjectDbContext(DbContextOptions<FirstRealProjectDbContext> dbContext):base(dbContext)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //car and autoEquipment hasmany withmany start
            modelBuilder.Entity<CarAutoEquipment>().HasKey(ca => new { ca.CarId, ca.AutoEquipmentId });

            modelBuilder.Entity<CarAutoEquipment>()
                .HasOne<Car>(ca => ca.Car)
                .WithMany(c => c.CarAutoEquipments)
                .HasForeignKey(ca =>new { ca.CarId});
            modelBuilder.Entity<CarAutoEquipment>()
               .HasOne<AutoEquipment>(ca => ca.AutoEquipment)
               .WithMany(a => a.CarAutoEquipments)
               .HasForeignKey(ca => ca.AutoEquipmentId);
            //car and autoEquipment hasmany withmany end


            //===============car start
            //car property key start
            modelBuilder.Entity<Car>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Car>().Property(c => c.AnnounceUniqueCode).IsUnicode();
            //car property key end

            //car property create index start
            modelBuilder.Entity<Car>().HasIndex(c => c.AnnounceName);
            modelBuilder.Entity<Car>().HasIndex(c => c.Price);
            modelBuilder.Entity<Car>().HasIndex(c => c.CarYear);

            //car property create index end


            base.OnModelCreating(modelBuilder);

        }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Static> Statics { get; set; }
        //---------Transport
        public virtual DbSet<AnnounceType> AnnounceTypes { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarMake> CarMakes { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarBodyType> CarBodyTypes { get; set; }
        public virtual DbSet<AutoEquipment> AutoEquipments { get; set; }
        public virtual DbSet<Motocycle> Motocycles { get; set; }
        public virtual DbSet<MotocycleMake> MotocycleMakes { get; set; }
        public virtual DbSet<MotocycleBodyType> MotocycleBodyTypes { get; set; }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<BusMake> BusMakes { get; set; }
        public virtual DbSet<BusBodyType> BusBodyTypes { get; set; }
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<AccessoryType> AccessoryTypes { get; set; }
        public virtual DbSet<CarPhoto> CarPhotos { get; set; }
        public virtual DbSet<MotocyclePhoto> MotocyclePhotos { get; set; }
        public virtual DbSet<AccessoryPhoto> AccessoryPhotos { get; set; }
        public virtual DbSet<BusPhoto> BusPhotos { get; set; }
        public virtual DbSet<CarAutoEquipment> CarAutoEquipments { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }
        public virtual DbSet<SpeedBox> SpeedBoxes { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }



        //---------RealEstate
        public virtual DbSet<RSAnnounceType> RSAnnounceTypes { get; set; }
		public virtual DbSet<ApartmentType> ApartmentTypes { get; set; }
		public virtual DbSet<Apartment> Apartments { get; set; }
		public virtual DbSet<Garage> Garages { get; set; }
		public virtual DbSet<House> Houses { get; set; }
		public virtual DbSet<HouseType> HouseTypes { get; set; }
		public virtual DbSet<Land> Lands { get; set; }
		public virtual DbSet<Office> Offices { get; set; }
		public virtual DbSet<OfficeType> OfficeTypes { get; set; }
		public virtual DbSet<ApartmentPhoto> ApartmentPhotos { get; set; }
		public virtual DbSet<OfficePhoto> OfficePhotos { get; set; }
		public virtual DbSet<GaragePhoto>  GaragePhotos { get; set; }
		public virtual DbSet<LandPhoto> LandPhotos { get; set; }
        public virtual DbSet<HousePhoto> HousePhotos { get; set; }



		//---------Job
		public virtual DbSet<BusinessEquipment> BusinessEquipments { get; set; }
		public virtual DbSet<BusinessType> BusinessTypes { get; set; }
		public virtual DbSet<Food> Foods { get; set; }
		public virtual DbSet<Job> Jobs { get; set; }
		public virtual DbSet<JobType> JobTypes { get; set; }
		public virtual DbSet<ActivityArea> ActivityAreas { get; set; }
		public virtual DbSet<BusinessEPhoto> BusinessEPhotos { get; set; }
		public virtual DbSet<FoodPhoto> FoodPhotos { get; set; }
		public virtual DbSet<JobPhoto> JobPhotos { get; set; }


        //----------Pages data models
        public virtual DbSet<BasicMenu> BasicMenus { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        


    }
}
