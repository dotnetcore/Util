using System.ComponentModel;

namespace Util.Ui.Enums {
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
        /// 等宽排列
        /// </summary>
        [Description( "space-around" )]
        SpaceAround,
        /// <summary>
        /// 分散排列
        /// </summary>
        [Description( "space-between" )]
        SpaceBetween
    }
}
