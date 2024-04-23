using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Segments.Helpers;
using Util.Ui.NgZorro.Components.Segments.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Segments;

/// <summary>
/// 分段控制器,生成的标签为&lt;nz-segmented&gt;&lt;/nz-segmented&gt;
/// </summary>
[HtmlTargetElement( "util-segmented" )]
public class SegmentedTagHelper : FormControlTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 扩展属性,是否启用扩展指令,当设置Url或Data属性时自动启用,默认为 false
    /// </summary>
    public bool EnableExtend { get; set; }
    /// <summary>
    /// 扩展属性 [autoLoad],初始化时是否自动加载数据，默认为true,设置成false则手工加载
    /// </summary>
    public bool AutoLoad { get; set; }
    /// <summary>
    /// 扩展属性 [(queryParam)],查询参数
    /// </summary>
    public string QueryParam { get; set; }
    /// <summary>
    /// 扩展属性 url,Api地址
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 扩展属性 [url],Api地址
    /// </summary>
    public string BindUrl { get; set; }
    /// <summary>
    /// 扩展属性 [data],数据源
    /// </summary>
    public string Data { get; set; }
    /// <summary>
    /// 扩展属性 [(value)],双向绑定值
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// nzSize,组件尺寸，可选值: 'large'|'small'|'default'
    /// </summary>
    public InputSize Size { get; set; }
    /// <summary>
    /// [nzSize],组件尺寸，可选值: 'large'|'small'|'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzOptions],选项列表,类型: string[] | number[] | Array&lt;{ label: string; value: string | number; icon: string; disabled?: boolean; useTemplate?: boolean }>
    /// </summary>
    public string Options { get; set; }
    /// <summary>
    /// [nzBlock],是否将宽度调整为父元素宽度, 默认值: false
    /// </summary>
    public string Block { get; set; }
    /// <summary>
    /// (valueChange),扩展事件, 选中值变更事件
    /// </summary>
    public string OnValueChange { get; set; }
    /// <summary>
    /// 扩展事件 (onLoad),数据加载完成事件,类型: EventEmitter&lt;any>,参数为服务端返回结果
    /// </summary>
    public string OnLoad { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new SegmentedService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new SegmentedRender( _config );
    }
}