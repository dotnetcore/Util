using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.TagHelpers {
    /// <summary>
    /// TagHelper上下文
    /// </summary>
    public class Context {
        /// <summary>
        /// 初始化TagHelper上下文
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        /// <param name="content">内容</param>
        public Context( TagHelperContext context, TagHelperOutput output, IHtmlContent content ) {
            Attributes = new TagHelperAttributeList( context.AllAttributes ) ;
            OtherAttributes = output.Attributes;
            Content = content;
        }
        
        /// <summary>
        /// 属性集合，包含全部属性
        /// </summary>
        public TagHelperAttributeList Attributes { get; }

        /// <summary>
        /// 属性集合，在TagHelper中未明确定义的属性放入该集合
        /// </summary>
        public TagHelperAttributeList OtherAttributes { get; }

        /// <summary>
        /// 内容
        /// </summary>
        public IHtmlContent Content { get; }
    }
}
