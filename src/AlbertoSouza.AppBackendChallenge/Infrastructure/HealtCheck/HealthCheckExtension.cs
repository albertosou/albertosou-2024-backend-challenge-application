using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Text.Json;

namespace AlbertoSouza.AppBackendChallenge.Infrastructure.HealtCheck
{
    public static class HealthCheckExtension
    {
        public static WebApplicationBuilder UseHealthChecksServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks()
                .AddCheck<AdotHealthCheck>("ADOT");

            builder.Services.AddOpenTelemetry()
                .WithTracing(tracerProviderBuilder =>
                    tracerProviderBuilder.AddSource(builder.Environment.ApplicationName)
                        .ConfigureResource(resource =>
                            resource.AddService(serviceName: builder.Environment.ApplicationName))
                        .AddAspNetCoreInstrumentation()
                        .AddOtlpExporter(opt =>
                        {
                            opt.Endpoint = new Uri("http://aws-otel-collector:4317");
                        }));

            return builder;
        }

        public static void UseHealthChecks(this WebApplication app)
        {
            //app.UseOpenTelemetryTracing();

            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        status = report.Status.ToString(),
                        checks = report.Entries.Select(e => new
                        {
                            name = e.Key,
                            status = e.Value.Status.ToString(),
                            description = e.Value.Description
                        })
                    });

                    await context.Response.WriteAsync(result);
                }
            });
        }
    }
}
