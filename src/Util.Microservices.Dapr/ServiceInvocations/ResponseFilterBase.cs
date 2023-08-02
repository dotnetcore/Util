namespace Util.Microservices.Dapr.ServiceInvocations;

/// <summary>
/// WebApi服务调用响应过滤器
/// </summary>
public abstract class ResponseFilterBase : IResponseFilter {
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled => true;
    /// <summary>
    /// 序号
    /// </summary>
    public int Order => 0;
    /// <summary>
    /// 处理响应
    /// </summary>
    /// <param name="context">响应上下文</param>
    public abstract void Handle( ResponseContext context );
}