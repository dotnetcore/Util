using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// AntDesign图标主题风格
    /// </summary>
    public enum AntDesignTheme {
        /// <summary>
        /// 实心主题
        /// </summary>
        [Description( "fill" )]
        Fill,
        /// <summary>
        /// 描线主题
        /// </summary>
        [Description( "outline" )]
        Outline,
        /// <summary>
        /// 双色主题
        /// </summary>
        [Description( "twotone" )]
        TwoTone
    }
}
