using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;
using MISA.Core.Services;
using MISA.AMIS.WebAPIs.Middleware;
using MISA.Infrastructure;
using MISA.Infrastructure.Respository;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.WebAPIs
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
            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.AMIS.WebAPIs", Version = "v1" });
            });

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseReposiotry<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.AMIS.WebAPIs v1"));
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(option => option.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
