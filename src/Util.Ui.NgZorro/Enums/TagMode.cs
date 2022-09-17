using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 标签模式
    /// </summary>
    public enum TagMode {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "default" )]
        Default,
        /// <summary>
        /// 可关闭
        /// </summary>
        [Description( "closeable" )]
        Closeable,
        /// <summary>
        /// 可选择
        /// </summary>
        [Description( "checkable" )]
        Checkable
    }
}
