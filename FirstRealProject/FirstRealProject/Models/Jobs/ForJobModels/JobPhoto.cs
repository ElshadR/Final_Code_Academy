using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Jobs.ForJob;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Jobs.ForJobModels
{
	[Table("JobPhotos", Schema ="jobs")]
    public class JobPhoto:Photo
    {
        [Required]
        public virtual Job Job { get; set; }
        public int JobId { get; set; }
    }
}
