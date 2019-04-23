using FirstRealProject.Areas.Admin.Models.Commons;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForJob;
using FirstRealProject.Models.Jobs.ForJobModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.CRUD.Edit.Jobs
{
	public class JobEditModel:AnnounceA

	{
        public JobEditModel()
        {
            AnnounceTypes = new HashSet<AnnounceType>();
            PersonTypes = new HashSet<PersonType>();
            PaymentTypes = new HashSet<PaymentType>();
            ActivityAreas = new HashSet<ActivityArea>();
            JobTypes = new HashSet<JobType>();
            JobPhotos = new HashSet<JobPhoto>();
        }
		[Required]
		public int ActivityAreaId { get; set; }

		[Required]
		public int JobTypeId { get; set; }

		public virtual ICollection<ActivityArea> ActivityAreas { get; set; }
		public virtual ICollection<JobType> JobTypes { get; set; }
		public virtual ICollection<JobPhoto> JobPhotos { get; set; }
        public ICollection<AnnounceType> AnnounceTypes { get; set; }
        public ICollection<PersonType> PersonTypes { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; internal set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
