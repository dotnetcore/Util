namespace Util.Localization; 

/// <summary>
/// 本地化配置
/// </summary>
public class LocalizationOptions {
    /// <summary>
    /// 初始化本地化配置
    /// </summary>
    public LocalizationOptions() {
        Cultures = new List<string>();
    }

    /// <summary>
    /// 语言文化
    /// </summary>
    public IList<string> Cultures { get; set; }

    /// <summary>
    /// 缓存过期时间间隔,单位: 秒 ,默认值: 28800
    /// </summary>
    public int Expiration { get; set; } = 28800;

    /// <summary>
    /// 是否本地化Warning异常消息,默认值: false
    /// </summary>
    public bool IsLocalizeWarning { get; set; }
}