using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 日期选择器类型
    /// </summary>
    public enum DatePickerType {
        /// <summary>
        /// 选择日期
        /// </summary>
        [Description( "date" )]
        Date,
        /// <summary>
        /// 选择日期范围
        /// </summary>
        [Description( "range" )]
        Range,
        /// <summary>
        /// 选择年份
        /// </summary>
        [Description( "year" )]
        Year,
        /// <summary>
        /// 选择年和月份
        /// </summary>
        [Description( "month" )]
        Month,
        /// <summary>
        /// 选择一周
        /// </summary>
        [Description( "week" )]
        Week
    }
}