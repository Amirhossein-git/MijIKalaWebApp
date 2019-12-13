using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MijiKalaWebApp;
using MijiKalaWebApp.Areas.Admin.Repository;
using MijiKalaWebApp.Areas.API.Repository;
using MijiKalaWebApp.Classes;
using MijiKalaWebApp.Contexts;
using MijiKalaWebApp.Extensions;
using MijiKalaWebApp.Repository;
using MijiKalaWebApp.TripleA.Context;

namespace WebApplication1
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            var appSetting = configuration.GetSection("Settings").Get<Settings>();
            services.AddSingleton(appSetting);

            services.AddDbContext<ProductsContext>(options =>
            {
                options.UseSqlServer(appSetting.SqlServerConnectionString);
            });
            
            services.AddDbContext<PersonsContext>(options =>
            {
                options.UseSqlServer(appSetting.SqlServerConnectionString);
            });

            services.AddDbContext<AuthContext>(options =>
            {
                options.UseSqlServer(appSetting.SqlServerConnectionString);
            });

            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AuthContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(option =>
            {
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Registery/SignIn";
                options.LogoutPath = "/Registery/Logout";
                options.AccessDeniedPath = "/Registery/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.ReturnUrlParameter = "ReturnUrl";
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,option=>
            {
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "http://localhost",
                    ValidAudience = "http://localhost",
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RoleClaimType="Roles",
                    NameClaimType="Username",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes("M I J I -app   PA3c3wOrDd..")),
                };
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Registery/SignIn";
                options.LogoutPath = "/Registery/Logout";
                options.AccessDeniedPath = "/Registery/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = new TimeSpan(0, 30, 0);
                options.ReturnUrlParameter = "ReturnUrl";
            });

            services.AddAuthorization();

            services.AddControllersWithViews();

            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IAPIRepository, APIRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.MigrateDatabase<ProductsContext>();
            app.MigrateDatabase<AuthContext>();
            DataSeeder.SeedAuthData(app);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=Home}/{action=Home}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Home}");
                
            });
        }
    }
}
