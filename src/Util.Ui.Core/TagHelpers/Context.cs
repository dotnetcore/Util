using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Extensions;

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
        public Context( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            TagHelperContext = context;
            Output = output;
            AllAttributes = new TagHelperAttributeList( context.AllAttributes ) ;
            OutputAttributes = new TagHelperAttributeList( output.Attributes ); 
            Content = content;
        }

        /// <summary>
        /// TagHelper上下文
        /// </summary>
        public TagHelperContext TagHelperContext { get; }

        /// <summary>
        /// TagHelper输出
        /// </summary>
        public TagHelperOutput Output { get; }

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
        public TagHelperContent Content { get; set; }

        /// <summary>
        /// 从TagHelperContext Items里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">键</param>
        public T GetValueFromItems<T>( object key = null ) {
            return TagHelperContext.GetValueFromItems<T>( key );
        }

        /// <summary>
        /// 设置TagHelperContext Items值
        /// </summary>
        /// <param name="value">值</param>
        public void SetValueToItems<T>( T value ) {
            TagHelperContext.SetValueToItems( value );
        }

        /// <summary>
        /// 移除TagHelperContext Items值
        /// </summary>
        public void RemoveFromItems<T>() {
            TagHelperContext.RemoveFromItems<T>();
        }
    }
}
