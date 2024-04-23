using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Typographies.Builders;

namespace Util.Ui.NgZorro.Components.Typographies; 

/// <summary>
/// 段落，生成的标签为&lt;p&gt;&lt;/p&gt;
/// </summary>
[HtmlTargetElement( "util-p" )]
public class PTagHelper : TypographyTagHelper {
    /// <summary>
    /// 是否排版组件
    /// </summary>
    public bool Typography { get; set; }

    /// <inheritdoc />
    protected override bool IsEnableTypography() {
        return false;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder( Config config ) {
        return new PBuilder( config );
    }
}