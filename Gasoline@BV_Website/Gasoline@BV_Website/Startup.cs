using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gasoline_BV_Website
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

            services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCookieAuth";
               options.LoginPath = "/Index";
                options.LoginPath = "/About";
                options.AccessDeniedPath = "/AccessDenied";
                // options.ExpireTimeSpan = TimeSpan.FromSeconds(30);
            });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin-Manager"));
                option.AddPolicy("CustomerOnly", policy => policy.RequireClaim("Consumer"));
                option.AddPolicy("RetailerOnly", policy => policy.RequireClaim("Retailer"));
                option.AddPolicy("WareHouserOnly", policy => policy.RequireClaim("WareHouse-Manager"));
                option.AddPolicy("SalesOnly", policy => policy.RequireClaim("Financial-Manager"));
                option.AddPolicy("productionOnly", policy => policy.RequireClaim("Production-Manager"));
                option.AddPolicy("SupplyOnly", policy => policy.RequireClaim("Supplier"));
                //option.AddPolicy("MustBelongToHRDepartment", policy => policy.RequireClaim("Department", "HR")
                // .RequireClaim("Department", "HR")
                // .RequireClaim("Manager"));

            });
            services.AddSession();
            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseSession();


            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
