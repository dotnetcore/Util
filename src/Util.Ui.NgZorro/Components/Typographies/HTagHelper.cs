using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Typographies {
    /// <summary>
    /// h1，生成的标签为&lt;h1 nz-typography&gt;&lt;/h1&gt;
    /// </summary>
    [HtmlTargetElement( "util-h1" )]
    public class H1TagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new H1Builder();
        }
    }

    /// <summary>
    /// h2，生成的标签为&lt;h2 nz-typography&gt;&lt;/h2&gt;
    /// </summary>
    [HtmlTargetElement( "util-h2" )]
    public class H2TagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new H2Builder();
        }
    }

    /// <summary>
    /// h3，生成的标签为&lt;h3 nz-typography&gt;&lt;/h3&gt;
    /// </summary>
    [HtmlTargetElement( "util-h3" )]
    public class H3TagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new H3Builder();
        }
    }

    /// <summary>
    /// h4，生成的标签为&lt;h4 nz-typography&gt;&lt;/h4&gt;
    /// </summary>
    [HtmlTargetElement( "util-h4" )]
    public class H4TagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new H4Builder();
        }
    }

    /// <summary>
    /// h5，生成的标签为&lt;h5 nz-typography&gt;&lt;/h5&gt;
    /// </summary>
    [HtmlTargetElement( "util-h5" )]
    public class H5TagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new H5Builder();
        }
    }

    /// <summary>
    /// h6，生成的标签为&lt;h6 nz-typography&gt;&lt;/h6&gt;
    /// </summary>
    [HtmlTargetElement( "util-h6" )]
    public class H6TagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new H6Builder();
        }
    }
}
