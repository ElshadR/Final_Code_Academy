using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce
{
    public class AccessoryAnnounceModel:NewAnnounceCreateModel
    {
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int AccessoryTypeId { get; set; }

        public bool AccessoryCondition { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərifdən çox olmalıdı")]
        public string AccessoryName { get; set; }
        
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "minimum 1 şəkil.")]
        public int PhotoLength { get; set; }

    }
}
