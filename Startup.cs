using System;
using FrontToBack.Models;
using FrontToBack.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FrontToBack
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddIdentity<AppUser, IdentityRole>(opt =>
             {
                 opt.Password.RequireLowercase = true;
                 opt.Password.RequiredLength = 8;
                 opt.Password.RequireNonAlphanumeric = true;

                 opt.User.RequireUniqueEmail = true;

                 opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                 opt.Lockout.MaxFailedAccessAttempts = 3;
                 //opt.Lockout.AllowedForNewUsers = true;

             }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            
            services.AddControllersWithViews();
            services.AddDbContext<Context>(opt =>
            {
                opt.UseSqlServer(_config.GetConnectionString("Default"));
            });

            services.AddSession(opt => {

                opt.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "areas",
                    "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
              
                endpoints.MapControllerRoute("default",
                    "{controller=home}/{action=Index}/{id?}");
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });

        }
    }
}
