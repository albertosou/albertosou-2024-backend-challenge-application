using AlbertoSouza.AppBackendChallenge.Adapters;
using AlbertoSouza.AppBackendChallenge.Ports;

namespace AlbertoSouza.AppBackendChallenge.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtValidationService, JwtValidationService>();

        return services;
    }
}
