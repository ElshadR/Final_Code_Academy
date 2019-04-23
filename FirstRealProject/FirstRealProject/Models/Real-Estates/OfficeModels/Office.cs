using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Real_Estates.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.OfficeModels
{
	[Table("Offices", Schema = "real_estate")]
	public class Office: Announce
	{
        public Office()
        {
        }
        public Office(OfficeType officeType,string location, int area)
        {
            this.AnnounceName = officeType.Name +", " + location;
            this.OfficeLocation = location;
            this.OfficeArea = area;
            this.OfficeTypeId = officeType.Id;
            OfficePhotos = new HashSet<OfficePhoto>();
        }

        public virtual ICollection<OfficePhoto> OfficePhotos { get; set; }

        [Required]
        public virtual RSAnnounceType RSAnnounceType { get; set; }
		public int RSAnnounceTypeId { get; set; }

		[Required]
        public virtual OfficeType OfficeType { get; set; }
		public int OfficeTypeId { get; set; }

		[Required]
		public string OfficeLocation { get; set; }

		[Required]
		public int OfficeArea { get; set; }
        
    }
}
