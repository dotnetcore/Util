using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 输入框类型
    /// </summary>
    public enum InputType {
        /// <summary>
        /// 文本输入框
        /// </summary>
        [Description( "text" )]
        Text,
        /// <summary>
        /// 密码输入框
        /// </summary>
        [Description( "password" )]
        Password,
        /// <summary>
        /// 数字输入框
        /// </summary>
        [Description( "number" )]
        Number,
        /// <summary>
        /// 电子邮件输入框
        /// </summary>
        [Description( "email" )]
        Email
    }
}
