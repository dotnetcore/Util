using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.FooterToolbars.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.FooterToolbars;

/// <summary>
/// ng-alain 底部工具栏,生成的标签为&lt;footer-toolbar&gt;&lt;/footer-toolbar&gt;
/// </summary>
[HtmlTargetElement( "util-footer-toolbar" )]
public class FooterToolbarTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [errorCollect],是否收集表单错误,需要放入 form 标签内, 默认值: false
    /// </summary>
    public string ErrorCollect { get; set; }
    /// <summary>
    /// extra,额外信息，显示在左边
    /// </summary>
    public string Extra { get; set; }
    /// <summary>
    /// [extra],额外信息，显示在左边
    /// </summary>
    public string BindExtra { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new FooterToolbarRender( config );
    }
}