using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 滑动输入条提示可见性
    /// </summary>
    public enum SliderTooltipVisible {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "default" )]
        Default,
        /// <summary>
        /// 总是可见
        /// </summary>
        [Description( "always" )]
        Always,
        /// <summary>
        /// 不可见
        /// </summary>
        [Description( "never" )]
        Never
    }
}
