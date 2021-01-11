using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLuna.Back.Middlewares;
using DataLuna.Back.Infrastructure;
using DataLuna.Back.Infrastructure.DemoParse;
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
using AspNetCore.Yandex.ObjectStorage;

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
            bool injectLocalContext = bool.Parse(Configuration["UseLocalDb"]);
            if (injectLocalContext)
            {
                services.AddDbContext<DataLunaDbContext>(options => 
                    options.UseNpgsql(Configuration.GetConnectionString("DataLunaDatabase")));
            }
            else
            {
                services.AddDbContext<DataLunaDbContext>(options => 
                    options.UseNpgsql(Configuration.GetConnectionString("DataLunaDatabaseRemote")));
            }

            services.AddLogging();
            
            //Admin services
            services.AddScoped<IAdminTeamsService, AdminTeamsService>();
            services.AddScoped<IAdminPlayerService, AdminPlayerService>();
            services.AddScoped<IAdminEventService, AdminEventService>();
            
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

            //Infrastructure
            services.AddScoped<IDemoParseProvider, DemoParseProvider>();
            services.AddScoped<IYandexStorage, YandexStorage>();
            services.AddYandexObjectStorage(o => 
            {
                o.BucketName = "datalunaimagebucket";
                o.AccessKey = "6yyHcnpFGKUjFe1YZ9R3";
                o.SecretKey = "m35StLq68Hwmn7QsNWbe5GeSamwfxbfhelqzpx0f";
            });
            
            services.AddCors();
            services.AddControllers();
            
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
            
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            bool swaggerEnable = bool.Parse(Configuration["SwaggerEnable"]);
            if (swaggerEnable)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataLuna API");
                });
            }
        }
    }
}
