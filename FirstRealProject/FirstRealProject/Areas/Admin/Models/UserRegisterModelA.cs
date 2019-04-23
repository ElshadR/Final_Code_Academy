using FirstRealProject.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models
{
    public class UserRegisterModelA
    {
        public UserRegisterModelA()
        {
            UserRoles = new List<string>();
            Roles = new List<AppRole>();
        }

        [Required]
        [Display(Name = "Adınızı daxil edin")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Şifrə")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Şifrəni təsdiq et")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<string> UserRoles { get; set; }
        public IEnumerable<AppRole> Roles { get; set; }
        public string RoleName { get; set; }
        public string HeaderName { get; set; }
    }
}
