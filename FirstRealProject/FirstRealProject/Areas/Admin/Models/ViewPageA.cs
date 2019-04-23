using FirstRealProject.Models.PagesModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models
{
    public class ViewPageA
    {
        public ViewPageA()
        {
            ViewAnnounceAs = new List<ViewAnnounceA>();
        }
        public PaginationA Pagination { get; set; }

        public IEnumerable<ViewAnnounceA> ViewAnnounceAs { get; set; }
    }
}
