using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Checkboxes.Helpers;
using Util.Ui.NgZorro.Components.Checkboxes.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Checkboxes; 

/// <summary>
/// 复选框,生成的标签为&lt;label nz-checkbox&gt;&lt;/label&gt;
/// </summary>
[HtmlTargetElement( "util-checkbox" )]
public class CheckboxTagHelper : FormControlTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzId,组件内部的 id
    /// </summary>
    public string NzId { get; set; }
    /// <summary>
    /// [nzId],组件内部的 id
    /// </summary>
    public string BindNzId { get; set; }
    /// <summary>
    /// [nzAutoFocus],是否自动获取焦点, 类型: boolean, 默认值: false
    /// </summary>
    public string AutoFocus { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// [nzIndeterminate],是否中间状态,当复选框未全部选中或全部取消时,全选复选框的状态, 类型: boolean, 默认值: false
    /// </summary>
    public string Indeterminate { get; set; }
    /// <summary>
    /// nzValue,值,与 &lt;util-checkbox-wrapper> 的 on-change 配合使用
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// [nzValue],值,与 &lt;util-checkbox-wrapper> 的 on-change 配合使用
    /// </summary>
    public string BindValue { get; set; }
    /// <summary>
    /// 扩展属性, 标签文本, 支持多语言
    /// </summary>
    public string Label { get; set; }
    /// <summary>
    /// 扩展属性, 标签文本
    /// </summary>
    public string BindLabel { get; set; }
    /// <summary>
    /// [nzChecked],是否选中, 类型: boolean, 默认值: false
    /// </summary>
    public string Checked { get; set; }
    /// <summary>
    /// (nzCheckedChange),选中状态变化事件, 类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnCheckedChange { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new CheckboxService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new CheckboxRender( _config );
    }
}