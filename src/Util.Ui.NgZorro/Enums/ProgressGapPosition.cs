using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 进度条缺口位置
    /// </summary>
    public enum ProgressGapPosition {
        /// <summary>
        /// 上方
        /// </summary>
        [Description( "top" )]
        Top,
        /// <summary>
        /// 左方
        /// </summary>
        [Description( "left" )]
        Left,
        /// <summary>
        /// 右方
        /// </summary>
        [Description( "right" )]
        Right,
        /// <summary>
        /// 下方
        /// </summary>
        [Description( "bottom" )]
        Bottom
    }
}
