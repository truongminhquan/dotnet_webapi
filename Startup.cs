using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using weatherapi.Data;
using weatherapi.Models;
namespace weatherapi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Console.WriteLine(Configuration.GetConnectionString("WeatherForecastConnection"));
            // services.AddDbContext<WeatherForecastContext>(opt => opt.UseSqlServer(
            //     Configuration.GetConnectionString("WeatherForecastConnection")));

            services.AddControllers();
            services.AddScoped<IWeatherForecastRepo, MockWeatherForecastRepo>();
            // services.AddScoped<IWeatherForecastRepo, SqlWeatherForecastRepo>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "weatherapi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // PrepDB.PrepPopulation(app);
        }
    }
}
