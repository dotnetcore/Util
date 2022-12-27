using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 徽标状态
    /// </summary>
    public enum BadgeStatus {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "default" )]
        Default,
        /// <summary>
        /// 成功
        /// </summary>
        [Description( "success" )]
        Success,
        /// <summary>
        /// 处理中
        /// </summary>
        [Description( "processing" )]
        Processing,
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
