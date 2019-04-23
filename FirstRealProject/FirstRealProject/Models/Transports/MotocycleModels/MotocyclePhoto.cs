using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.MotocycleModels
{

	[Table("MotocyclePhotos", Schema = "transport")]
    public class MotocyclePhoto : Photo
    {
        [Required]
        public virtual Motocycle Motocycle { get; set; }
        public int MotocycleId { get; set; }
    }
}
