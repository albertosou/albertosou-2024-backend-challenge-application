using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace AlbertoSouza.BackendChallengeApplication.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtValidationService, JwtValidationService>();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

        return services;
    }
}
