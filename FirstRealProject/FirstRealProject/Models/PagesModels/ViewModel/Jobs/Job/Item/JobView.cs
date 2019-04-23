using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Jobs.ForJob;
using FirstRealProject.Models.Jobs.ForJobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.Jobs.Job.Item
{
    public class JobView : k.ViewItem
    {
        public JobView()
        {
            Photos = new HashSet<JobPhoto>();
        }
        public ActivityArea ActivityArea { get; set; }
        public JobType JobType { get; set; }
        public ICollection<JobPhoto> Photos { get; set; }
    }
}
