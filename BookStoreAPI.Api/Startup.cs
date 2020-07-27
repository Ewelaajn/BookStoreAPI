using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Threading.Tasks;
using BookStoreAPI.Repositories.Db;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Repositories;
using BookStoreAPI.Repositories.Settings;
using BookStoreAPI.Services;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.Mappings;
using BookStoreAPI.Services.Mappings.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BookStoreAPI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // injection configuration = config.AddJsonFile()
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // configureServices is used to:
        // 1.Registering services using Depencency Injection
        // 2.Registering swagger
        // 3.Mapping sertings from .json to objects
        public void ConfigureServices(IServiceCollection services)
        {

            // Grabs "DbSettings" section of appSettings.json and maps it to DbSettings model
            // Matched by name
            services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));
            //Registering services using , connecting interfaces with implementation
            services.AddScoped<IDb, Db>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookMapper, BookMapper>();
            // Core api configuration
            // Registering cotrollers 
            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddApiExplorer().AddControllersAsServices();
            //Register swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Book Store API",
                    Version = "0.0.1",
                    Description = "Api for buying books"

                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Cofigure - not optional, main app configuration
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            
            app.UseRouting();
            // Map endpoints (https adresses) to controllers (objects)
            app.UseEndpoints(e =>
            {
                e.MapControllers();
            });
            // Adding swagger to application app 
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                // Defining place where swagger.json can be found
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Store API");
                // Address of swagger UI
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
