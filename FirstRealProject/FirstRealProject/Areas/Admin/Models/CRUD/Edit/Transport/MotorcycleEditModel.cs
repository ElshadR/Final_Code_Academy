using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Transports.MotocycleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport
{
	public class MotorcycleEditModel:AnnounceA
	{
        public MotorcycleEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            MotocycleMakes = new HashSet<MotocycleMake>();
            MotocyclePhotos = new HashSet<MotocyclePhoto>();
        } 
        [Required]
		public string MotocycleModel { get; set; }
        [Required]
		public int MotocycleMakeId { get; set; }

		[Required]
		public int MotocycleBodyTypeId { get; set; }

		[Required]
		public int MotocycleMotor { get; set; }

		[Required]
		public int MotocycleYear { get; set; }

		[Required]
		public int MotocycleKilometer { get; set; }

		public bool Condition { get; set; }
		public bool ConditionCredit { get; set; }
		public bool ConditionBarter { get; set; }

		public virtual ICollection<MotocycleBodyType> MotocycleBodyTypes { get; set; }
		public virtual ICollection<MotocycleMake> MotocycleMakes { get; set; }
        public virtual ICollection<MotocyclePhoto> MotocyclePhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
