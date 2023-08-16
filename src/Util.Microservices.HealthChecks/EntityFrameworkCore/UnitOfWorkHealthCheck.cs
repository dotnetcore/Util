namespace Util.Microservices.HealthChecks.EntityFrameworkCore;

/// <summary>
/// 工作单元健康检查
/// </summary>
/// <typeparam name="TUnitOfWork">工作单元类型</typeparam>
public class UnitOfWorkHealthCheck<TUnitOfWork> : IHealthCheck where TUnitOfWork : IUnitOfWork {
    /// <summary>
    /// 工作单元
    /// </summary>
    private readonly TUnitOfWork _unitOfWork;

    /// <summary>
    /// 初始化工作单元健康检查
    /// </summary>
    /// <param name="unitOfWork">工作单元</param>
    public UnitOfWorkHealthCheck( TUnitOfWork unitOfWork ) {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException( nameof( unitOfWork ) );
    }

    /// <summary>
    /// 健康检查
    /// </summary>
    /// <param name="context">健康检查上下文</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task<HealthCheckResult> CheckHealthAsync( HealthCheckContext context, CancellationToken cancellationToken = default ) {
        context.CheckNull( nameof( context ) );
        try {
            var healthy = await _unitOfWork.CanConnectAsync( cancellationToken );
            return healthy ? HealthCheckResult.Healthy() : new HealthCheckResult( context.Registration.FailureStatus );
        }
        catch ( Exception exception ) {
            return HealthCheckResult.Unhealthy( exception.Message, exception );
        }
    }
}
