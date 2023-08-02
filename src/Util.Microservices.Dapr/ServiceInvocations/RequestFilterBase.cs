namespace Util.Microservices.Dapr.ServiceInvocations; 

/// <summary>
/// WebApi服务调用请求过滤器
/// </summary>
public abstract class RequestFilterBase : IRequestFilter {
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled => true;
    /// <summary>
    /// 序号
    /// </summary>
    public int Order => 0;
    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="context">请求上下文</param>
    public abstract void Handle( RequestContext context );
}