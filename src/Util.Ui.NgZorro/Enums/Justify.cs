using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 水平排列方式
    /// </summary>
    public enum Justify {
        /// <summary>
        /// 居左排列
        /// </summary>
        [Description( "start" )]
        Start,
        /// <summary>
        /// 居中排列
        /// </summary>
        [Description( "center" )]
        Center,
        /// <summary>
        /// 居右排列
        /// </summary>
        [Description( "end" )]
        End,
        /// <summary>
        /// 等宽排列,每个项两侧的间隔相等
        /// </summary>
        [Description( "space-around" )]
        SpaceAround,
        /// <summary>
        /// 分散排列,两端对齐，项之间的间隔都相等
        /// </summary>
        [Description( "space-between" )]
        SpaceBetween
    }
}
