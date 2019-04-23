using FirstRealProject.Models.Commons;
using FirstRealProject.Models.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item
{
    public class ViewItem
    {
        public int Id { get; set; }
        public FindTable FindTable { get; set; }
        public string AnounceName { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public decimal Price { get; set; }
        public PersonType PersonType { get; set; }
        public int PersonTypeId { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AnnounceAddedDate { get; set; }
        public DateTime? AnnounceEndedDate { get; set; }
        public DateTime? AnnouncePublishDate { get; set; }
        public int AnnounceViewCount { get; set; }
        public string AnnouncePinCode { get; set; }
        public string AnnounceUniqueCode { get; set; }
        public AnnounceType AnnounceType { get; set; }
        public int? AnnounceTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public int? PaymentTypeId { get; set; }
        public bool AnnouncePublished { get; set; }
        public bool AnnounceCheckIn { get; set; }
        public bool AnnounceEnded { get; set; }
    }
}
