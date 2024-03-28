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
    /// <summary>
    /// 是否启用Razor监视服务,默认值: true
    /// </summary>
    public bool EnableWatchRazor { get; set; } = true;
    /// <summary>
    /// Razor监听服务启动初始化的延迟时间，单位: 毫秒, 默认值：1000, 注意: 需要等待Web服务启动完成才能开始初始化 
    /// </summary>
    public int StartInitDelay { get; set; } = 1000;
    /// <summary>
    /// 修改Razor页面生成Html文件的延迟时间，单位: 毫秒, 默认值：100 ,注意: 延迟太短可能导致生成异常
    /// </summary>
    public int HtmlRenderDelayOnRazorChange { get; set; } = 100;    
    /// <summary>
    /// 启动Razor监视服务时是否预热,默认值: true
    /// </summary>
    public bool EnablePreheat { get; set; } = true;
    /// <summary>
    /// 启用Razor生成覆盖已存在的html文件,默认值: true
    /// </summary>
    public bool EnableOverrideHtml { get; set; } = true;
}