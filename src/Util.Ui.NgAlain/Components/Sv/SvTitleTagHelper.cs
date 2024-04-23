using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sv;

/// <summary>
/// ng-alain 查看标题组件,生成的标签为&lt;sv-title&gt;&lt;/sv-title&gt;
/// </summary>
[HtmlTargetElement( "util-descriptions-x-title" )]
[HtmlTargetElement( "util-sv-title" )]
public class SvTitleTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 扩展属性, 标题, 支持i18n
    /// </summary>
    public string Title { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new SvTitleRender( config );
    }
}