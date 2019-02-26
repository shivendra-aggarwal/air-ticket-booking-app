using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Business.AirVendors;
using ATS.Business.AirVendors.GoAir;
using ATS.Business.AirVendors.JetAir;
using ATS.Business.Booking;
using ATS.Business.Interfaces;
using ATS.DataAccess.Context;
using ATS.DataAccess.Data;
using ATS.DataAccess.Repositories;
using ATS.DataAccess.Repositories.Interfaces;
using ATS.Models;
using ATS.UI.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ATS.UI
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
            // Below code will help to protect all incoming request to server by having check on Anti forgery token
            services.AddMvc(options =>
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()))
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver =
                            new CamelCasePropertyNamesContractResolver();
                        options.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });

            services.AddDataProtection();

            services.AddDbContext<ATSDbContext>(options =>
                options.UseSqlite("Data Source=ATSTest.db"));

            #region Respositories Registration
            services.AddScoped<IAirVendorRepository, AirVendorRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            #endregion

            #region Business Services registration
            services.AddScoped<IAirVendorManager, AirVendorManager>();
            services.AddScoped<IAirVendorObjectManager, AirVendorObjectManager>();
            services.AddScoped<IAirVendorFactory, AirVendorFactory>();
            services.AddScoped<IBookingManager, BookingManager>();
            services.AddScoped<GoAirAirlines, GoAirAirlines>();
            services.AddScoped<JetAirAirlines, JetAirAirlines>();
            services.AddScoped<HandleExceptionAttribute>();
            #endregion

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ATSDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            InitializeDb.LoadAirVendors(context);
        }
    }
}
