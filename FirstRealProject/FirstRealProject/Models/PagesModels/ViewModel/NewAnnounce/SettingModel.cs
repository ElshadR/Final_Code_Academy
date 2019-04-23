using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using FirstRealProject.Models.Jobs.ForJob;
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce
{
    public class SettingModel
    {
        public SettingModel()
        {
            City = new List<City>();
            CarMakes = new List<CarMake>();
            SpeedBoxes = new List<SpeedBox>();
            Transmissions = new List<Transmission>();
            FuelTypes = new List<FuelType>();
            CarBodyTypes = new List<CarBodyType>();
            AutoEquipments = new List<AutoEquipment>();
            BusMakes = new List<BusMake>();
            BusBodyTypes = new List<BusBodyType>();
            MotocycleMakes = new List<MotocycleMake>();
            MotocycleBodyTypes = new List<MotocycleBodyType>();
            AccessoryTypes = new List<AccessoryType>();
            ApartmentTypes = new List<ApartmentType>();
            HouseTypes = new List<HouseType>();
            OfficeTypes = new List<OfficeType>();
            BusinessTypes = new List<BusinessType>();
            JobTypes = new List<JobType>();
            ActivityAreas = new List<ActivityArea>();
            AutoEquipmentId = new List<int>();
            PersonTypes = new List<PersonType>();
            RSAnnounceTypes = new List<RSAnnounceType>();
            CarModels = new List<CarModel>();
            AnnounceTypes = new List<AnnounceType>();
        }

        public List<PersonType> PersonTypes { get; set; }
        public List<AnnounceType> AnnounceTypes { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int PersonTypeId { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string PersonName { get; set; }
        //==========Transport start============

        //car
        public List<City> City { get; set; }
        public AnnounceType VipPrice { get; set; }
        public List<CarMake> CarMakes { get; set; }
        public List<CarModel> CarModels { get; set; }
        public List<SpeedBox> SpeedBoxes { get; set; }
        public List<Transmission> Transmissions { get; set; }
        public List<FuelType> FuelTypes { get; set; }
        public List<CarBodyType> CarBodyTypes { get; set; }
        public List<AutoEquipment> AutoEquipments { get; set; }
        //bus
        public List<BusMake> BusMakes { get; set; }
        public List<BusBodyType> BusBodyTypes { get; set; }
        //motocycle
        public List<MotocycleMake> MotocycleMakes { get; set; }
        public List<MotocycleBodyType> MotocycleBodyTypes { get; set; }
        //accessory
        public List<AccessoryType> AccessoryTypes { get; set; }
        //==========Transport end============
        //==========Real Estate start============
        public List<RSAnnounceType> RSAnnounceTypes { get; set; }
        //Apartment
        public List<ApartmentType> ApartmentTypes { get; set; }
        //Garage

        //House
        public List<HouseType> HouseTypes { get; set; }
        //Land
        //Office
        public List<OfficeType> OfficeTypes { get; set; }
        //==========Real Estate end============
        //==========Jobs stort============
        //Food
        //Business
        public List<BusinessType> BusinessTypes { get; set; }
        //Job
        public List<JobType> JobTypes { get; set; }
        public List<ActivityArea> ActivityAreas { get; set; }
        //==========Jobs end============

        //common
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int CityId { get; set; }

       

        [Column(TypeName = "decimal(15,2)")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusYear { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string PhoneNumber { get; set; }

        

        public int AnnounceTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int PaymentTypeId { get; set; }

        //bus
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusMakeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusBodyTypeId { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusKilometer { get; set; }

        public bool BusCondition { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 2, ErrorMessage = "2 hərfdən çox olmalıdı")]
        public string BusName { get; set; }


        //car
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int CarMakeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int CarModelId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int CarBodyTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int SpeedBoxId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int TransmissionId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int FuelTypeId { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        public int CarMotor { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int CarMotorStrength { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int CarYear { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int CarKilometer { get; set; }

        public bool CarCondition { get; set; }

        public List<int> AutoEquipmentId { get; set; }

        //motocycle

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string MotocycleModel { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleBodyTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleMakeId { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string MotocycleMotor { get; set; }

        public DateTime MotocycleYear { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleKilometer { get; set; }

        public bool MotocycleCondition { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 1, ErrorMessage = "1 hərfdən çox olmalıdı")]
        public string MotocycleName { get; set; }

        //accessory
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int AccessoryTypeId { get; set; }

        public bool AccessoryCondition { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string AccessoryName { get; set; }

        //========== Transport end===========

        //==============Real Estate start==============
      
        //apartment
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int ApartmentTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int RSAnnounceTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal ApartmentArea { get; set; }

        public byte ApartmentRoomCount { get; set; }

        [Required(ErrorMessage = "Boş olmaz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string ApartamentLocation { get; set; }

        //house
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int HouseTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal HouseArea { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int HouseRSAnnounceTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string HouseLocation { get; set; }
        //office
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int OfficeTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal OfficeArea { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int OfficeRSAnnounceTypeId { get; set; }

      


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string OfficeLocation { get; set; }
        //qarage
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal GarageArea { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string GarageName { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string GarageLocation { get; set; }
        //land
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal LandArea { get; set; }


        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərfdən çox olmalıdı")]
        public string LandLocation { get; set; }
        //==============Real Estate end==============

        //==============jobs end==============
        //job
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 1, ErrorMessage = "1 hərfdən çox olmalıdı")]
        public string JobName { get; set; }

        [Required]
        public int JobActivityAreaId { get; set; }

        [Required]
        public int JobTypeId { get; set; }

        //business
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 1, ErrorMessage = "1 hərfdən çox olmalıdı")]
        public string BusinessName { get; set; }

        [Required]
        public int BusinessTypeId { get; set; }
        //food
        //==============jobs end==============
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 1, ErrorMessage = "1 hərfdən çox olmalıdı")]
        public string FoodName { get; set; }


        //Photo
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "minimum 1 şəkil")]
        public int PhotoLength { get; set; }

    }
}
