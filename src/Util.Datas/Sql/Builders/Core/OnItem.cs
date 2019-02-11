using Util.Datas.Queries;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 连接条件项
    /// </summary>
    public class OnItem {
        /// <summary>
        /// 初始化连接条件项
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public OnItem( string left,string right, Operator @operator ) {
            Left = new SqlItem( left );
            Right = new SqlItem( right );
            Operator = @operator;
        }

        /// <summary>
        /// 初始化连接条件项
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public OnItem( SqlItem left, SqlItem right, Operator @operator ) {
            Left = left;
            Right = right;
            Operator = @operator;
        }

        /// <summary>
        /// 左表列名
        /// </summary>
        public SqlItem Left { get; }

        /// <summary>
        /// 右表列名
        /// </summary>
        public SqlItem Right { get; }

        /// <summary>
        /// 条件运算符
        /// </summary>
        public Operator Operator { get; }
    }
}
