namespace Util.Microservices.HealthChecks.Dapr;

/// <summary>
/// Dapr健康检查
/// </summary>
public class DaprHealthCheck : IHealthCheck {
    /// <summary>
    /// Dapr客户端
    /// </summary>
    private readonly DaprClient _client;

    /// <summary>
    /// 初始化Dapr健康检查
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    public DaprHealthCheck( DaprClient client ) {
        _client = client ?? throw new ArgumentNullException( nameof( client ) );
    }

    /// <summary>
    /// 健康检查
    /// </summary>
    /// <param name="context">健康检查上下文</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task<HealthCheckResult> CheckHealthAsync( HealthCheckContext context, CancellationToken cancellationToken = default ) {
        try {
            var healthy = await _client.CheckHealthAsync( cancellationToken );
            return healthy ? HealthCheckResult.Healthy() : new HealthCheckResult( context.Registration.FailureStatus );
        }
        catch ( Exception exception ) {
            return HealthCheckResult.Unhealthy( exception.Message, exception );
        }
    }
}
