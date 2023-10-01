namespace Util.Localization; 

/// <summary>
/// Json本地化配置
/// </summary>
public class JsonLocalizationOptions : LocalizationOptions {
    /// <summary>
    /// 初始化Json本地化配置
    /// </summary>
    public JsonLocalizationOptions() {
        ResourcesPath = "Resources";
    }

    /// <summary>
    /// 资源路径
    /// </summary>
    public string ResourcesPath { get; set; }
}