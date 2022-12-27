using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 走马灯动画效果
    /// </summary>
    public enum CarouselEffect {
        /// <summary>
        /// X轴滚动
        /// </summary>
        [Description( "scrollx" )]
        ScrollX,
        /// <summary>
        /// 渐显
        /// </summary>
        [Description( "fade" )]
        Fade
    }
}
