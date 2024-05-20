using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Buttons.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Buttons;

/// <summary>
/// 链接,生成的标签为&lt;a&gt;&lt;/a&gt;
/// </summary>
[HtmlTargetElement( "util-a" )]
public class ATagHelper : ButtonTagHelperBase {
    /// <summary>
    /// 扩展属性,是否危险状态,默认值: false
    /// </summary>
    public bool Danger { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ARender( config );
    }
}