using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 抽屉方向
    /// </summary>
    public enum DrawerPlacement {
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
