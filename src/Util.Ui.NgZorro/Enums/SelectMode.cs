using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 选择模式
    /// </summary>
    public enum SelectMode {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "default" )]
        Default,
        /// <summary>
        /// 多选
        /// </summary>
        [Description( "multiple" )]
        Multiple,
        /// <summary>
        /// 标签
        /// </summary>
        [Description( "tags" )]
        Tags
    }
}
