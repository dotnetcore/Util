using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 进度条类型
    /// </summary>
    public enum ProgressType {
        /// <summary>
        /// 进度条
        /// </summary>
        [Description( "line" )]
        Line,
        /// <summary>
        /// 进度圈
        /// </summary>
        [Description( "circle" )]
        Circle,
        /// <summary>
        /// 仪表盘
        /// </summary>
        [Description( "dashboard" )]
        Dashboard
    }
}
