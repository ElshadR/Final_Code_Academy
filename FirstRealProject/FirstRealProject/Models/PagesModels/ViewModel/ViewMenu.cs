using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel
{
    public class ViewMenu
    {
        public ViewMenu()
        {
            ViewCategories = new HashSet<ViewCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public ICollection<ViewCategory> ViewCategories { get; set; }
    }
}
