using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.AccessoryModels
{
	[Table("Accessories", Schema = "transport")]
    public class Accessory: Announce
	{
        public Accessory()
        {
            AccessoryPhotos = new HashSet<AccessoryPhoto>();
        }

        public virtual ICollection<AccessoryPhoto> AccessoryPhotos { get; set; }

        [Required]
        public virtual AccessoryType AccessoryType { get; set; }
        public int AccessoryTypeId { get; set; }

        [Required]
        public bool Condition { get; set; }

        
    }
}
