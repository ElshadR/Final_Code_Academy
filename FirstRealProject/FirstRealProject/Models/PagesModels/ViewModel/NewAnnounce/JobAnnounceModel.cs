using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce
{
    public class JobAnnounceModel:NewAnnounceCreateModel
    {
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 1, ErrorMessage = "1 hərifdən çox olmalıdı")]
        public string JobName { get; set; }
        
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "minimum 1 şəkil.")]
        public int PhotoLength { get; set; }

        [Required]
        public int JobActivityAreaId { get; set; }

        [Required]
        public int JobTypeId { get; set; }
    }
}
