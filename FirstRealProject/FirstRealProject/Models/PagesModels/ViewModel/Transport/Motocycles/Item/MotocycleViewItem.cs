using FirstRealProject.Models.Transports.MotocycleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.Transport.Motocycles.Item
{
    public class MotocycleViewItem : k.ViewItem
    {
        public MotocycleViewItem()
        {
            Photos = new HashSet<MotocyclePhoto>();
        }

        public string MotocycleModel { get; set; }
        public MotocycleBodyType MotocycleBodyType { get; set; }
        public int MotocycleMotor { get; set; }
        public int MotocycleYear { get; set; }
        public int MotocycleKilometer { get; set; }
        public bool Condition { get; set; }
        public bool ConditionCredit { get; set; }
        public bool ConditionBarter { get; set; }

        public ICollection<MotocyclePhoto> Photos { get; set; }


    }
}
