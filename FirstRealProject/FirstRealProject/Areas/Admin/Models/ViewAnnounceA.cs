using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models
{
    public class ViewAnnounceA
    {
            public ViewAnnounceA(FindTable find,string category,string subCategory)
        {
            Photos = new List<ViewPhoto>();
            FindTable = find;
            Category = category;
            SubCategory = subCategory;
        }

        public int Id { get; set; }
        public FindTable FindTable { get; set; }

        public DateTime AddedDate { get; set; }
        public string City { get; set; }
        public string AnnouncePinCode{ get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Name { get; set; }
        public AnnounceType AnnounceType { get; set; }
        public AnnounceTypeFind AnnounceTypeFind { get; set; }
        public string Status { get; set; }
        public FindStatus FindStatus { get; set; }
        public IEnumerable<ViewPhoto> Photos { get; set; }
        public Pagination Pagination { get; set; }
        public string EditAction { get; internal set; }
        public string Controller { get; internal set; }
        public string ReadAction { get; internal set; }
        public string ReadController { get; internal set; }
    }
}
