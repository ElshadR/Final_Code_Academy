using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.LandModels
{
	[Table("Lands", Schema = "real_estate")]
	public class Land: Announce
	{
        public Land()
        {
        }
        public Land(decimal area,string location)
        {
            this.AnnounceName = area + "sot torpaq sahəsi, " + location;
            this.Area = area;
            this.LandLocation = location;
            LandPhotos = new HashSet<LandPhoto>();
        }
        public virtual ICollection<LandPhoto> LandPhotos { get; set; }

        [Required]
		[Column(TypeName = "decimal(15,2)")]
		public decimal Area { get; set; }

		[Required]
		public string LandLocation { get; set; }
        
    }
}
