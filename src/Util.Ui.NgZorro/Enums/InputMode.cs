using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 输入模式
    /// </summary>
    public enum InputMode {
        /// <summary>
        /// 无虚拟键盘,在需要实现自己的键盘输入控件时很有用
        /// </summary>
        [Description( "none" )]
        None,
        /// <summary>
        /// 使用用户本地区域设置的标准文本输入键盘
        /// </summary>
        [Description( "text" )]
        Text,
        /// <summary>
        /// 小数输入键盘，包含数字和分隔符,通常是“ . ”或者“ , ”。
        /// </summary>
        [Description( "decimal" )]
        Decimal,
        /// <summary>
        /// 数字输入键盘，0到9的数字
        /// </summary>
        [Description( "numeric" )]
        Numeric,
        /// <summary>
        /// 电话输入键盘，包含0到9的数字、星号（*）和井号（#）键
        /// </summary>
        [Description( "tel" )]
        Tel,
        /// <summary>
        /// 为搜索输入优化的虚拟键盘，比如，返回键可能被重新标记为“搜索”
        /// </summary>
        [Description( "search" )]
        Search,
        /// <summary>
        /// 为邮件地址输入优化的虚拟键盘，通常包含"@"符号和其他优化
        /// </summary>
        [Description( "email" )]
        Email,
        /// <summary>
        /// 为网址输入优化的虚拟键盘，比如，“/”键会更加明显、历史记录访问
        /// </summary>
        [Description( "url" )]
        Url,
    }
}
