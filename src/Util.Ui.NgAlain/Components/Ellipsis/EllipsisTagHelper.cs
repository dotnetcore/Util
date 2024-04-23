using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Ellipsis.Helpers;
using Util.Ui.NgAlain.Components.Ellipsis.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Ellipsis;

/// <summary>
/// 文本省略组件,生成的标签为&lt;ellipsis&gt;&lt;/ellipsis&gt;
/// </summary>
[HtmlTargetElement( "util-ellipsis" )]
public class EllipsisTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 属性表达式
    /// </summary>
    public ModelExpression For { get; set; }
    /// <summary>
    /// [tooltip],是否显示文本完整内容的提示,默认值: false
    /// </summary>
    public string Tooltip { get; set; }
    /// <summary>
    /// [length],在按照长度截取下的文本最大字符数，超过则截取省略
    /// </summary>
    public string Length { get; set; }
    /// <summary>
    /// [lines],在按照行数截取下最大的行数，超过则截取省略
    /// </summary>
    public string Lines { get; set; }
    /// <summary>
    /// [fullWidthRecognition],是否将全角字符的长度视为2来计算字符串长度,默认值: false
    /// </summary>
    public string FullWidthRecognition { get; set; }
    /// <summary>
    /// tail,指定溢出尾巴,默认值: ...
    /// </summary>
    public string Tail { get; set; }
    /// <summary>
    /// [tail],指定溢出尾巴,默认值: ...
    /// </summary>
    public string BindTail { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var loader = new EllipsisExpressionLoader();
        loader.Load( _config );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new EllipsisRender( _config );
    }
}