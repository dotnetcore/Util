using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Statistics.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Statistics; 

/// <summary>
/// 统计,生成的标签为&lt;nz-statistic>&lt;/nz-statistic>
/// </summary>
[HtmlTargetElement( "util-statistic" )]
public class StatisticTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzTitle,数值标题,支持多语言
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],数值标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// nzValue,数值,类型: string | number
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// [nzValue],数值,类型: string | number
    /// </summary>
    public string BindValue { get; set; }
    /// <summary>
    /// nzPrefix,数值前缀,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Prefix { get; set; }
    /// <summary>
    /// [nzPrefix],数值前缀,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPrefix { get; set; }
    /// <summary>
    /// nzSuffix,数值后缀,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Suffix { get; set; }
    /// <summary>
    /// [nzSuffix],数值后缀,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindSuffix { get; set; }
    /// <summary>
    /// [nzValueStyle],数值样式,类型: Object, 范例: { color: '#3F8600' }
    /// </summary>
    public string ValueStyle { get; set; }
    /// <summary>
    /// [nzValueTemplate],数值展示自定义模板,类型: TemplateRef&lt;{ $implicit: string | number }>
    /// </summary>
    public string ValueTemplate { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new StatisticRender( config );
    }
}