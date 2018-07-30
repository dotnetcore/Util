namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// Sql不相等查询条件
    /// </summary>
    public class NotEqualCondition : ICondition {
        /// <summary>
        /// 列名
        /// </summary>
        private readonly string _column;
        /// <summary>
        /// 参数
        /// </summary>
        private readonly string _parameter;

        /// <summary>
        /// 初始化Sql不相等查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="parameter">参数</param>
        public NotEqualCondition( string column, string parameter ) {
            _column = column;
            _parameter = parameter;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return $"{_column}!={_parameter}";
        }
    }
}