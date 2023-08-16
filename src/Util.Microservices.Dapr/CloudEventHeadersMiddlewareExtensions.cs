using Microsoft.AspNetCore.Builder;
using Util.Microservices.Dapr.Events;

namespace Util.Microservices.Dapr;

/// <summary>
/// 云事件标头处理中间件扩展
/// </summary>
public static class CloudEventHeadersMiddlewareExtensions {
    /// <summary>
    /// 注册云事件标头处理中间件,注意: 必须在 app.UseCloudEvents() 之前调用
    /// </summary>
    /// <param name="builder">应用程序生成器</param>
    public static IApplicationBuilder UseCloudEventHeaders( this IApplicationBuilder builder ) {
        return builder.UseMiddleware<CloudEventHeadersMiddleware>();
    }
}