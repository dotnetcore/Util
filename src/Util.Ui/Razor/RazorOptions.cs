namespace Util.Ui.Razor; 

/// <summary>
/// Razor配置
/// </summary>
public class RazorOptions {
    /// <summary>
    /// 是否在Razor页面运行时自动生成html文件
    /// </summary>
    public bool IsGenerateHtml { get; set; }
    /// <summary>
    /// Razor生成Html页面的基路径,默认值: /ClientApp/src/app
    /// </summary>
    public string GenerateHtmlBasePath { get; set; } = "/ClientApp/src/app";
    /// <summary>
    /// Razor生成Html文件的目录名称，默认值：html
    /// </summary>
    public string GenerateHtmlFolder { get; set; } = "html";
    /// <summary>
    /// Razor生成Html页面的文件后缀，默认值：component.html
    /// </summary>
    public string GenerateHtmlSuffix { get; set; } = "component.html";
}