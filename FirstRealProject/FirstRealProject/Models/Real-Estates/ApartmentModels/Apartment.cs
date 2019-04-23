using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Real_Estates.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.ApartmentModels
{
	[Table("Apartments", Schema = "real_estate")]
	public class Apartment:Announce
	{
        public Apartment()
        {
            ApartmentPhotos = new HashSet<ApartmentPhoto>();
        }

        public Apartment(int roomCount, string location, decimal area)
        {
            this.AnnounceName = roomCount + "-otaqlı, " + location + ", " + area;
            this.RoomCount = (byte)roomCount;
            this.ApartamentLocation = location;
            this.Area = area;
            ApartmentPhotos = new HashSet<ApartmentPhoto>();
        }

        public virtual ICollection<ApartmentPhoto> ApartmentPhotos { get; set; }

        [Required]
        public virtual RSAnnounceType RSAnnounceType { get; set; }
		public int RSAnnounceTypeId { get; set; }

		[Required]
        public virtual ApartmentType ApartmentType { get; set; }
		public int ApartmentTypeId { get; set; }

		[Required]
		[Column(TypeName = "decimal(15,2)")]
		public decimal Area { get; set; }

		[Required]
		public byte RoomCount { get; set; }

		[Required]
		public string ApartamentLocation { get; set; }
    }
}
