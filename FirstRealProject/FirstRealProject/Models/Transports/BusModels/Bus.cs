using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.BusModels
{
	[Table("Buses", Schema = "transport")]
    public class Bus : Announce
	{

        public Bus()
        {

        }

        public Bus(BusBodyType bodyType, int year)
        {
            this.AnnounceName = bodyType.Name + ", " + year;
            this.BusBodyTypeId = bodyType.Id;
            this.BusYear = year;
        }

        public virtual ICollection<BusPhoto> BusPhotos { get; set; }

        [Required]
        public virtual BusMake BusMake { get; set; }
        public int BusMakeId { get; set; }

        [Required]
        public virtual BusBodyType BusBodyType { get; set; }
        public int BusBodyTypeId { get; set; }

        [Required]
        public int BusYear { get; set; }

        [Required]
        public int BusKilometer { get; set; }

        [Required]
        public bool Condition { get; set; }
        [Required]
        public bool ConditionCredit { get; set; }
        [Required]
        public bool ConditionBarter { get; set; }
        
    }
}
