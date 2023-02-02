using System.ComponentModel;

namespace Util.Ui.NgAlain.Enums {
    /// <summary>
    /// Tinymce工具栏模式
    /// </summary>
    public enum TinymceToolbarMode {
        /// <summary>
        /// 浮动模式,点击工具栏...图标,溢出的工具栏在下方浮动显示
        /// </summary>
        [Description( "floating" )]
        Floating,
        /// <summary>
        /// 滑动模式,点击工具栏...图标,溢出的工具栏滑动到下方显示
        /// </summary>
        [Description( "sliding" )]
        Sliding,
        /// <summary>
        /// 滚动模式,工具栏溢出时出现滚动条
        /// </summary>
        [Description( "scrolling" )]
        Scrolling,
        /// <summary>
        /// 包装模式,溢出的工具栏显示在主工具栏下方的一个或多个工具栏上
        /// </summary>
        [Description( "wrap" )]
        wrap
    }
}
