using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// Is Not Null查询条件
    /// </summary>
    public class IsNotNullCondition : ICondition {
        /// <summary>
        /// 列名
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// 初始化Is Not Null查询条件
        /// </summary>
        /// <param name="name">列名</param>
        public IsNotNullCondition( string name ) {
            _name = name;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return string.IsNullOrWhiteSpace( _name ) ? null : $"{_name} Is Not Null";
        }
    }
}