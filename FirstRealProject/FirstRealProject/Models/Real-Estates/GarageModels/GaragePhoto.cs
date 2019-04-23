using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.GarageModels
{
	[Table("GaragePhotos", Schema = "real_estate")]
    public class GaragePhoto:Photo
    {
        [Required]
        public virtual Garage Garage { get; set; }
        public int GarageId { get; set; }
    }
}
