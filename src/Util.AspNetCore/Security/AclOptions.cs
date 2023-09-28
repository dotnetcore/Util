namespace Util.Security;

/// <summary>
/// 访问控制配置
/// </summary>
public class AclOptions {
    /// <summary>
    /// 是否允许匿名访问,无需授权,无需登录
    /// </summary>
    public bool AllowAnonymous { get; set; }
    /// <summary>
    /// 是否忽略授权检查,无需授权,但仍需要登录
    /// </summary>
    public bool IgnoreAcl { get; set; }
    /// <summary>
    /// 全局资源标识,未指定资源标识的Api使用该值
    /// </summary>
    public string ResourceUri { get; set; }
}