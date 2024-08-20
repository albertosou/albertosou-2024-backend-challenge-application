using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AlbertoSouza.AppBackendChallenge.Infrastructure.HealtCheck;

public class AdotHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            // Aqui você pode fazer uma chamada para o endpoint de health check do ADOT
            // Por padrão, o health check do ADOT é exposto na porta 13133
            using var client = new HttpClient();
            var response = client.GetAsync("http://aws-otel-collector:13133").Result;

            if (response.IsSuccessStatusCode)
            {
                return Task.FromResult(HealthCheckResult.Healthy("ADOT Collector is healthy"));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("ADOT Collector is not responding"));
            }
        }
        catch (Exception ex)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy($"ADOT Collector check failed: {ex.Message}"));
        }
    }
}
