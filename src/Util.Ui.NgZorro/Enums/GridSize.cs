using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 栅格大小
    /// </summary>
    public enum GridSize {
        /// <summary>
        /// 超窄尺寸
        /// </summary>
        [Description( "xs" )]
        Xs,
        /// <summary>
        /// 窄尺寸
        /// </summary>
        [Description( "sm" )]
        Sm,
        /// <summary>
        /// 中尺寸
        /// </summary>
        [Description( "md" )]
        Md,
        /// <summary>
        /// 宽尺寸
        /// </summary>
        [Description( "lg" )]
        Lg,
        /// <summary>
        /// 超宽尺寸
        /// </summary>
        [Description( "xl" )]
        Xl,
        /// <summary>
        /// 极宽尺寸
        /// </summary>
        [Description( "xxl" )]
        Xxl
    }
}
