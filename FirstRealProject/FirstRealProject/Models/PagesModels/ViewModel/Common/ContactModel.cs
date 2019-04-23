using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.Common
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? CheckInDate { get; set; }
        public bool CheckIn { get; set; }
    }
}
