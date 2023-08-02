namespace Util.Logging.Serilog; 

/// <summary>
/// 日志配置
/// </summary>
public class LogOptions {
    /// <summary>
    /// 是否清除默认设置的日志提供程序
    /// </summary>
    public bool IsClearProviders { get; set; }
    /// <summary>
    /// 应用程序名称
    /// </summary>
    public string Application { get; set; }
}