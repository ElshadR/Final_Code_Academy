using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce
{
    public class MotocycleAnnounceModel:NewAnnounceCreateModel
    {
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 1, ErrorMessage = "1 hərifdən çox olmalıdı")]
        public string MotocycleModel { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleMakeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleBodyTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleMotor { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleYear { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int MotocycleKilometer { get; set; }
        
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "minimum 1 şəkil.")]
        public int PhotoLength { get; set; }

        public bool MotocycleCondition { get; set; }
    }
}
