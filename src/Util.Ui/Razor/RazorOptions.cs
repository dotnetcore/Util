namespace Util.Ui.Razor; 

/// <summary>
/// Razor配置
/// </summary>
public class RazorOptions {
    /// <summary>
    /// Razor文件根路径,默认值: /ClientApp
    /// </summary>
    public string RazorRootDirectory { get; set; } = "/ClientApp";
    /// <summary>
    /// Spa静态文件根路径,默认值: ClientApp
    /// </summary>
    public string RootPath { get; set; } = "ClientApp";
    /// <summary>
    /// Razor页面生成html文件路径的版本,用于兼容传统使用方式,可选值: v1,v2, 如果需要退回到传统生成路径,传入 v1
    /// </summary>
    public string GenerateHtmlVersion { get; set; }
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
    /// 修改Razor页面生成Html文件的延迟时间，单位: 毫秒, 默认值：300 ,注意: 延迟太短可能导致生成异常
    /// </summary>
    public int HtmlRenderDelayOnRazorChange { get; set; } = 300;    
    /// <summary>
    /// 启动Razor监视服务时是否预热,默认值: true
    /// </summary>
    public bool EnablePreheat { get; set; } = true;
    /// <summary>
    /// 启用Razor生成覆盖已存在的html文件,默认值: true
    /// </summary>
    public bool EnableOverrideHtml { get; set; } = true;
}