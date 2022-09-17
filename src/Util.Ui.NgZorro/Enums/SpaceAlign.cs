using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 间距对齐方式
    /// </summary>
    public enum SpaceAlign {
        /// <summary>
        /// 顶部对齐
        /// </summary>
        [Description( "start" )]
        Start,
        /// <summary>
        /// 底部对齐
        /// </summary>
        [Description( "end" )]
        End,
        /// <summary>
        /// 居中对齐
        /// </summary>
        [Description( "center" )]
        Center,
        /// <summary>
        /// 居中对齐
        /// </summary>
        [Description( "baseline" )]
        Baseline
    }
}
