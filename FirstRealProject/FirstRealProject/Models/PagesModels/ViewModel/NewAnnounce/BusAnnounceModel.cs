using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce
{
    public class BusAnnounceModel:NewAnnounceCreateModel
    {
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusMakeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusBodyTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusYear { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int BusKilometer { get; set; }
        
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "minimum 1 şəkil.")]
        public int PhotoLength { get; set; }


        public bool BusCondition { get; set; }
    }
}
