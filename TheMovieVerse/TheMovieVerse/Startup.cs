using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMovieVerse.DB;

namespace TheMovieVerse
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

            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DatabaseConnection")));

            services.AddSwaggerGen();
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TheMovieVerse Service",
                    Version = "v1"
                });
                //var basePath = AppContext.BaseDirectory;
                //var xmlPath = Path.Combine(basePath, "Dmart.APIProject.xml");
                //swag.IncludeXmlComments(xmlPath);
                //var xmlPath2 = Path.Combine(basePath, "Dmart.Model.xml");
                //swag.IncludeXmlComments(xmlPath2);
                // swag.DescribeAllEnumsAsStrings();
                //swag.DescribeAllParametersInCamelCase();
                //swag.CustomSchemaIds(i => i.FullName);
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("v1/swagger.json", "TheMovieVerse Service"));
        }
    }
}
