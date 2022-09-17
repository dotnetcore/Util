using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 进度条状态
    /// </summary>
    public enum ProgressStatus {
        /// <summary>
        /// 成功
        /// </summary>
        [Description( "success" )]
        Success,
        /// <summary>
        /// 异常
        /// </summary>
        [Description( "exception" )]
        Exception,
        /// <summary>
        /// 活动
        /// </summary>
        [Description( "active" )]
        Active,
        /// <summary>
        /// 常规
        /// </summary>
        [Description( "normal" )]
        Normal
    }
}
