using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Jobs.ForBusinessModels
{
	[Table("BusinessEPhotos", Schema ="jobs")]
    public class BusinessEPhoto:Photo
    {
        [Required]
        public virtual BusinessEquipment BusinessEquipment { get; set; }
        public int BusinessEquipmentId { get; set; }
    }
}
