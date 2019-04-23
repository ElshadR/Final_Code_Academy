using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForFoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.Jobs.Foods.Item
{
    public class FoodView : k.ViewItem
    {
        public FoodView()
        {
            Photos = new HashSet<FoodPhoto>();
        }
        public ICollection<FoodPhoto> Photos { get; set; }
    }
}
