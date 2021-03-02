using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Services.Emp;
using Assignment1.Services.Interface;
using Assignment1.Services.Observer;
using Assignment1.CommonUtility;
using Assignment1.CommonUtility.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;

namespace Assignment1.Web
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
            string Conn = Configuration.GetConnectionString("DB");
            services.AddControllersWithViews();

            services.AddTransient<IDbConnection>((connection) =>
                   new SqlConnection(Conn)
               );
            services.AddScoped<IEmployeeService, ContractEmployee>();
            services.AddScoped<IEmployeeProject, FulltimeEmployee>();
            services.AddScoped<IMessenger, Email>();
            services.AddScoped<IMessenger, SlackClient>();
        }



        //public static IServiceCollection Resolve(this IServiceCollection services, IConfiguration configuration)
        //{
        //    string Conn = configuration.GetConnectionString("DB");
        //    services.AddTransient<IDbConnection>((connection) =>
        //        new SqlConnection(Conn)
        //    );

        //    services.AddControllersWithViews();
        //    services.AddScoped<IEmployeeService, ContractEmployee>();
        //    services.AddScoped<IEmployeeProject, FulltimeEmployee>();
        //    services.AddScoped<IMessenger, Email>();
        //    services.AddScoped<IMessenger, SlackClient>();

        //    return services;
        //}

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
