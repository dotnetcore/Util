using Util.Ui.NgZorro.Enums;
using Util.Ui.Razor;

namespace Util.Ui.NgZorro;

/// <summary>
/// NgZorro配置
/// </summary>
public class NgZorroOptions : RazorOptions {
    /// <summary>
    /// 初始化NgZorro配置
    /// </summary>
    public NgZorroOptions() {
        if ( Util.Helpers.Environment.IsTest ) {
            EnableDefaultOptionText = false;
            EnableI18n = false;
            EnableAllowClear = false;
            EnableWatchRazor = false;
        }
    }

    /// <summary>
    /// 是否启用默认项文本,默认值: true
    /// </summary>
    public bool EnableDefaultOptionText { get; set; } = true;
    /// <summary>
    /// 是否启用多语言,默认值: true
    /// </summary>
    public bool EnableI18n { get; set; } = true;
    /// <summary>
    /// 是否启用全局输入框设置 autocomplete="off",默认值: false
    /// </summary>
    public bool EnableAutocompleteOff { get; set; }
    /// <summary>
    /// 是否启用允许清除输入框,默认值: true
    /// </summary>
    public bool EnableAllowClear { get; set; } = true;
    /// <summary>
    /// 是否启用勾选表格行复选框时添加样式类 table-row-checked ,默认值: false
    /// </summary>
    public bool EnableTableRowCheckedClass { get; set; }
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