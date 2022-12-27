using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 校验状态
    /// </summary>
    public enum ValidateStatus {
        /// <summary>
        /// 成功
        /// </summary>
        [Description( "success" )]
        Success,
        /// <summary>
        /// 警告
        /// </summary>
        [Description( "warning" )]
        Warning,
        /// <summary>
        /// 错误
        /// </summary>
        [Description( "error" )]
        Error,
        /// <summary>
        /// 校验中
        /// </summary>
        [Description( "validating" )]
        Validating
    }
}
