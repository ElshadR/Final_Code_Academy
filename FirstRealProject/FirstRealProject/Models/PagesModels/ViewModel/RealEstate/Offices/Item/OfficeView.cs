using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Real_Estates.Commons;
using FirstRealProject.Models.Real_Estates.OfficeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Offices.Item
{
    public class OfficeView : k.ViewItem
    {
        public OfficeView()
        {
            Photos = new HashSet<OfficePhoto>();
        }
        public RSAnnounceType RSAnnounceType { get; set; }
		public OfficeType OfficeType { get; set; }
        public decimal Area { get; set; }
        public string Location { get; set; }
        public ICollection<OfficePhoto
            > Photos { get; set; }
    }
}
