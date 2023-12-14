namespace Util.Ui.NgZorro; 

/// <summary>
/// NgZorro配置
/// </summary>
public class NgZorroOptions {
    /// <summary>
    /// Spa静态文件根路径,默认值: ClientApp
    /// </summary>
    public string RootPath { get; set; } = "ClientApp";
    /// <summary>
    /// 是否生成html
    /// </summary>
    internal bool IsGenerateHtml { get; set; }
    /// <summary>
    /// Razor生成Html页面的基路径,默认值: /ClientApp/src/app
    /// </summary>
    public string GenerateHtmlBasePath { get; set; } = "/ClientApp/src/app";
    /// <summary>
    /// Razor生成Html页面的文件后缀，默认值：component.html
    /// </summary>
    public string GenerateHtmlSuffix { get; set; } = "component.html";
    /// <summary>
    /// 是否启用默认项文本
    /// </summary>
    public bool EnableDefaultOptionText { get; set; }
    /// <summary>
    /// 是否启用多语言
    /// </summary>
    public bool EnableI18n { get; set; }
    /// <summary>
    /// 是否启用全局输入框设置 autocomplete="off"
    /// </summary>
    public bool EnableAutocompleteOff { get; set; }
    /// <summary>
    /// 是否启用允许清除输入框
    /// </summary>
    public bool EnableAllowClear { get; set; }
    /// <summary>
    /// 获取表格布尔列内容操作
    /// </summary>
    public Func<string, string> GetTableColumnBoolContentAction { get; set; }
}