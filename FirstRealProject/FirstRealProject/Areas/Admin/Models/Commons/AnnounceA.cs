using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.PagesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.Commons
{
    public class AnnounceA
    {
        public AnnounceA()
        {
            PhotoPaths = new HashSet<string>();
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        public string AnnounceName { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

        public int PersonTypeId { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(225, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(225, MinimumLength = 3)]
        public string PhoneNumber { get; set; }


        public DateTime? AnnounceEndedDate { get; set; }


        public int AnnounceViewCount { get; set; }

        public int? AnnounceTypeId { get; set; }

        public int? PaymentTypeId { get; set; }

        public bool AnnouncePublished { get; set; }

        public bool AnnounceCheckIn { get; set; }

        public bool AnnounceEnded { get; set; }

        public virtual AppUser AppUser { get; set; }
        public string AppUserId { get; set; }


        public ICollection<string> PhotoPaths { get; set; }
        public  ICollection<City> Cities { get; set; }
        public FindTable FindTable { get; set; }
    }
}
