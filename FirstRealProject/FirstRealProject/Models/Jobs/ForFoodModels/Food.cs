using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Jobs.ForFoodModels
{
	[Table("Foods", Schema ="jobs")]
	public class Food: Announce
	{
        public Food()
        {
            FoodPhotos = new HashSet<FoodPhoto>();
        }

        public virtual ICollection<FoodPhoto> FoodPhotos { get; set; }

    }
}
