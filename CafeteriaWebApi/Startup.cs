using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CafeteriaWebApi.DataEntities;
using Microsoft.EntityFrameworkCore;
using CafeteriaWebApi.Repositories;
using CafeteriaWebApi.Services;
using CafeteriaWebApi.Models;
using CafeteriaWebApi.Mappers;

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CafeteriaWebApi
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
            services.AddDbContext<CafeteriaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           // services.TryAddSingleton<IBookingRepository, BookingRepository>();
            services.AddSingleton(typeof(IBookingServices), typeof(BookingService));
            services.AddScoped<IBookingServices, BookingService>();
            services.AddSingleton(typeof(IBookingRepository), typeof(BookingRepository));
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.TryAddSingleton<IBookingMappingServices, BookingMappingService>();
            services.AddScoped<IBookingMappingServices, BookingMappingService>();
            // Mappers
            services.TryAddSingleton<IMapper<BookingModel, Booking>, BookingModelToEntities>();
            services.AddScoped<IMapper<BookingModel, Booking>, BookingModelToEntities>();
            services.TryAddSingleton<IMapper<Booking, BookingModel>, BookingEntityToModel>();
            services.AddScoped<IMapper<Booking, BookingModel>, BookingEntityToModel>();
            services.TryAddSingleton<IMapper<IEnumerable<Booking>, IEnumerable<BookingModel>>, EnumerableMapper<Booking, BookingModel>>();
            services.AddScoped<IMapper<IEnumerable<Booking>, IEnumerable<BookingModel>>, EnumerableMapper<Booking, BookingModel>>();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ApplicationServices.GetService<IDisposable>();
            app.UseMvc();
        }
    }
}
