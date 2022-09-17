using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 级联选择展开方式
    /// </summary>
    public enum CascaderExpandTrigger {
        /// <summary>
        /// 点击展开
        /// </summary>
        [Description( "click" )]
        Click,
        /// <summary>
        /// 鼠标悬停展开
        /// </summary>
        [Description( "hover" )]
        Hover
    }
}
