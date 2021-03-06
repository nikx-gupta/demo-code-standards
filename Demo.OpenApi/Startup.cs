using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Demo.OpenAPI.Validations;
using FluentValidation;

namespace Demo.OpenApi
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
            // Add Fluent Validations for Validation By Design
            services.AddControllers()
                .AddFluentValidation();

            // Register Validator Objects
            services.AddTransient<IValidator<AddAdGroupRequest>, AddAdGroupRequestValidator>();

            // Don't Create Open Policies If there is no requirement
            services.AddCors((opt) =>
            {
                opt.AddPolicy("Open", (pol)=>
                {
                    pol.AllowAnyMethod();
                    pol.AllowAnyHeader();
                    pol.AllowAnyOrigin();
                });
            });
           
            // Create Restrictive instead. Leverage This POST policy on POST methods
            services.AddCors((opt) =>
            {
                opt.AddPolicy("POST", (pol) =>
                {
                    pol.WithMethods("POST");
                    pol.WithOrigins("www.google.com,www.customdomain.com");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo.OpenApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo.OpenApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
