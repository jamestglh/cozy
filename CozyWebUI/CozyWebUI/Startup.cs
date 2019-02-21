﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Data.Context;
using Cozy.Data.Implementation.EFCore;
using Cozy.Data.Implementation.Mock;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CozyWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //GetDependancyResolvedForMockRepositoryLayer(services);
            GetDependancyResolvedForEFCoreRepositoryLayer(services);

            GetDependancyResolvedForServiceLayer(services);

            services.AddDbContext<CozyDbContext>();
            services.AddDefaultIdentity<AppUser>()
                .AddEntityFrameworkStores<CozyDbContext>();



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            
            app.UseStaticFiles(); // so it knows where to find your stuff
            app.UseAuthentication(); //makes use of identity

            app.UseMvcWithDefaultRoute();
            // controller/view/?id
            //home controller is default
            //index is default view


        }

        private void GetDependancyResolvedForMockRepositoryLayer(IServiceCollection services)
        {
            //repository layer  injection
            services.AddScoped<IHomeRepository, MockHomeRepository>();
            services.AddScoped<ILandlordRepository, MockLandlordRepository>();
            services.AddScoped<ILeaseRepository, MockLeaseRepository>();
            services.AddScoped<IMaintenanceRepository, MockMaintenanceRepository>();
            services.AddScoped<IMaintenanceStatusRepository, MockMaintenanceStatusRepository>();
            services.AddScoped<IPaymentRepository, MockPaymentRepository>();
            services.AddScoped<ITenantRepository, MockTenantRepository>();

        }

        private void GetDependancyResolvedForEFCoreRepositoryLayer(IServiceCollection services)
        {
            //repository layer  injection
            services.AddScoped<IHomeRepository, EFCoreHomeRepository>();
            //services.AddScoped<ILandlordRepository, EFCoreLandlordRepository>();
            services.AddScoped<ILeaseRepository, EFCoreLeaseRepository>();
            services.AddScoped<IMaintenanceRepository, EFCoreMaintenanceRepository>();
            services.AddScoped<IMaintenanceStatusRepository, EFCoreMaintenanceStatusRepository>();
            services.AddScoped<IPaymentRepository, EFCorePaymentRepository>();
            //services.AddScoped<ITenantRepository, EFCoreTenantRepository>();
        }

        private void GetDependancyResolvedForServiceLayer(IServiceCollection services)
        {
            //services layer injection
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ILandlordService, LandlordService>();
            services.AddScoped<ILeaseService, LeaseService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IMaintenanceStatusService, MaintenanceStatusService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITenantService, TenantService>();
        }
    }
}
