using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 颜色
    /// </summary>
    public enum Color {
        /// <summary>
        /// 默认
        /// </summary>
        [Description( "default" )]
        Default,
        /// <summary>
        /// 主色，深蓝色
        /// </summary>
        [Description( "primary" )]
        Primary,
        /// <summary>
        /// 虚线
        /// </summary>
        [Description( "dashed" )]
        Dashed,
        /// <summary>
        /// 危险色，红色
        /// </summary>
        [Description( "danger" )]
        Danger
    }
}
