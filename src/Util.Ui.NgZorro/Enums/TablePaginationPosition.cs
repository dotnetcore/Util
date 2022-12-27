using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 表格分页位置
    /// </summary>
    public enum TablePaginationPosition {
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
        /// 上方和下方
        /// </summary>
        [Description( "both" )]
        Both
    }
}
