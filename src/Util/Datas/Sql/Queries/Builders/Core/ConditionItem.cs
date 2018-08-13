using Util.Datas.Queries;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// 查询条件项
    /// </summary>
    public class ConditionItem {
        /// <summary>
        /// 初始化查询条件项
        /// </summary>
        /// <param name="left">左侧列名</param>
        /// <param name="operator">操作符</param>
        /// <param name="right">右侧值或列名</param>
        public ConditionItem( string left, Operator @operator,string right ) {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        /// <summary>
        /// 左侧列名
        /// </summary>
        public string Left { get; private set; }
        /// <summary>
        /// 操作符
        /// </summary>
        public Operator Operator { get; private set; }
        /// <summary>
        /// 右侧值或列名
        /// </summary>
        public string Right { get; private set; }
    }
}
