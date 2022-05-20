using FluxoCaixa.API.CustomFormat;
using FluxoCaixa.Application.Services;
using FluxoCaixa.Application.Services.Interfaces;
using FluxoCaixa.Core.Interfaces;
using FluxoCaixa.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFluxoCaixaRepository, FluxoCaixaRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // services.AddScoped<IFluxoCaixaServices, FluxoCaixaServices>();
            return services;
        }

        public static IServiceCollection AddCustomFormat(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });

            return services;
        }
    }
}