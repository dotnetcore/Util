using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 表头单元格对齐方式
    /// </summary>
    public enum TableHeadColumnAlign {
        /// <summary>
        /// 左对齐
        /// </summary>
        [Description( "left" )]
        Left,
        /// <summary>
        /// 右对齐
        /// </summary>
        [Description( "right" )]
        Right,
        /// <summary>
        /// 居中对齐
        /// </summary>
        [Description( "center" )]
        Center
    }
}
