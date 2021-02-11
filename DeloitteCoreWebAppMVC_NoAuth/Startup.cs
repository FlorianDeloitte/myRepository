using DeloitteCoreWebAppMVC_NoAuth.BL;
using DeloitteCoreWebAppMVC_NoAuth.CAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeoSmart.Caching.Sqlite;
using System;

namespace DeloitteCoreWebAppMVC_NoAuth
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
            services.AddSqliteCache(options => { options.CachePath = @"C:\cache.db"; });
            services.AddControllersWithViews().
             AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
             });

            services.AddDistributedMemoryCache();

            services.AddScoped<IHomeBusinessService, HomeBusinessService>();
            services.AddScoped<IHomeDataService, HomeDataService>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(200000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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
            app.UseSession();
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