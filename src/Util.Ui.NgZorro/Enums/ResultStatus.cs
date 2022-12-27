using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 警告提示类型
    /// </summary>
    public enum ResultStatus {
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
        Error,
        /// <summary>
        /// 403
        /// </summary>
        [Description( "403" )]
        StatusCode403,
        /// <summary>
        /// 404
        /// </summary>
        [Description( "404" )]
        StatusCode404,
        /// <summary>
        /// 500
        /// </summary>
        [Description( "500" )]
        StatusCode500
    }
}
