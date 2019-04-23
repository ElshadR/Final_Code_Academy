using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Accounts
{
	public class AppRole:IdentityRole
	{
		public AppRole()
		{

		}
		public AppRole(string roleName):base(roleName)
		{

		}
	}
}
