using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace AlbertoSouza.AppBackendChallenge.Infrastructure.OpenTelemetry
{
    public static class OpenTelemetryExtension
    {
        private static readonly int PORT_ADOT_GRPC = 4317;
        private static readonly int PORT_ADOT_HTTP = 4318;
        public static WebApplicationBuilder UseOpenTelemetryServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks()
                .AddCheck<OpenTelemetryHealthCheck>("ADOT");

            _ = builder.Services.AddOpenTelemetry()
                .WithLogging()
                .WithTracing(tracer => TracingAction(tracer, builder.Environment.ApplicationName))
                .WithMetrics(MetricsAction);

            var resourceBuilder = ResourceBuilder.CreateDefault()
                .AddService(builder.Environment.ApplicationName)
                .AddTelemetrySdk()
                .AddAttributes(new Dictionary<string, object>
                {
                    ["host.name"] = Environment.MachineName,
                    ["os.description"] = RuntimeInformation.OSDescription,
                    ["deployment.environment"] =
                        builder.Environment.EnvironmentName.ToLowerInvariant(),
                });



            builder.Logging.ClearProviders()
                .AddOpenTelemetry(options =>
                {
                    options
                        .SetResourceBuilder(resourceBuilder)
                        .AddProcessor(new OpenTelemetryLogProcessor())
                        .AddOtlpExporter(opt => opt.Endpoint = new Uri($"http://aws-otel-collector:{PORT_ADOT_GRPC}"))
                        .AddOtlpExporter(opt => opt.Endpoint = new Uri($"http://aws-otel-collector:{PORT_ADOT_HTTP}"))
                        .AddConsoleExporter();

                    options.IncludeFormattedMessage = true;
                    options.IncludeScopes = true;
                    options.ParseStateValues = true;
                });

            return builder;
        }

        private static void MetricsAction(MeterProviderBuilder meterBuilder)
        {
            meterBuilder.AddAspNetCoreInstrumentation()
                .AddOtlpExporter(opt => opt.Endpoint = new Uri($"http://aws-otel-collector:{PORT_ADOT_GRPC}"))
                .AddOtlpExporter(opt => opt.Endpoint = new Uri($"http://aws-otel-collector:{PORT_ADOT_HTTP}"));
        }


        private static void TracingAction(TracerProviderBuilder tracerBuilder, string applicationName)
        {
            tracerBuilder.AddSource(applicationName)
                .ConfigureResource(resource =>
                    resource.AddService(serviceName: applicationName))
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(opt =>opt.Endpoint = new Uri($"http://aws-otel-collector:{PORT_ADOT_GRPC}"))
                .AddOtlpExporter(opt =>opt.Endpoint = new Uri($"http://aws-otel-collector:{PORT_ADOT_HTTP}"));
        }

        public static void UseOpenTelemetry(this WebApplication app)
        {
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
