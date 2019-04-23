using FirstRealProject.Models.PagesModels.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.User.Models.ViewModels
{
    public class UserViewModel
    {
        private string phoneNumber;

        public UserViewModel(string id, string userName, string email, string phoneNumber)
        {
            UserName = userName;
            Email = email;
            this.phoneNumber = phoneNumber;
            this.Id = id;


            PublishedAnnounces = new HashSet<ViewAnnounce>();
            NonPublishedAnnounces = new HashSet<ViewAnnounce>();
            CheckInAnnounces = new HashSet<ViewAnnounce>();
            EndedAnnounces = new HashSet<ViewAnnounce>();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int CommonAnnounceCount { get; set; }

        public ICollection<ViewAnnounce> NonPublishedAnnounces { get; set; }

        public ICollection<ViewAnnounce> PublishedAnnounces { get; set; }

        public ICollection<ViewAnnounce> CheckInAnnounces { get; set; }

        public ICollection<ViewAnnounce> EndedAnnounces { get; set; }

    }
}
