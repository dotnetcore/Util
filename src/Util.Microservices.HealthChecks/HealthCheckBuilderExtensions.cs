using Util.Microservices.HealthChecks.Dapr;
using Util.Microservices.HealthChecks.EntityFrameworkCore;

namespace Util.Microservices.HealthChecks;

/// <summary>
/// 健康检查生成器扩展
/// </summary>
public static class HealthCheckBuilderExtensions {
    /// <summary>
    /// 配置Dapr健康检查
    /// </summary>
    /// <param name="builder">健康检查生成器</param>
    /// <param name="name">健康检查器名称，默认值：dapr</param>
    /// <param name="tags">标签集合</param>
    /// <param name="failureStatus">检测失败状态，默认值：HealthStatus.Unhealthy</param>
    public static IHealthChecksBuilder AddDapr( this IHealthChecksBuilder builder, string name = "dapr", IEnumerable<string> tags = null, HealthStatus? failureStatus = null ) {
        builder.CheckNull( nameof( builder ) );
        failureStatus ??= HealthStatus.Unhealthy;
        tags ??= Enumerable.Empty<string>();
        return builder.AddCheck<DaprHealthCheck>( name, failureStatus, tags );
    }

    /// <summary>
    /// 配置工作单元健康检查
    /// </summary>
    /// <param name="builder">健康检查生成器</param>
    /// <param name="name">健康检查器名称，默认值：unitOfWork</param>
    /// <param name="tags">标签集合</param>
    /// <param name="failureStatus">检测失败状态，默认值：HealthStatus.Unhealthy</param>
    public static IHealthChecksBuilder AddUnitOfWork<TUnitOfWork>( this IHealthChecksBuilder builder, string name = "unitOfWork", IEnumerable<string> tags = null, HealthStatus? failureStatus = null )
        where TUnitOfWork: IUnitOfWork {
        builder.CheckNull( nameof( builder ) );
        failureStatus ??= HealthStatus.Unhealthy;
        tags ??= Enumerable.Empty<string>();
        return builder.AddCheck<UnitOfWorkHealthCheck<TUnitOfWork>>( name, failureStatus, tags );
    }

    /// <summary>
    /// 配置Url健康检查
    /// </summary>
    /// <param name="builder">健康检查生成器</param>
    /// <param name="url">请求地址</param>
    /// <param name="name">健康检查器名称</param>
    /// <param name="tags">标签集合</param>
    /// <param name="failureStatus">检测失败状态，默认值：HealthStatus.Unhealthy</param>
    public static IHealthChecksBuilder AddUrl( this IHealthChecksBuilder builder,string url, string name, IEnumerable<string> tags = null, HealthStatus? failureStatus = null ) {
        builder.CheckNull( nameof( builder ) );
        failureStatus ??= HealthStatus.Unhealthy;
        tags ??= Enumerable.Empty<string>();
        return builder.AddUrlGroup( new Uri( url ), name, failureStatus, tags );
    }
}
