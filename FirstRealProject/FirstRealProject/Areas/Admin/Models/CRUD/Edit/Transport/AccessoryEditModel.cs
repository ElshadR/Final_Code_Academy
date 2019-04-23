using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Transports.AccessoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport
{
	public class AccessoryEditModel:AnnounceA
	{
        public AccessoryEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            AccessoryTypes = new HashSet<AccessoryType>();
            PaymentTypes = new HashSet<PaymentType>();
        }
		[Required]
		public int AccessoryTypeId { get; set; }

		[Required]
		public bool Condition { get; set; }

		public virtual ICollection<AccessoryType> AccessoryTypes { get; set; }
		public virtual ICollection<AccessoryPhoto> AccessoryPhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get;  set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
