namespace Util.Localization; 

/// <summary>
/// Json本地化配置
/// </summary>
public class JsonLocalizationOptions {
    /// <summary>
    /// 初始化Json本地化配置
    /// </summary>
    public JsonLocalizationOptions() {
        ResourcesPath = "Resources";
        Cultures = new List<string>();
    }

    /// <summary>
    /// 资源路径
    /// </summary>
    public string ResourcesPath { get; set; }

    /// <summary>
    /// 语言文化
    /// </summary>
    public IList<string> Cultures { get; set; }
}