using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 图标旋转类型
    /// </summary>
    public enum RotateType {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "normal" )]
        Default,
        /// <summary>
        /// 顺时针旋转90度
        /// </summary>
        [Description( "fa-rotate-90" )]
        Rotate90,
        /// <summary>
        /// 顺时针旋转180度
        /// </summary>
        [Description( "fa-rotate-180" )]
        Rotate180,
        /// <summary>
        /// 顺时针旋转270度
        /// </summary>
        [Description( "fa-rotate-270" )]
        Rotate270,
        /// <summary>
        /// 水平翻转
        /// </summary>
        [Description( "fa-flip-horizontal" )]
        FlipHorizontal,
        /// <summary>
        /// 垂直翻转
        /// </summary>
        [Description( "fa-flip-vertical" )]
        FlipVertical
    }
}
