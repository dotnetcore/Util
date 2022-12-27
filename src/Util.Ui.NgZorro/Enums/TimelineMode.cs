using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 时间轴模式
    /// </summary>
    public enum TimelineMode {
        /// <summary>
        /// 左侧显示
        /// </summary>
        [Description( "left" )]
        Left,
        /// <summary>
        /// 右侧显示
        /// </summary>
        [Description( "right" )]
        Right,
        /// <summary>
        /// 交替显示
        /// </summary>
        [Description( "alternate" )]
        Alternate,
        /// <summary>
        /// 自定义显示
        /// </summary>
        [Description( "custom" )]
        Custom
    }
}
