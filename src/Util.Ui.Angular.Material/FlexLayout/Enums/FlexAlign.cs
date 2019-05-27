using System.ComponentModel;

namespace Util.Ui.FlexLayout.Enums {
    /// <summary>
    /// 对齐方式
    /// </summary>
    public enum FlexAlign {
        /// <summary>
        /// 起始对齐
        /// </summary>
        [Description( "start" )]
        Start,
        /// <summary>
        /// 居中对齐
        /// </summary>
        [Description( "center" )]
        Center,
        /// <summary>
        /// 末尾对齐
        /// </summary>
        [Description( "end" )]
        End,
        /// <summary>
        /// 与基线对齐
        /// </summary>
        [Description( "baseline" )]
        Baseline,
        /// <summary>
        /// 拉伸
        /// </summary>
        [Description( "stretch" )]
        Stretch
    }
}