using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Images.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Images;

/// <summary>
/// 图片分组,生成的标签为&lt;nz-image-group>&lt;/nz-image-group>
/// </summary>
[HtmlTargetElement( "util-image-group" )]
public class ImageGroupTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzScaleStep], `1 + nzScaleStep` 为缩放放大的每步倍数, 类型: number
    /// </summary>
    public string ScaleStep { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ImageGroupRender( config );
    }
}