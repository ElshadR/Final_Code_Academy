using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForBusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.Jobs.Businesses.Item
{
    public class BusinessView : k.ViewItem
    {
        public BusinessView()
        {
            Photos = new HashSet<BusinessEPhoto>();
        }
        public BusinessType BusinessType { get; set; }
        public ICollection<BusinessEPhoto> Photos { get; set; }
    }
}
