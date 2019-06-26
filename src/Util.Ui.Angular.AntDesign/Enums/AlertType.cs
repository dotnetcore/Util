using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 警告提示样式
    /// </summary>
    public enum AlertType {
        /// <summary>
        /// 成功
        /// </summary>
        [Description( "success" )]
        Success,
        /// <summary>
        /// 信息
        /// </summary>
        [Description( "info" )]
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        [Description( "warning" )]
        Warning,
        /// <summary>
        /// 错误
        /// </summary>
        [Description( "error" )]
        Error
    }
}
