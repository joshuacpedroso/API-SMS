using Envio.Api.Service;

namespace Envio.Api.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
           services.AddScoped<IEnvioService, EnvioService>();

            return services;
        }
    }
}
