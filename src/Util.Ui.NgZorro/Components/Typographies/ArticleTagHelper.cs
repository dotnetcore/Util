using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Typographies {
    /// <summary>
    /// 文章，生成的标签为&lt;article nz-typography&gt;&lt;/article&gt;
    /// </summary>
    [HtmlTargetElement( "util-article" )]
    public class ArticleTagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new ArticleBuilder();
        }
    }
}
