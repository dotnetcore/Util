using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 进度条端点形状
    /// </summary>
    public enum ProgressStrokeLinecap {
        /// <summary>
        /// 圆角边缘
        /// </summary>
        [Description( "round" )]
        Round,
        /// <summary>
        /// 方角边缘
        /// </summary>
        [Description( "square" )]
        Square
    }
}
