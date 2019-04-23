using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Users.Models
{
    public class UserRegisterModel
    {
        [Required]
		[Display(Name="Adınızı daxil edin")]
        public string Name { get; set; }
		[Required]
        public string Email { get; set; }
        [Required]
		[Display(Name = "Şifrə")]
		public string Password { get; set; }
		[Required]
		[Compare("Password")]
		[Display(Name="Şifrəni təsdiq et")]
		public string ConfirmPassword { get; set; }


	}
}
