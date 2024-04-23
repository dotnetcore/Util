using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv.Renders;
using Util.Ui.NgAlain.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sv;

/// <summary>
/// ng-alain 查看值组件,生成的标签为&lt;sv-value&gt;&lt;/sv-value&gt;
/// </summary>
[HtmlTargetElement( "util-descriptions-x-value" )]
[HtmlTargetElement( "util-sv-value" )]
public class SvValueTagHelper : AngularTagHelperBase {
    /// <summary>
    /// prefix, 前缀
    /// </summary>
    public string Prefix { get; set; }
    /// <summary>
    /// [prefix], 前缀
    /// </summary>
    public string BindPrefix { get; set; }
    /// <summary>
    /// unit, 单位
    /// </summary>
    public string Unit { get; set; }
    /// <summary>
    /// [unit], 单位
    /// </summary>
    public string BindUnit { get; set; }
    /// <summary>
    /// tooltip, 文字提示, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Tooltip { get; set; }
    /// <summary>
    /// [tooltip], 文字提示, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindTooltip { get; set; }
    /// <summary>
    /// size, 尺寸, 可选值: 'default','small','large', 默认值: default
    /// </summary>
    public SvValueSize Size { get; set; }
    /// <summary>
    /// [size], 尺寸, 可选值: 'default','small','large', 默认值: default
    /// </summary>
    public string BindSize { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new SvValueRender( config );
    }
}