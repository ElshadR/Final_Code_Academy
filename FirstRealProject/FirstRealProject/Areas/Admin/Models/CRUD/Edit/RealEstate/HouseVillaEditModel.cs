using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Real_Estates.Commons;
using FirstRealProject.Models.Real_Estates.HouseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate
{
	public class HouseVillaEditModel:AnnounceA
	{
        public HouseVillaEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            RSAnnounceTypes = new HashSet<RSAnnounceType>();
            HouseTypes = new HashSet<HouseType>();
            HousePhotos = new HashSet<HousePhoto>();
        }
		[Required]
		public int RSAnnounceTypeId { get; set; }

		[Required]
		public int HouseTypeId { get; set; }

		[Required]
		[Column(TypeName = "decimal(15,2)")]
		public decimal Area { get; set; }

		[Required]
		public string HouseLocation { get; set; }

		public virtual ICollection<RSAnnounceType> RSAnnounceTypes { get; set; }
		public virtual ICollection<HouseType> HouseTypes { get; set; }
		public virtual ICollection<HousePhoto> HousePhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
