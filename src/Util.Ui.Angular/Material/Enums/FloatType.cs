using System.ComponentModel;

namespace Util.Ui.Material.Enums {
    /// <summary>
    /// 占位符浮动类型
    /// </summary>
    public enum FloatType {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "auto" )]
        Auto,
        /// <summary>
        /// 设置文本后隐藏占位符
        /// </summary>
        [Description( "never" )]
        Never,
        /// <summary>
        /// 始终显示浮动占位符
        /// </summary>
        [Description( "always" )]
        Always
    }
}
