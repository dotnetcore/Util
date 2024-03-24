using Util.Ui.NgZorro.Enums;

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
    /// Razor生成Html文件的目录名称，默认值：html
    /// </summary>
    public string GenerateHtmlFolder { get; set; } = "html";
    /// <summary>
    /// Razor生成Html页面的文件后缀，默认值：component.html
    /// </summary>
    public string GenerateHtmlSuffix { get; set; } = "component.html";
    /// <summary>
    /// 修改Razor页面生成Html文件的延迟时间，单位: 毫秒, 默认值：100 ,注意: 延迟太短可能导致生成异常
    /// </summary>
    public int HtmlRenderDelayOnRazorChange { get; set; } = 100;
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
    /// <summary>
    /// 表格设置组件标签名，默认值：x-table-settings
    /// </summary>
    public string TableSettingsTag { get; set; } = "x-table-settings";
    /// <summary>
    /// 表格复选框对齐方式，默认值：左对齐
    /// </summary>
    public TableHeadColumnAlign TableCheckboxAlign { get; set; } = TableHeadColumnAlign.Left;
    /// <summary>
    /// 表格单选按钮对齐方式，默认值：左对齐
    /// </summary>
    public TableHeadColumnAlign TableRadioAlign { get; set; } = TableHeadColumnAlign.Left;
    /// <summary>
    /// 表格序号对齐方式，默认值：左对齐
    /// </summary>
    public TableHeadColumnAlign TableLineNumberAlign { get; set; } = TableHeadColumnAlign.Left;
}