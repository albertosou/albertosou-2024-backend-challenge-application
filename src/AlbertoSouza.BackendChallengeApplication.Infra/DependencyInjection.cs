using Microsoft.Extensions.DependencyInjection;

namespace AlbertoSouza.BackendChallengeApplication.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtValidationService, JwtValidationService>();

        return services;
    }
}
