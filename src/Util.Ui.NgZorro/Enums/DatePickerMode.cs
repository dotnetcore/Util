using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// 日期选择器模式
    /// </summary>
    public enum DatePickerMode {
        /// <summary>
        /// 选择日期
        /// </summary>
        [Description( "date" )]
        Date,
        /// <summary>
        /// 选择一周
        /// </summary>
        [Description( "week" )]
        Week,
        /// <summary>
        /// 选择年和月份
        /// </summary>
        [Description( "month" )]
        Month,
        /// <summary>
        /// 选择年份
        /// </summary>
        [Description( "year" )]
        Year
    }
}