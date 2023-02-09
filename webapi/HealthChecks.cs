using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace webapi
{
    public sealed class HealthCheck: IHealthCheck
    {
        public HealthCheck()
        {

        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken CancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}