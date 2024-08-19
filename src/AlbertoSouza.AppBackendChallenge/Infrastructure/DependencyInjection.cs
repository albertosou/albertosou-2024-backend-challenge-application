using AlbertoSouza.AppBackendChallenge.Adapters;
using AlbertoSouza.AppBackendChallenge.Ports;
using Serilog;

namespace AlbertoSouza.AppBackendChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtValidationService, JwtValidationService>();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

        return services;
    }
}
