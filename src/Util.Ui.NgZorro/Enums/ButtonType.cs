using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 按钮类型
    /// </summary>
    public enum ButtonType {
        /// <summary>
        /// 默认按钮
        /// </summary>
        [Description( "default" )]
        Default,
        /// <summary>
        /// 主按钮，深蓝色,在同一个操作区域最多出现一次
        /// </summary>
        [Description( "primary" )]
        Primary,
        /// <summary>
        /// 虚线按钮
        /// </summary>
        [Description( "dashed" )]
        Dashed,
        /// <summary>
        /// 文本按钮
        /// </summary>
        [Description( "text" )]
        Text,
        /// <summary>
        /// 链接按钮
        /// </summary>
        [Description( "link" )]
        Link
    }
}
