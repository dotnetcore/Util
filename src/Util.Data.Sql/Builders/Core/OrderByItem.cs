using System;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// 排序项
    /// </summary>
    public class OrderByItem {
        /// <summary>
        /// 初始化排序项
        /// </summary>
        /// <param name="order">排序表达式</param>
        public OrderByItem( string order ) {
            Column = order.SafeString().Trim();
            if ( Column.EndsWith( " Asc",StringComparison.OrdinalIgnoreCase ) ) {
                Column = Column.Substring( 0, Column.Length - 3 ).Trim();
                return;
            }
            if( Column.EndsWith( " Desc", StringComparison.OrdinalIgnoreCase ) ) {
                Desc = true;
                Column = Column.Substring( 0, Column.Length - 4 ).Trim();
            }
        }

        /// <summary>
        /// 排序列
        /// </summary>
        public string Column { get; }

        /// <summary>
        /// 是否倒排
        /// </summary>
        public bool Desc { get; }
    }
}
