using FirstRealProject.Models.Real_Estates.LandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Lands.Item
{
    public class LandView : k.ViewItem
    {
        public LandView()
        {
            Photos = new HashSet<LandPhoto>();
        }
        public decimal Area { get; set; }
        public string Location { get; set; }
        public ICollection<LandPhoto> Photos { get; set; }
    }
}
