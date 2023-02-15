using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Links.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Links {
    /// <summary>
    /// 链接,生成的标签为&lt;a&gt;&lt;/a&gt;
    /// </summary>
    [HtmlTargetElement( "util-a" )]
    public class ATagHelper : ButtonTagHelperBase {
        /// <summary>
        /// href,链接地址
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// [href],链接地址
        /// </summary>
        public string BindHref { get; set; }
        /// <summary>
        /// target,链接打开目标
        /// </summary>
        public ATarget Target { get; set; }
        /// <summary>
        /// [target],链接打开目标
        /// </summary>
        public string BindTarget { get; set; }
        /// <summary>
        /// rel,指定当前文档与被链接文档的关系
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// [rel],指定当前文档与被链接文档的关系
        /// </summary>
        public string BindRel { get; set; }
        /// <summary>
        /// 扩展属性,是否危险状态
        /// </summary>
        public bool Danger { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ARender( config );
        }
    }
}