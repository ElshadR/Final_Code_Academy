using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.AccessoryModels
{
	[Table("AccessoryPhotos", Schema = "transport")]
    public class AccessoryPhoto:Photo
    {
        [Required]
        public virtual Accessory Accessory { get; set; }
        public int AccessoryId { get; set; }
    }
}
