using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Services;
using Services.Interfaces;




namespace CalculoMediaAluno
{
	public class Startup
	{
       
        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddControllers();

            //sservices.AddHttpContextAccessor();


            ConfigureRoute(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalculoMédia", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo Média V1");
            });

        }

        private void ConfigureRoute(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }

    }
}

