using System.ComponentModel;

namespace Util.Data {
    /// <summary>
    /// 查询操作符
    /// </summary>
    public enum Operator {
        /// <summary>
        /// 等于
        /// </summary>
        [Description( "等于" )]
        Equal,
        /// <summary>
        /// 不等于
        /// </summary>
        [Description( "不等于" )]
        NotEqual,
        /// <summary>
        /// 大于
        /// </summary>
        [Description( "大于" )]
        Greater,
        /// <summary>
        /// 大于等于
        /// </summary>
        [Description( "大于等于" )]
        GreaterEqual,
        /// <summary>
        /// 小于
        /// </summary>
        [Description( "小于" )]
        Less,
        /// <summary>
        /// 小于等于
        /// </summary>
        [Description( "小于等于" )]
        LessEqual,
        /// <summary>
        /// 头匹配
        /// </summary>
        [Description( "头匹配" )]
        Starts,
        /// <summary>
        /// 尾匹配
        /// </summary>
        [Description( "尾匹配" )]
        Ends,
        /// <summary>
        /// 模糊匹配
        /// </summary>
        [Description( "模糊匹配" )]
        Contains,
        /// <summary>
        /// In
        /// </summary>
        [Description( "In" )]
        In,
        /// <summary>
        /// Not In
        /// </summary>
        [Description( "Not In" )]
        NotIn,
    }
}
