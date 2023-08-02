namespace Util.Microservices; 

/// <summary>
/// 服务状态码
/// </summary>
public enum ServiceState {
    /// <summary>
    /// 失败
    /// </summary>
    Fail,
    /// <summary>
    /// 成功
    /// </summary>
    Ok,
    /// <summary>
    /// 未授权
    /// </summary>
    Unauthorized
}