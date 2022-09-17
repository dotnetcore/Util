using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 下拉菜单弹出位置
    /// </summary>
    public enum DropdownMenuPlacement {
        /// <summary>
        /// 左下方
        /// </summary>
        [Description( "bottomLeft" )]
        BottomLeft,
        /// <summary>
        /// 中下方
        /// </summary>
        [Description( "bottomCenter" )]
        BottomCenter,
        /// <summary>
        /// 右下方
        /// </summary>
        [Description( "bottomRight" )]
        BottomRight,
        /// <summary>
        /// 左上方
        /// </summary>
        [Description( "topLeft" )]
        TopLeft,
        /// <summary>
        /// 中上方
        /// </summary>
        [Description( "topCenter" )]
        TopCenter,
        /// <summary>
        /// 右上方
        /// </summary>
        [Description( "topRight" )]
        TopRight
    }
}
