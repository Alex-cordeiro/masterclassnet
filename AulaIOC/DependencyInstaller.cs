using AulaIOC.HttpClients;
using AulaIOC.Services.Interfaces;
using AulaIOC.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AulaIOC
{
    public static class DependencyInstaller
    {

        public static IServiceCollection ConfiguracaoServicos(this IServiceCollection services)
        {
            services.AddTransient<ICepService, CepService>();
            return services;
        }

        public static IServiceCollection ConfiguracaoRefitClient(this IServiceCollection services, IConfiguration configuration)
        {
            string? baseUrlCep = configuration.GetSection("VIACEP").Value;

            services.AddRefitClient<IViaCepRefit>()
                             .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrlCep));

            return services;
        }
    }
}
