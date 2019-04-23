using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.ApartmentModels
{
	[Table("ApartmentPhotos", Schema = "real_estate")]
    public class ApartmentPhoto : Photo
    {
        [Required]
        public virtual Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
    }
}
