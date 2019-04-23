using FirstRealProject.Models.Transports.BusModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.Transport.Buses.Item
{
    public class BusViewItem : k.ViewItem
    {
        public BusViewItem()
        {
            Photos = new HashSet<BusPhoto>();
        }

        public ICollection<BusPhoto> Photos { get; set; }


        public BusMake Make { get; set; }
        public BusBodyType BodyType { get; set; }
        public int Year { get; set; }
        public int BusKilometer { get; set; }
        public bool Condition { get; set; }
        public bool ConditionCredit { get; set; }
        public bool ConditionBarter { get; set; }
    }
}
