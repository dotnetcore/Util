using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Radios.Helpers;
using Util.Ui.NgZorro.Components.Radios.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Radios; 

/// <summary>
/// 单选框组合,生成的标签为&lt;nz-radio-group&gt;&lt;/nz-radio-group&gt;
/// </summary>
[HtmlTargetElement( "util-radio-group" )]
public class RadioGroupTagHelper : FormControlTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzName,将单选框设置为同一组选项
    /// </summary>
    public new string Name { get; set; }
    /// <summary>
    /// [nzName],将单选框设置为同一组选项
    /// </summary>
    public new string BindName { get; set; }
    /// <summary>
    /// nzSize,尺寸,只对按钮样式生效,可选值: 'large' | 'small' | 'default', 默认值: 'default'
    /// </summary>
    public ButtonSize Size { get; set; }
    /// <summary>
    /// [nzSize],尺寸,只对按钮样式生效,可选值: 'large' | 'small' | 'default', 默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用,类型: boolean, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// nzButtonStyle,风格样式,可选值: 'outline' | 'solid',默认值: 'outline'
    /// </summary>
    public RadioStyle ButtonStyle { get; set; }
    /// <summary>
    /// [nzButtonStyle],风格样式,可选值: 'outline' | 'solid',默认值: 'outline'
    /// </summary>
    public string BindButtonStyle { get; set; }
    /// <summary>
    /// 扩展属性,是否启用扩展指令,当设置 url 或 data 属性时自动启用,默认值: false
    /// </summary>
    public bool EnableExtend { get; set; }
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
        base.ProcessBefore( context, output );
        _config = new Config( context, output );
        var service = new RadioGroupService( _config );
        service.Init();
        service.Created();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new RadioGroupRender( _config );
    }
}