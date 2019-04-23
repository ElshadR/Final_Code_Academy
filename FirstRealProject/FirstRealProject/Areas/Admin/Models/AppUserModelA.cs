using FirstRealProject.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models
{
    public class AppUserModelA
    {
        public AppUserModelA()
        {
            AppUsers = new List<AppUser>();
        }
        public string HeaderName { get; set; }

        public IEnumerable<AppUser> AppUsers { get; set; }
        public string RoleName { get; set; }
    }
}
