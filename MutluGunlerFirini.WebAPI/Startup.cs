using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MutluGunlerFirini.Core.DependecyResolvers;
using MutluGunlerFirini.Core.Extensions;
using MutluGunlerFirini.Core.Utilities.IoC;
using MutluGunlerFirini.WebAPI.Helpers;

namespace MutluGunlerFirini.WebAPI
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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4201", "http://localhost:4200", "www.mutlugunlerfirini.com.tr", "https://qrmenu.mutlugunlerfirini.com.tr/", "https://qrmenu.mutlugunlerfirini.com.tr", "https://www.qrmenu.mutlugunlerfirini.com.tr/", "https://www.qrmenu.mutlugunlerfirini.com.tr", "www.qrmenu.mutlugunlerfirini.com.tr", "https://www.mutlugunlerfirini.com.tr/", "http://www.mutlugunlerfirini.com.tr/", "https://mutlugunlerfirini.com.tr", "https://admin.mutlugunlerfirini.com.tr", "https://mutlugunlerfirini.com.tr/urunlerimiz", "https://mutlugunlerfirini.com.tr/product/", "https://mutlugunlerfirini.com.tr/mutlutv", "https://mutlugunlerfirini.com.tr/galeri").AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
