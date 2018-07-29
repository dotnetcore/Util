namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// And连接条件
    /// </summary>
    public class AndCondition : ICondition {
        /// <summary>
        /// 查询条件1
        /// </summary>
        private readonly string _condition1;
        /// <summary>
        /// 查询条件2
        /// </summary>
        private readonly string _condition2;

        /// <summary>
        /// 初始化And连接条件
        /// </summary>
        /// <param name="condition1">查询条件1</param>
        /// <param name="condition2">查询条件2</param>
        public AndCondition( string condition1, string condition2 ) {
            _condition1 = condition1;
            _condition2 = condition2;
        }

        /// <summary>
        /// 初始化And连接条件
        /// </summary>
        /// <param name="condition1">查询条件1</param>
        /// <param name="condition2">查询条件2</param>
        public AndCondition( ICondition condition1, ICondition condition2 ) {
            _condition1 = condition1?.GetCondition();
            _condition2 = condition2?.GetCondition();
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            if ( string.IsNullOrWhiteSpace( _condition1 ) )
                return _condition2;
            if( string.IsNullOrWhiteSpace( _condition2 ) )
                return _condition1;
            return $"{_condition1} And {_condition2}";
        }
    }
}
