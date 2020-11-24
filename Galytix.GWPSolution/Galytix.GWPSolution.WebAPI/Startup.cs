using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Galytix.GWPSolution.WebAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Galytix.GWPSolution.WebAPI
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
            services.AddScoped<Operations.IGWPOperations, Operations.GWPOperations>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Galutix GWP Solution API",
                    Version = "v1",
                    Description = "API Definations for GWP Solutions",
                });
            });
            LoadDataFromCsv(services);
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
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Galutix GWP Solution API"));

        }

        /// <summary>
        /// Load data from csv.
        /// </summary>
        private void LoadDataFromCsv(IServiceCollection services)
        {
            var logger = services.BuildServiceProvider().GetService<ILogger>();
            try
            {

                var fileName = Path.Combine($"DataSource", "gwpByCountry.csv");
                FileInfo inputFile = new FileInfo(fileName);
                using (var reader = new StreamReader(inputFile.FullName))
                using (var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csvReader.Configuration.RegisterClassMap<GWPByCountryMap>();
                    var gwpList = csvReader.GetRecords<Model.GWPByCountry>().ToList();
                    ApplicationSharedInstance.GWPCountryData = gwpList;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

        }
    }
}
