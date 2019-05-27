using System.ComponentModel;

namespace Util.Ui.Material.Enums {
    /// <summary>
    /// X轴位置
    /// </summary>
    public enum XPosition {
        /// <summary>
        /// 左边
        /// </summary>
        [Description( "before" )]
        Left,
        /// <summary>
        /// 右边
        /// </summary>
        [Description( "after" )]
        Right
    }

    /// <summary>
    /// Y轴位置
    /// </summary>
    public enum YPosition {
        /// <summary>
        /// 上方
        /// </summary>
        [Description( "above" )]
        Above,
        /// <summary>
        /// 下方
        /// </summary>
        [Description( "below" )]
        Below
    }
}
