using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Implementations;
using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Infrastructure.Validations;
using FirstRealProject.Models.Accounts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstRealProject
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentity<AppUser, AppRole>(options => {
				//Changing the User Account Validation Settings
				options.User.RequireUniqueEmail = true;
				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
				
                //Configuring Password Validation
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireDigit = false;
				//End Configuring Password Validation

			}).AddEntityFrameworkStores<FirstRealProjectDbContext>()
					.AddDefaultTokenProviders();


            services.AddScoped<IAnnounceToAdd, AnnounceToAdd>();
            services.AddScoped<IFindAnnounce, FindAnnounce>();
            services.AddScoped<IUpdateAnnounce, UpdateAnnounce>();

            //Registering a Custom Password Validator
            services.AddTransient<IPasswordValidator<AppUser>,CustomPasswordValidator>();
            //END Registering a Custom Password Validator

            //Announce setting start
            services.AddTransient<ISettingAnnounce, SettingAnnounce>();
            //Announce setting end

            services.AddTransient<IUserValidator<AppUser>,CustomUserValidator>();


			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.ConfigureApplicationCookie(options => 
			{
				options.LoginPath = new PathString("/user/account/Login");
				options.AccessDeniedPath = new PathString("/user/account/AccessDenied");
                options.Cookie.Expiration = TimeSpan.FromDays(1);
                options.ExpireTimeSpan = new TimeSpan(2, 20, 10);
			});

			services.AddDbContext<FirstRealProjectDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:FirstRealProjectDb"]);
            });

			services.AddSession();

			services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStatusCodePages();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{

				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); // 
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
			{
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}"
                    );
				routes.MapRoute(
					name: "allRoute",
					template: "all/{controller}/{action}"
                    );
				routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id:int?}"
                  );
            });
		}
	}
}
