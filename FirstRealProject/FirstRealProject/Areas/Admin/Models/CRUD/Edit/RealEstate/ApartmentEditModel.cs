using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Real_Estates.ApartmentModels;
using FirstRealProject.Models.Real_Estates.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate
{
	public class ApartmentEditModel:AnnounceA
	{
        public ApartmentEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            RSAnnounceTypes = new HashSet<RSAnnounceType>();
            ApartmentTypes = new HashSet<ApartmentType>();
            ApartmentPhotos = new HashSet<ApartmentPhoto>();
        }
		[Required]
		public int RSAnnounceTypeId { get; set; }

		[Required]
		public int ApartmentTypeId { get; set; }

		[Required]
		[Column(TypeName = "decimal(15,2)")]
		public decimal Area { get; set; }

		[Required]
		public byte RoomCount { get; set; }

		[Required]
		public string ApartamentLocation { get; set; }

		public virtual ICollection<RSAnnounceType> RSAnnounceTypes { get; set; }
		public virtual ICollection<ApartmentType> ApartmentTypes { get; set; }
		public virtual ICollection<ApartmentPhoto> ApartmentPhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
