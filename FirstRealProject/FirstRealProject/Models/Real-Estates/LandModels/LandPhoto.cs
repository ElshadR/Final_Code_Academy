using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.LandModels
{
	[Table("LandPhotos", Schema = "real_estate")]
    public class LandPhoto: Photo
    {
        [Required]
        public virtual Land Land { get; set; }
        public int LandId { get; set; }
    }
}
