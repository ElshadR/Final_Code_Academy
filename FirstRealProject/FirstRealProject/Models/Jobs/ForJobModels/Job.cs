using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Jobs.ForJobModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Jobs.ForJob
{
	[Table("Jobs", Schema ="jobs")]
	public class Job:Announce
	{
        public Job()
        {
            JobPhotos = new HashSet<JobPhoto>();
        }

        public virtual ICollection<JobPhoto> JobPhotos { get; set; }

        [Required]
        public virtual ActivityArea ActivityArea { get; set; }
		public int ActivityAreaId { get; set; }

		[Required]
        public virtual JobType JobType { get; set; }
		public int JobTypeId { get; set; }
    }
}
