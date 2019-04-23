using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Models.Accounts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FirstRealProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
            IWebHost webHost = CreateWebHostBuilder(args).Build();


            using (IServiceScope serviceScope = webHost.Services.CreateScope())
            {
                using(FirstRealProjectDbContext dbContext= serviceScope.ServiceProvider.GetRequiredService<FirstRealProjectDbContext>())
                {
                    using (UserManager<AppUser> userManager=serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>())
                    {
                        using (RoleManager<AppRole> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>())
                        {
                            DefaultDbData.Seed(dbContext,userManager, roleManager);
                        }
                    }
                }
            }
			webHost.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
