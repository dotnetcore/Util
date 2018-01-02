using System.ComponentModel;

namespace Util.Ui.Material.Enums {
    /// <summary>
    /// 占位提示浮动位置
    /// </summary>
    public enum FloatPlaceholder {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "auto" )]
        Auto,
        /// <summary>
        /// 设置值后消失
        /// </summary>
        [Description( "never" )]
        Never,
        /// <summary>
        /// 始终显示
        /// </summary>
        [Description( "always" )]
        Always
    }
}
