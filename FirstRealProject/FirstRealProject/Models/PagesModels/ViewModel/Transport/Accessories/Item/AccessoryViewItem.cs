using FirstRealProject.Models.Transports.AccessoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.Transport.Accessories.Item
{
    public class AccessoryViewItem : k.ViewItem
    {
        public AccessoryViewItem()
        {
            Photos = new HashSet<AccessoryPhoto>();
        }

        public AccessoryType AccessoryType { get; set; }
        public bool Condition { get; set; }

        public ICollection<AccessoryPhoto> Photos { get; set; }

    }
}
