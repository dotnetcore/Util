namespace Util.Microservices; 

/// <summary>
/// WebApi服务调用响应过滤器
/// </summary>
public interface IResponseFilter {
    /// <summary>
    /// 是否启用
    /// </summary>
    bool Enabled { get; }
    /// <summary>
    /// 序号
    /// </summary>
    int Order { get; }
    /// <summary>
    /// 处理响应
    /// </summary>
    /// <param name="context">响应上下文</param>
    void Handle( ResponseContext context );
}