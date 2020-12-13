using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLuna.Back.Middlewares;
using DataLuna.Back.Persistence;
using DataLuna.Back.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace DataLuna.Back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataLunaDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DataLunaDatabase")));

            services.AddLogging();
            
            //Admin services
            services.AddScoped<IAdminTeamsService, AdminTeamsService>();
            services.AddScoped<IAdminPlayerService, AdminPlayerService>();
            
            //User services

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.LogoutPath = "/signout";
                })
                .AddSteam();
            
            services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.IgnoreNullValues = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DataLuna API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataLuna API");
            });
        }
    }
}
