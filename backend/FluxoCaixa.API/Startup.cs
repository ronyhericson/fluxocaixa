using System;
using FluxoCaixa.API.Extensions;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;
using FluxoCaixa.Infrastructure.Commands;
using FluxoCaixa.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FluxoCaixa.API
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

            services.AddSingleton<IConnectionManager>
                  (new NpgsqlConnectionManager
                      (
                         Configuration["DatabaseSettings:ConnectionString"],
                         null
                      )
                  );

            Environment.SetEnvironmentVariable("connectionString", Configuration["DatabaseSettings:ConnectionString"]);            
            services.AddCommandHandler<AddFluxoCaixaHandler, MovtoFluxoCaixa>();
            services
                .AddRepositories()
                .AddServices()
                .AddCors()
                .AddCustomFormat();

            services.AddScoped<ICommandsProcessor, CommandsProcessor>();
            services.AddAutoMapper(typeof(Startup));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FluxoCaixa.API", Version = "v1" });
            });

            services.AddHealthChecks()
                .AddNpgSql(Configuration["DatabaseSettings:ConnectionString"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FluxoCaixa.API v1"));
            }

           app.UseRouting();

            app.UseCors(option => option.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
