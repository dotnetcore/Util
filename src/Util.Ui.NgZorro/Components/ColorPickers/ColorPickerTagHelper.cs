using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.ColorPickers.Renders;
using Util.Ui.NgZorro.Components.Selects.Helpers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.ColorPickers;

/// <summary>
/// 颜色选择器,生成的标签为&lt;nz-color-picker&gt;&lt;/nz-color-picker&gt;
/// </summary>
[HtmlTargetElement( "util-color-picker" )]
public class ColorPickerTagHelper : FormControlTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzTitle,标题,支持i18n
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],标题,类型: string|TemplateRef&lt;void>
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// nzDefaultValue, 颜色默认值, 类型: string｜NzColor
    /// </summary>
    public string DefaultValue { get; set; }
    /// <summary>
    /// [nzDefaultValue], 颜色默认值, 类型: string｜NzColor
    /// </summary>
    public string BindDefaultValue { get; set; }
    /// <summary>
    /// nzValue, 颜色值, 类型: string｜NzColor
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// [nzValue], 颜色值, 类型: string｜NzColor
    /// </summary>
    public string BindValue { get; set; }
    /// <summary>
    /// [nzShowText],是否显示颜色文本,默认值: false
    /// </summary>
    public string ShowText { get; set; }
    /// <summary>
    /// nzSize,控件尺寸, 可选值: 'default' | 'small' |  'large' , 默认值: 'default'
    /// </summary>
    public InputSize Size { get; set; }
    /// <summary>
    /// [nzSize],控件尺寸, 可选值: 'default' | 'small' |  'large' , 默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// [nzDisabledAlpha],是否禁用透明度, 默认值: false
    /// </summary>
    public string DisabledAlpha { get; set; }
    /// <summary>
    /// nzTrigger,触发模式, 可选值: hover｜click ,默认值: click
    /// </summary>
    public ColorPickerTrigger Trigger { get; set; }
    /// <summary>
    /// [nzTrigger],触发模式, 可选值: hover｜click ,默认值: click
    /// </summary>
    public string BindTrigger { get; set; }
    /// <summary>
    /// [nzAllowClear], 是否允许清除选择的颜色, 默认值: false
    /// </summary>
    public string AllowClear { get; set; }
    /// <summary>
    /// nzFormat,颜色格式, 可选值: rgb｜hex｜hsb ,默认值: hex
    /// </summary>
    public ColorPickerFormat Format { get; set; }
    /// <summary>
    /// [nzFormat],颜色格式, 可选值: rgb｜hex｜hsb ,默认值: hex
    /// </summary>
    public string BindFormat { get; set; }
    /// <summary>
    /// [nzOpen],是否显示弹出窗口 ,默认值: false
    /// </summary>
    public string Open { get; set; }
    /// <summary>
    /// (nzOnChange),颜色变化事件 ,类型: EventEmitter&lt;{color: NzColor;format: string}>
    /// </summary>
    public string OnChange { get; set; }
    /// <summary>
    /// (nzOnClear),清除颜色事件 ,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnClear { get; set; }
    /// <summary>
    /// (nzOnFormatChange),颜色格式变化事件 ,类型: EventEmitter&lt;'rgb'｜'hex'｜'hsb'>
    /// </summary>
    public string OnFormatChange { get; set; }
    /// <summary>
    /// (nzOnOpenChange),打开颜色面板事件 ,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnOpenChange { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new SelectService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new ColorPickerRender( _config );
    }
}