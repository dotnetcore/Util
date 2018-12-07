using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// Sql查询条件
    /// </summary>
    public class SqlCondition : ICondition {
        /// <summary>
        /// Sql查询条件
        /// </summary>
        private readonly string _condition;

        /// <summary>
        /// 初始化Sql查询条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public SqlCondition( string condition ) {
            _condition = condition;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return _condition;
        }
    }
}
