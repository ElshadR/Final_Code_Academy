using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.BusModels
{
	[Table("BusPhotos", Schema = "transport")]
    public class BusPhoto:Photo
    {
        [Required]
        public virtual Bus Bus { get; set; }
        public int BusId { get; set; }
    }
}
