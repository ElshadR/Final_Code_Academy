using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Real_Estates.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.HouseModels
{
	[Table("Houses", Schema = "real_estate")]
	public class House:Announce
	{
        public House()
        {
        }
        public House(HouseType houseType,string location)
        {
            this.AnnounceName = houseType.Name + ", " + location;
            this.HouseLocation = location;
            this.HouseTypeId = houseType.Id;
            HousePhotos = new HashSet<HousePhoto>();
        }

        public virtual ICollection<HousePhoto> HousePhotos { get; set; }

        [Required]
        public virtual RSAnnounceType RSAnnounceType { get; set; }
		public int RSAnnounceTypeId { get; set; }

		[Required]
        public virtual HouseType HouseType { get; set; }
		public int HouseTypeId { get; set; }

		[Required]
		[Column(TypeName = "decimal(15,2)")]
		public decimal Area { get; set; }

		[Required]
		public string HouseLocation { get; set; }
    }
}
