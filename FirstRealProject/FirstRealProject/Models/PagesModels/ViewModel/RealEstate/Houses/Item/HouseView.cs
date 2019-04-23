using FirstRealProject.Models.Real_Estates.Commons;
using FirstRealProject.Models.Real_Estates.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Houses.Item
{
    public class HouseView : k.ViewItem
    {
        public HouseView()
        {
            Photos = new HashSet<HousePhoto>();
        }
        public RSAnnounceType RSAnnounceType { get; set; }
		public HouseType HouseType { get; set; }
        public decimal Area { get; set; }
        public string Location { get; set; }
        public ICollection<HousePhoto> Photos { get; set; }
    }
}
