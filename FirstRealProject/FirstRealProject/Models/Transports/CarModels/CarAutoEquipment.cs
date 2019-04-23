using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.CarModels
{
	[Table("CarAutoEquipments", Schema = "transport")]
    public class CarAutoEquipment
	{
        public virtual Car Car { get; set; }
        public int CarId { get; set; }
        //public string CarAnnounceUniCode { get; set; }

        public virtual AutoEquipment AutoEquipment { get; set; }
        public int AutoEquipmentId { get; set; }
    }
}
