using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 表单布局
    /// </summary>
    public enum FormLayout {
        /// <summary>
        /// 标签和表单控件水平排列
        /// </summary>
        [Description( "horizontal" )]
        Horizontal,
        /// <summary>
        /// 标签和表单控件上下垂直排列
        /// </summary>
        [Description( "vertical" )]
        Vertical,
        /// <summary>
        /// 表单项水平行内排列
        /// </summary>
        [Description( "inline" )]
        Inline
    }
}
