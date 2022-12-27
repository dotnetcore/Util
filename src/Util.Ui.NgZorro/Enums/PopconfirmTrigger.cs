using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 气泡确认框触发行为
    /// </summary>
    public enum PopconfirmTrigger {
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
