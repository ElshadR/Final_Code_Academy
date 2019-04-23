using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.OfficeModels
{
	[Table("OfficePhotos", Schema = "real_estate")]
    public class OfficePhoto:Photo
    {
        [Required]
        public virtual Office Office { get; set; }
        public int OfficeId { get; set; }
    }
}
