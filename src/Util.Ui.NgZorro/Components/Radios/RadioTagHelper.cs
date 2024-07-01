using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Radios.Helpers;
using Util.Ui.NgZorro.Components.Radios.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Radios;

/// <summary>
/// 按钮样式的单选框,生成的标签为&lt;label nz-radio-button&gt;&lt;/label&gt;
/// </summary>
[HtmlTargetElement( "util-radio-button" )]
public class RadioButtonTagHelper : RadioTagHelper {
    /// <summary>
    /// 获取指令名称
    /// </summary>
    protected override string GetDirectiveName() {
        return "nz-radio-button";
    }
}

/// <summary>
/// 单选框,生成的标签为&lt;label nz-radio&gt;&lt;/label&gt;
/// </summary>
[HtmlTargetElement( "util-radio" )]
public class RadioTagHelper : FormControlTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// [nzAutoFocus],是否自动获取焦点,类型: boolean, 默认值: false
    /// </summary>
    public string AutoFocus { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用,类型: boolean, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// nzValue,值
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// [nzValue],值
    /// </summary>
    public string BindValue { get; set; }
    /// <summary>
    /// 扩展属性,是否启用扩展指令,当设置 url 或 data 属性时自动启用,默认值: false
    /// </summary>
    public bool EnableExtend { get; set; }
    /// <summary>
    /// 扩展属性,标签文本,支持多语言
    /// </summary>
    public string Label { get; set; }
    /// <summary>
    /// 扩展属性,标签文本
    /// </summary>
    public string BindLabel { get; set; }
    /// <summary>
    /// 扩展属性 [data],数据源
    /// </summary>
    public string Data { get; set; }
    /// <summary>
    /// 扩展属性 url,Api地址
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 扩展属性 [url],Api地址
    /// </summary>
    public string BindUrl { get; set; }
    /// <summary>
    /// 扩展属性 [autoLoad],初始化时是否自动加载数据，默认值: true,设置成 false 手工加载
    /// </summary>
    public bool AutoLoad { get; set; }
    /// <summary>
    /// 扩展属性 [(queryParam)],查询参数
    /// </summary>
    public string QueryParam { get; set; }
    /// <summary>
    /// 扩展属性 order,排序条件,范例: creationTime desc
    /// </summary>
    public string Sort { get; set; }
    /// <summary>
    /// 扩展属性 [order],排序条件,范例: creationTime desc
    /// </summary>
    public string BindSort { get; set; }
    /// <summary>
    /// 扩展事件 (onLoad),数据加载完成事件,类型: EventEmitter&lt;any>,参数为服务端返回结果
    /// </summary>
    public string OnLoad { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new RadioService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new RadioRender( _config, GetDirectiveName() );
    }

    /// <summary>
    /// 获取指令名称
    /// </summary>
    protected virtual string GetDirectiveName() {
        return "nz-radio";
    }
}