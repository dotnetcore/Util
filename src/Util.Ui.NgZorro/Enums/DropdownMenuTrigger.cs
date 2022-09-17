using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 下拉菜单触发方式
    /// </summary>
    public enum DropdownMenuTrigger {
        /// <summary>
        /// 移入触发
        /// </summary>
        [Description( "hover" )]
        Hover,
        /// <summary>
        /// 点击触发
        /// </summary>
        [Description( "click" )]
        Click
    }
}
