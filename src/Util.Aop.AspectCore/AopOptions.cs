namespace Util.Aop;

/// <summary>
/// Aop配置
/// </summary>
public class AopOptions {
    /// <summary>
    /// 是否启用IAopProxy接口标记
    /// </summary>
    public bool IsEnableIAopProxy { get; set; }
    /// <summary>
    /// 是否启用参数拦截器,默认值: true
    /// </summary>
    public bool IsEnableParameterAspect { get; set; } = true;
}