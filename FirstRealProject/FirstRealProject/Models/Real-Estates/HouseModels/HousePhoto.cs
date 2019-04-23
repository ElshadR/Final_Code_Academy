using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.HouseModels
{
	[Table("HousePhotos", Schema = "real_estate")]
    public class HousePhoto:Photo
    {
        [Required]
        public virtual House House { get; set; }
        public int HouseId { get; set; }
    }
}
