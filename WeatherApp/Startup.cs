using dotenv.net;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace WeatherApp
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

            //Fluent Validation
            services.AddMvc()
             .AddFluentValidation(fvc =>
                 fvc.RegisterValidatorsFromAssemblyContaining<Startup>());



            //MySql
            services.AddScoped<IDbConnection>((s) =>
            {
                var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
                var envConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

                var connectionString = environment == "dev"
                    ? Configuration.GetConnectionString("weatherapp")
                    : envConnectionString;

                IDbConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                return conn;
            });


           


            //Login session
            services.AddSession();


            
            services.AddTransient<IContactUsRepository, ContactUsRepository>();
            services.AddTransient<IRegisterRepository, RegisterRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();

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

                //var envVars = Environment.GetEnvironmentVariable("APIKEY");
                //var _key = envVars;
            }
            app.UseSession();

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
