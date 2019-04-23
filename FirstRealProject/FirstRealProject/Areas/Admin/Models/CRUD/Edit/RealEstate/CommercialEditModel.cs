using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Real_Estates.Commons;
using FirstRealProject.Models.Real_Estates.OfficeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate
{
	public class CommercialEditModel:AnnounceA
	{
        public CommercialEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            RSAnnounceTypes = new HashSet<RSAnnounceType>();
            OfficeTypes = new HashSet<OfficeType>();
            OfficePhotos = new HashSet<OfficePhoto>();
        }
		[Required]
		public int RSAnnounceTypeId { get; set; }

		[Required]
		public int OfficeTypeId { get; set; }

		[Required]
		public string OfficeLocation { get; set; }

		[Required]
		public int OfficeArea { get; set; }

		public virtual ICollection<RSAnnounceType> RSAnnounceTypes { get; set; }
		public virtual ICollection<OfficeType> OfficeTypes { get; set; }
		public virtual ICollection<OfficePhoto> OfficePhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
