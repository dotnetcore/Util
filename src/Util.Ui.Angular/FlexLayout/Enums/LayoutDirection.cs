using System.ComponentModel;

namespace Util.Ui.FlexLayout.Enums {
    /// <summary>
    /// 布局方向
    /// </summary>
    public enum LayoutDirection {
        /// <summary>
        /// 将内容排成一行，该项为默认值
        /// </summary>
        [Description( "row" )]
        Row,
        /// <summary>
        /// 将内容排成一列
        /// </summary>
        [Description( "column" )]
        Column,
        /// <summary>
        /// 将内容倒着排成一行
        /// </summary>
        [Description( "row-reverse" )]
        RowReverse,
        /// <summary>
        /// 将内容倒着排成一列
        /// </summary>
        [Description( "column-reverse" )]
        ColumnReverse,
    }
}
