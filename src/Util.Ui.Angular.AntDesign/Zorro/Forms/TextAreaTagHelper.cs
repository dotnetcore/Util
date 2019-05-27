using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Base;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 多行文本框
    /// </summary>
    [HtmlTargetElement( "util-textarea" )]
    public class TextAreaTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 最小行数
        /// </summary>
        public string MinRows { get; set; }
        /// <summary>
        /// 最大行数
        /// </summary>
        public string MaxRows { get; set; }
        /// <summary>
        /// 最小长度
        /// </summary>
        public string MinLength { get; set; }
        /// <summary>
        /// 最小长度错误消息
        /// </summary>
        public string MinLengthMessage { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public string MaxLength { get; set; }
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Regex { get; set; }
        /// <summary>
        /// 正则表达式错误消息
        /// </summary>
        public string RegexMessage { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new TextBoxConfig( context ) {IsTextArea = true};
            return new TextBoxRender( config );
        }
    }
}
