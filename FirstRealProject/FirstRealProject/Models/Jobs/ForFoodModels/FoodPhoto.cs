using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Jobs.ForFoodModels
{
	[Table("FoodPhotos", Schema ="jobs")]
    public class FoodPhoto:Photo
    {
        [Required]
        public virtual Food Food { get; set; }
        public int FoodId { get; set; }
    }
}
