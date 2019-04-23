using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.Transports.AccessoryModels;
using FirstRealProject.Models.Transports.BusModels;
using FirstRealProject.Models.Transports.CarModels;
using FirstRealProject.Models.Transports.MotocycleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.Home
{
    public class ViewAnnounce
    {
         public ViewAnnounce(FindTable findTable)
        {
            Photos = new List<ViewPhoto>();
            this.FindTable = findTable;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string AnnounceUnicode { get; set; }
        public string AnnouncePinCode { get; set; }
        public DateTime? AddedPublishDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public ViewPhoto ActivePhoto { get; set; }
        public bool SelectedAnnounce { get; set; }

        public IEnumerable<ViewPhoto> Photos { get; set; }

        public FindTable FindTable { get; set; }

    }
}
