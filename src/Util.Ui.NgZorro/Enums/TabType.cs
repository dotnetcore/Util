using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 标签类型
    /// </summary>
    public enum TabType {
        /// <summary>
        /// 常规标签
        /// </summary>
        [Description( "line" )]
        Line,
        /// <summary>
        /// 卡片式标签
        /// </summary>
        [Description( "card" )]
        Card,
        /// <summary>
        /// 可关闭的卡片式标签
        /// </summary>
        [Description( "editable-card" )]
        EditableCard
    }
}
