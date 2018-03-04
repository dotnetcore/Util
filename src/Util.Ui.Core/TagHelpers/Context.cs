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
            AllAttributes = new TagHelperAttributeList( context.AllAttributes ) ;
            OutputAttributes = output.Attributes;
            Content = content;
            TagHelperContext = context;
        }

        /// <summary>
        /// 全部属性集合
        /// </summary>
        public TagHelperAttributeList AllAttributes { get; }

        /// <summary>
        /// 输出属性集合，TagHelper中未明确定义的属性从该集合获取
        /// </summary>
        public TagHelperAttributeList OutputAttributes { get; }

        /// <summary>
        /// 内容
        /// </summary>
        public IHtmlContent Content { get; }

        /// <summary>
        /// TagHelper上下文
        /// </summary>
        public TagHelperContext TagHelperContext { get; }

        /// <summary>
        /// 从TagHelperContext Items里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">键</param>
        public T GetValue<T>( object key ) {
            var exists = TagHelperContext.Items.TryGetValue( key, out var attribute );
            if ( exists == false )
                return default( T );
            var tagHelperAttribute = attribute as TagHelperAttribute;
            return Util.Helpers.Convert.To<T>( tagHelperAttribute?.Value );
        }
    }
}
