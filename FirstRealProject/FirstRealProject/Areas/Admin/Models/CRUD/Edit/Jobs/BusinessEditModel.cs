using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.Jobs
{
	public class BusinessEditModel:AnnounceA
	{
        public BusinessEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            BusinessTypes = new HashSet<BusinessType>();
            BusinessEPhotos = new HashSet<BusinessEPhoto>();
        }

		[Required]
		public int BusinessTypeId { get; set; }

		public virtual ICollection<BusinessType> BusinessTypes { get; set; }
		public virtual ICollection<BusinessEPhoto> BusinessEPhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
