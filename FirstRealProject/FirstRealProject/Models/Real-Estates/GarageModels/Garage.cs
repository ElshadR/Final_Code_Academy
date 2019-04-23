using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Real_Estates.GarageModels
{
	[Table("Garages", Schema = "real_estate")]
	public class Garage: Announce
	{
        public Garage()
        {
            GaragePhotos = new HashSet<GaragePhoto>();
        }

        public virtual ICollection<GaragePhoto> GaragePhotos { get; set; }

        [Required]
		[Column(TypeName = "decimal(15,2)")]
		public decimal Area { get; set; }

		[Required]
		public string GarageLocation { get; set; }
    }
}
