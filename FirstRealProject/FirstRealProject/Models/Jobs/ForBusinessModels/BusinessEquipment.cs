using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Jobs.ForBusinessModels
{
	[Table("BusinessEquipments", Schema ="jobs")]
	public class BusinessEquipment: Announce
	{
        public BusinessEquipment()
        {
            BusinessEPhotos = new HashSet<BusinessEPhoto>();
        }

        public virtual ICollection<BusinessEPhoto> BusinessEPhotos { get; set; }
        [Required]
        public virtual BusinessType  BusinessType { get; set; }
		public int  BusinessTypeId { get; set; }
    }
}
