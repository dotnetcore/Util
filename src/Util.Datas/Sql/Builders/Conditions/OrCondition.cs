namespace Util.Datas.Sql.Builders.Conditions {
    /// <summary>
    /// Or连接条件
    /// </summary>
    public class OrCondition : ICondition {
        /// <summary>
        /// 左操作数
        /// </summary>
        private readonly string _left;
        /// <summary>
        /// 右操作数
        /// </summary>
        private readonly string _right;

        /// <summary>
        /// 初始化Or连接条件
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        public OrCondition( string left, string right ) {
            _left = left;
            _right = right;
        }

        /// <summary>
        /// 初始化Or连接条件
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        public OrCondition( ICondition left, ICondition right ) {
            _left = left?.GetCondition();
            _right = right?.GetCondition();
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            if( string.IsNullOrWhiteSpace( _left ) )
                return _right;
            if( string.IsNullOrWhiteSpace( _right ) )
                return _left;
            return $"({_left} Or {_right})";
        }
    }
}