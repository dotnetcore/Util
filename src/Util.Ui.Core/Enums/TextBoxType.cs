using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 文本框类型
    /// </summary>
    public enum TextBoxType {
        /// <summary>
        /// 文本框
        /// </summary>
        [Description( "text" )]
        Text,
        /// <summary>
        /// 密码框
        /// </summary>
        [Description( "password" )]
        Password,
        /// <summary>
        /// 数字框
        /// </summary>
        [Description( "number" )]
        Number,
        /// <summary>
        /// 电子邮件框
        /// </summary>
        [Description( "email" )]
        Email,
        /// <summary>
        /// 多行文本框
        /// </summary>
        [Description( "text" )]
        Multiple
    }
}
