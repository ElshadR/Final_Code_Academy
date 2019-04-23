using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce
{
    public class ApartmentAnnounceModel:NewAnnounceCreateModel
    {
        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue,ErrorMessage = "Boş ola bilməz.")]
        public int ApartmentTypeId { get; set; }
        
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "minimum 1 şəkil.")]
        public int PhotoLength { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int RSAnnounceTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Column(TypeName = "decimal(15,2)")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public decimal ApartmentArea { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public byte ApartmentRoomCount { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərifdən çox olmalıdı")]
        public string ApartamentLocation { get; set; }
    }
}
