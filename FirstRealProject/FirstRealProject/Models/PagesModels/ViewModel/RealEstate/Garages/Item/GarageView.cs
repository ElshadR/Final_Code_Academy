using FirstRealProject.Models.Real_Estates.GarageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Garages.Item
{
    public class GarageView : k.ViewItem
    {
        public GarageView()
        {
            Photos = new HashSet<GaragePhoto>();
        }
        public decimal Area { get; set; }
        public string Location { get; set; }
        public ICollection<GaragePhoto> Photos { get; set; }
    }
}
