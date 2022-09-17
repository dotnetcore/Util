using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 走马灯指示点位置
    /// </summary>
    public enum CarouselDotPosition {
        /// <summary>
        /// 上方
        /// </summary>
        [Description( "top" )]
        Top,
        /// <summary>
        /// 下方
        /// </summary>
        [Description( "bottom" )]
        Bottom,
        /// <summary>
        /// 左方
        /// </summary>
        [Description( "left" )]
        Left,
        /// <summary>
        /// 右方
        /// </summary>
        [Description( "right" )]
        Right
    }
}
