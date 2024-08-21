using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace AlbertoSouza.AppBackendChallenge.Infrastructure.Swagger;

public static class SwaggerBootrstrap
{
    public static void ConfigureServices(this ServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT Validator", Version = "v1" });
            c.EnableAnnotations();
            c.OperationFilter<SwaggerDefaultValues>();
        });
    }
}
