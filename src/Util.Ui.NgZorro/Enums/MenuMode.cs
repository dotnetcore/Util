using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 菜单模式
    /// </summary>
    public enum MenuMode {
        /// <summary>
        /// 垂直
        /// </summary>
        [Description( "vertical" )]
        Vertical,
        /// <summary>
        /// 水平
        /// </summary>
        [Description( "horizontal" )]
        Horizontal,
        /// <summary>
        /// 内嵌
        /// </summary>
        [Description( "inline" )]
        Inline
    }
}
