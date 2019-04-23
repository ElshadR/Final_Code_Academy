using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Transports.BusModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport
{
	public class BusEditModel:AnnounceA
	{
        public BusEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
        }
        [Required]
		public int BusMakeId { get; set; }

		[Required]
		public int BusBodyTypeId { get; set; }

		[Required]
		public int BusYear { get; set; }

		[Required]
		public int BusKilometer { get; set; }

		[Required]
		public bool Condition { get; set; }
		[Required]
		public bool ConditionCredit { get; set; }
		[Required]
		public bool ConditionBarter { get; set; }


		public virtual ICollection<BusMake> BusMakes { get; set; }
		public virtual ICollection<BusPhoto> BusPhotos { get; set; }
		public virtual ICollection<BusBodyType> BusBodyTypes { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
