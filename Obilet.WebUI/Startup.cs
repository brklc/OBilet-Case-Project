using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Obilet.Business.Abstract;
using Obilet.Business.Conctrete;
using Obilet.Business.Models.General;
using System;

namespace Obilet.WebUI
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
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddRazorPages();
            services.AddHttpContextAccessor();

            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IJourneyService, JourneyService>();
            services.AddScoped<IRestRequestService, RestRequestService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<BaseUrl>(Configuration.GetSection("BaseUrl"));
            services.AddSingleton<BaseUrl>(bu =>
               bu.GetRequiredService<IOptions<BaseUrl>>().Value);
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Journey}/{action=Index}/{id?}");
            });
        }
    }
}
