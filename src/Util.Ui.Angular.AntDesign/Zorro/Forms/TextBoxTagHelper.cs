using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Base;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 文本框
    /// </summary>
    [HtmlTargetElement( "util-textbox" )]
    public class TextBoxTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 只读
        /// </summary>
        public bool Readonly { get; set; }
        /// <summary>
        /// 文本框类型
        /// </summary>
        public TextBoxType Type { get; set; }
        /// <summary>
        /// 电子邮件错误消息
        /// </summary>
        public string EmailMessage { get; set; }
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
        /// [nzMin],最小值
        /// </summary>
        public string Min { get; set; }
        /// <summary>
        /// [nzMax],最大值
        /// </summary>
        public string Max { get; set; }
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Regex { get; set; }
        /// <summary>
        /// 正则表达式错误消息
        /// </summary>
        public string RegexMessage { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动获取焦点，默认值： false
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzPrecision]，数值精度，即保留的小数位数，默认值：6
        /// </summary>
        public int Precision { get; set; }
        /// <summary>
        /// [nzStep]，每次改变数值，默认值：1
        /// </summary>
        public double Step { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new TextBoxConfig( context );
            var type = config.GetValue<TextBoxType?>( UiConst.Type );
            switch ( type ) {
                case TextBoxType.Multiple:
                    config.IsTextArea = true;
                    break;
                case TextBoxType.Number:
                    config.IsNumber = true;
                    break;
            }
            return new TextBoxRender( config );
        }
    }
}
