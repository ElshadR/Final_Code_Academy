using FirstRealProject.Models.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.Common
{
    public class DeleteModalModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public FindTable FindTable { get; set; }

        [Required]
        public string AnnouncePinCode { get; set; }
    }
}
