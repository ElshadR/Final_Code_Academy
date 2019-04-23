using FirstRealProject.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models
{
    public class UserChangeModelA
    {

        public UserChangeModelA()
        {
            UserRoles = new List<string>();
            AllRoles = new List<AppRole>();
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public object Year { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public string HeaderName { get; set; }

        public IEnumerable<string> UserRoles { get; set; }
        public IEnumerable<AppRole>AllRoles { get; set; }

    }
}
