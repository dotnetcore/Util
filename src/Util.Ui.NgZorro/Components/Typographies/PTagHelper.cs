using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Typographies.Builders;

namespace Util.Ui.NgZorro.Components.Typographies;

/// <summary>
/// 段落，生成的标签为&lt;p nz-typography>&lt;/p>
/// </summary>
[HtmlTargetElement( "util-p" )]
public class PTagHelper : TypographyTagHelper {
    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder( Config config ) {
        return new PBuilder( config );
    }
}