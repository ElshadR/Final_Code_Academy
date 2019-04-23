using FirstRealProject.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.TagHelpers
{
	[HtmlTargetElement("td", Attributes = "identity-role")]
	public class RoleUsersTagHelper : TagHelper
	{
		private UserManager<AppUser> userManager;
		private RoleManager<AppRole> roleManager;
		public RoleUsersTagHelper(UserManager<AppUser> usermgr,
		RoleManager<AppRole> rolemgr)
		{
			userManager = usermgr;
			roleManager = rolemgr;
		}
		[HtmlAttributeName("identity-role")]
		public string Role { get; set; }
		public override async Task ProcessAsync(TagHelperContext context,TagHelperOutput output)
		{
			List<string> names = new List<string>();
			AppRole role = await roleManager.FindByIdAsync(Role);
			if (role != null)
			{
				foreach (var user in userManager.Users)
				{
					if (user != null && await userManager.IsInRoleAsync(user, role.Name))
					{
						names.Add(user.UserName);
					}
				}
			}
			output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
		}
	}
   
}
