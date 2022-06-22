using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using netchill.Model;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;

namespace netchill
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
            services.AddControllersWithViews();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddDbContext<DonationDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DonationDBContext>();
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Login/Index";
            });

            services.AddSpaStaticFiles(configuration =>
               {
                   configuration.RootPath = "ClientApp/build";
               });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseSpa(spa =>
            {
                app.UseEndpoints(endpoints =>
                {
                  

                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                    endpoints.MapControllerRoute("Ui",
                      "/Ui",
                      new { controller = "Home", action = "Index" });


                    endpoints.MapControllerRoute("featured",
                      "/Home/Ui/featured",
                      new { controller = "Home", action = "Index" });


                     endpoints.MapControllerRoute("newrelease",
                      "/Home/Ui/newrelease",
                      new { controller = "Home", action = "Index" });


                    endpoints.MapControllerRoute("upcoming",
                    "Home/Ui/upcoming",
                    new { controller = "Home", action = "Index" });



                    endpoints.MapControllerRoute("mylist",
                    "Home/Ui/mylist",
                    new { controller = "Home", action = "Index" });
                });




                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }



        
    }
}