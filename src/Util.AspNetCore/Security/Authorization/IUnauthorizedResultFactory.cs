namespace Util.Security.Authorization;

/// <summary>
/// 未授权返回结果工厂
/// </summary>
public interface IUnauthorizedResultFactory : ISingletonDependency {
    /// <summary>
    /// 设置Http状态码
    /// </summary>
    int HttpStatusCode { get; }
    /// <summary>
    /// 创建未授权返回结果
    /// </summary>
    /// <param name="context">Http上下文</param>
    object CreateResult( HttpContext context );
}