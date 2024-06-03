using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms; 

/// <summary>
/// 表单,生成的标签为&lt;form nz-form&gt;&lt;/form&gt;
/// </summary>
[HtmlTargetElement( "util-form" )]
public class FormTagHelper : FormContainerTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzLayout,布局方式,可选值: 'horizontal' | 'vertical' | 'inline' ,默认值: 'horizontal'
    /// </summary>
    public FormLayout Layout { get; set; }
    /// <summary>
    /// [nzLayout],布局方式,可选值: 'horizontal' | 'vertical' | 'inline' ,默认值: 'horizontal'
    /// </summary>
    public string BindLayout { get; set; }
    /// <summary>
    /// [nzAutoTips],自动提示,配置 &lt;util-form-control> 的 auto-tips 默认值, 类型: Record&lt;string, Record&lt;string, string>>
    /// </summary>
    public string AutoTips { get; set; }
    /// <summary>
    /// [nzDisableAutoTips],是否禁用自动提示,配置 &lt;util-form-control> 的 disable-auto-tips 默认值, 类型: boolean, 默认值: false
    /// </summary>
    public string DisableAutoTips { get; set; }
    /// <summary>
    /// [nzNoColon],是否不显示表单标签的冒号，配置 &lt;util-form-label> 的 no-colon 默认值, 类型: boolean, 默认值: false
    /// </summary>
    public string NoColon { get; set; }
    /// <summary>
    /// [nzLabelWrap],表单标签文本是否换行,配置 &lt;util-form-label> 的 label-wrap 默认值, 类型: boolean, 默认值: false
    /// </summary>
    public string LabelWrap { get; set; }
    /// <summary>
    /// nzLabelAlign,表单标签文本对齐方式, 配置 &lt;util-form-label> 的 label-align 默认值, 类型: 'left' | 'right', 默认值: 'right'
    /// </summary>
    public LabelAlign LabelAlign { get; set; }
    /// <summary>
    /// [nzLabelAlign],表单标签文本对齐方式, 配置 &lt;util-form-label> 的 label-align 默认值, 类型: 'left' | 'right', 默认值: 'right'
    /// </summary>
    public string BindLabelAlign { get; set; }
    /// <summary>
    /// nzTooltipIcon,表单标签提示图标，配置 &lt;util-form-label> 的 tooltip-icon 默认值, 类型: string | { type: string; theme: ThemeType },默认值: { type: 'question-circle', theme: 'outline' }
    /// </summary>
    public AntDesignIcon TooltipIcon { get; set; }
    /// <summary>
    /// [nzTooltipIcon],表单标签提示图标，配置 &lt;util-form-label> 的 tooltip-icon 默认值, 类型: string | { type: string; theme: ThemeType },默认值: { type: 'question-circle', theme: 'outline' }
    /// </summary>
    public string BindTooltipIcon { get; set; }
    /// <summary>
    /// autocomplete,是否打开浏览器自动完成功能,设置为 false 关闭浏览器自动完成
    /// </summary>
    public bool Autocomplete { get; set; }
    /// <summary>
    /// [formGroup],表单组实例,类型: FormGroup
    /// </summary>
    public string FormGroup { get; set; }
    /// <summary>
    /// 扩展属性,是否自动创建表单标签 &lt;nz-form-label>, 类型: boolean
    /// </summary>
    public bool ShowLabel { get; set; }
    /// <summary>
    /// 扩展属性,表单标签宽度, 可设置数值,单位: px, 范例: 100, 表示 "100px", 也可自行设置单位, 范例: "20%"
    /// </summary>
    public string LabelWidth { get; set; }
    /// <summary>
    /// novalidate,是否不验证表单,类型: boolean, 默认值: false
    /// </summary>
    public bool Novalidate { get; set; }
    /// <summary>
    /// (ngSubmit),表单提交事件,类型: EventEmitter&lt;void>
    /// </summary>
    public string OnSubmit { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new FormShareService( _config );
        service.Init();
        service.Created();
        service.SetFormId();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new FormRender( _config );
    }
}