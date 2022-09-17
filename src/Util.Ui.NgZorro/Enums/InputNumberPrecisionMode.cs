using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 数字输入精度模式
    /// </summary>
    public enum InputNumberPrecisionMode {
        /// <summary>
        /// 多余的位数直接截断
        /// </summary>
        [Description( "cut" )]
        Cut,
        /// <summary>
        /// 四舍五入
        /// </summary>
        [Description( "toFixed" )]
        ToFixed
    }
}
