using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 文字提示触发行为
    /// </summary>
    public enum TooltipTrigger {
        /// <summary>
        /// 点击触发
        /// </summary>
        [Description( "click" )]
        Click,
        /// <summary>
        /// 获得焦点触发
        /// </summary>
        [Description( "focus" )]
        Focus,
        /// <summary>
        /// 移入触发
        /// </summary>
        [Description( "hover" )]
        Hover
    }
}
