using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.CarModels
{
	[Table("Cars", Schema = "transport")]
    public class Car: Announce
	{
        private FirstRealProjectDbContext _dbContext { get; set; }

        public Car()
        {
            
        }
        public Car(CarMake make,CarModel model,int year)
        {
            CarAutoEquipments = new HashSet<CarAutoEquipment>();
            CarPhotos = new HashSet<CarPhoto>();
            base.AnnounceName = make.Name + " " + model.Name + ", " + year;
            this.CarModelId = model.Id;
            this.CarYear = year;
        }

        [Required]
        public virtual CarModel CarModel { get; set; }
        public int CarModelId { get; set; }

        [Required]
        public virtual CarBodyType CarBodyType { get; set; }
        public int CarBodyTypeId { get; set; }

        [Required]
        public virtual SpeedBox SpeedBox { get; set; }
        public int SpeedBoxId { get; set; }

        [Required]
        public virtual Transmission Transmission { get; set; }
        public int TransmissionId { get; set; }

        [Required]
        public virtual FuelType FuelType { get; set; }
        public int FuelTypeId { get; set; }

        [Required]
        public string Color { get; set; }


        [Required]
        public int CarMotor { get; set; }

        [Required]
        public int CarMotorStrength { get; set; }

        [Required]
        public int CarYear { get; set; }

        [Required]
        public int CarKilometer { get; set; }

        [Required]
        public bool Condition { get; set; }
        [Required]
        public bool ConditionCredit { get; set; }
        [Required]
        public bool ConditionBarter { get; set; }

       

        public virtual ICollection<CarAutoEquipment> CarAutoEquipments { get; set; }
        public virtual ICollection<CarPhoto> CarPhotos { get; set; }
    }
}
