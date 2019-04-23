using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.CarModels
{
	[Table("CarPhotos", Schema = "transport")]
    public class CarPhoto : Photo
    {
        [Required]
        public virtual Car Car { get; set; }
        public int CarId { get; set; }
    }
}
