using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastructure.Response;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API.HealthCheck
{
    /// <summary>
    /// Health check builder with some customized options.
    /// </summary>
    public static class HealthChecksBuilder
    {
        /// <summary>
        /// Creates the health check options with a custom response writer.
        /// </summary>
        /// <returns>Customized HealthCheckOptions.</returns>
        public static HealthCheckOptions CreateOptions()
        {
            var options = new HealthCheckOptions
            {
                AllowCachingResponses = false,
                ResultStatusCodes = new Dictionary<HealthStatus, int>
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                },
                ResponseWriter = UnifyHealthCheckResponse
            };

            return options;
        }

        /// <summary>
        /// Unifies health check response and writes a json object into respose stream.
        /// </summary>
        /// <param name="httpContext">Required httpContext to modify response stream.</param>
        /// <param name="result">Health report generated.</param>
        /// <returns>Awaitable task</returns>
        private static Task UnifyHealthCheckResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var response = new HealthCheckResponseModel
            {
                Overall = result.Status.ToString(),
                Duration = result.TotalDuration.ToString("g")
            };

            result.Entries.ToList().ForEach(entry => { response.Entries.Add(new HealthCheckEntry(entry.Key, entry.Value.Status.ToString(), entry.Value.Duration.ToString("g"))); });

            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}