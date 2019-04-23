using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Transports.CarModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce
{
    public class NewAnnounceCreateModel
    {
        public NewAnnounceCreateModel()
        {
            Paths = new List<string>();
        }
        public List<string> Paths { get; set; }
        public int AnnounceTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Column(TypeName = "decimal(15,2)")]
        [Range(minimum:1,maximum:int.MaxValue,ErrorMessage = "Boş ola bilməz.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Boş ola bilməz.")]
        public int PersonTypeId { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 2, ErrorMessage = "2 hərifdən çox olmalıdı")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "3 hərifdən çox olmalıdı")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərifdən çox olmalıdı")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz.")]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "3 hərifdən çox olmalıdı")]
        public string PhoneNumber { get; set; }
    }
}
