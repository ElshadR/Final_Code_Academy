using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Real_Estates.GarageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate
{
	public class GarageEditModel:AnnounceA
	{
        public GarageEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            GaragePhotos = new HashSet<GaragePhoto>();
        }
		[Required]
		[Column(TypeName = "decimal(15,2)")]
		public decimal Area { get; set; }

		[Required]
		public string GarageLocation { get; set; }

		public virtual ICollection<GaragePhoto> GaragePhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
