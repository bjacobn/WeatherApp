using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Data;


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

            //MySQL
            services.AddScoped<IDbConnection>((s) =>
            {   
                var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
                var herokuConnectionString = Environment.GetEnvironmentVariable("REMOTEDB");
                var connectionString = environment == "development"
                          ? Configuration.GetConnectionString("LOCALDB")
                          : herokuConnectionString;


                IDbConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                return conn;
            });
            
            services.AddSession();

            //Repos
            services.AddTransient<IContactUsRepository, ContactUsRepository>();
            services.AddTransient<IRegisterRepository, RegisterRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
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
