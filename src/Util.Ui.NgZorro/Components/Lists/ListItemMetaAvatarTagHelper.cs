using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists; 

/// <summary>
/// 列表项元信息头像,生成的标签为&lt;nz-list-item-meta-avatar>&lt;/nz-list-item-meta-avatar>
/// </summary>
[HtmlTargetElement( "util-list-item-meta-avatar" )]
public class ListItemMetaAvatarTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzSrc,头像地址
    /// </summary>
    public string Src { get; set; }
    /// <summary>
    /// [nzSrc],头像地址
    /// </summary>
    public string BindSrc { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ListItemMetaAvatarRender( config );
    }
}