using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.PagesModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Commons
{
    public class Announce
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225,MinimumLength =3)]
        public string AnnounceName { get; set; }

        [Required]
        public virtual City City { get; set; }
        public int CityId { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

        public virtual PersonType PersonType { get; set; }
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

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AnnounceAddedDate { get; set; }

        public DateTime? AnnounceEndedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AnnouncePublishDate { get; set; }

        public int AnnounceViewCount { get; set; }

        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string AnnouncePinCode { get; set; }

        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string AnnounceUniqueCode { get; set; }

        public virtual AnnounceType AnnounceType { get; set; }
        public int? AnnounceTypeId { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public int? PaymentTypeId { get; set; }

        public bool AnnouncePublished { get; set; }

        public bool AnnounceCheckIn { get; set; }

        public bool AnnounceEnded { get; set; }

        public bool AppendedPinCode { get; set; }

        public virtual AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
