using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.PagesModels;
using FirstRealProject.Models.Transports.CarModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport
{
    public class CarEditModel : AnnounceA
    {
        public CarEditModel()
        {
             Models = new HashSet<CarModel>();
            Makes = new HashSet<CarMake>();
            BodyTypes = new HashSet<CarBodyType>();
            SpeedBoxes = new HashSet<SpeedBox>();
            Transmissions = new HashSet<Transmission>();
            FuelTypes = new HashSet<FuelType>();
            AutoEquipments = new HashSet<AutoEquipment>();
            SelectedAutoEquipments = new HashSet<AutoEquipment>();
            AutoEquipmentId = new HashSet<int>();
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
        }

		[Required]
		public int ModelId { get; set; }

		[Required]
		public int MakeId { get; set; }

		[Required]
		public int BodyTypeId { get; set; }

		[Required]
		public int SpeedBoxId { get; set; }

		[Required]
		public int TransmissionId { get; set; }

        [Required]
		public int FuelTypeId { get; set; }

		[Required]
		public string Color { get; set; }

		[Required]
		public int Motor { get; set; }

		[Required]
		public int MotorStrength { get; set; }

		[Required]
		public int Year { get; set; }

		[Required]
		public int Kilometer { get; set; }

		[Required]
		public bool Condition { get; set; }
		[Required]
		public bool ConditionCredit { get; set; }
		[Required]
		public bool ConditionBarter { get; set; }

		public  ICollection<CarModel> Models { get; set; }
		public  ICollection<CarMake> Makes { get; set; }
        public  ICollection<CarBodyType> BodyTypes { get; set; }
		public  ICollection<SpeedBox> SpeedBoxes { get; set; }
		public  ICollection<Transmission> Transmissions { get; set; }
		public  ICollection<FuelType> FuelTypes { get; set; }

		public  ICollection<int> AutoEquipmentId { get; set; }
		public  ICollection<AutoEquipment> AutoEquipments { get; set; }
        public  ICollection<AutoEquipment> SelectedAutoEquipments { get; set; }
        public  ICollection<CarPhoto> Photos { get; set; }
        public  ICollection<AnnounceType> AnnounceTypes { get; set; }
        public  ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get;  set; }
        public string ControllerName { get;  set; }
        public string ActionName { get;  set; }
    }
}
