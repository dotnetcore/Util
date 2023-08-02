namespace Util.Microservices; 

/// <summary>
/// WebApi服务调用请求过滤器
/// </summary>
public interface IRequestFilter {
    /// <summary>
    /// 是否启用
    /// </summary>
    bool Enabled { get; }
    /// <summary>
    /// 序号
    /// </summary>
    int Order { get; }
    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="context">请求上下文</param>
    void Handle( RequestContext context );
}