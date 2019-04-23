using FirstRealProject.Models.Real_Estates.ApartmentModels;
using FirstRealProject.Models.Real_Estates.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Apartments.Item
{
    public class ApartmentView : k.ViewItem
    {
        public ApartmentView()
        {
            Photos = new HashSet<ApartmentPhoto>();
        }
        public RSAnnounceType RSAnnounceType { get; set; }
        public ApartmentType ApartmentType { get; set; }
        public decimal Area { get; set; }
        public byte RoomCount { get; set; }
        public string ApartamentLocation { get; set; }
        public ICollection<ApartmentPhoto> Photos { get; set; }
    }
}
