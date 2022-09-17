using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 文本类型
    /// </summary>
    public enum TextType {
        /// <summary>
        /// 次要
        /// </summary>
        [Description( "secondary" )]
        Secondary,
        /// <summary>
        /// 警告
        /// </summary>
        [Description( "warning" )]
        Warning,
        /// <summary>
        /// 危险
        /// </summary>
        [Description( "danger" )]
        Danger,
        /// <summary>
        /// 成功
        /// </summary>
        [Description( "success" )]
        Success
    }
}
