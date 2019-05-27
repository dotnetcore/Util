using Util.Datas.Queries;

namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// 连接条件
    /// </summary>
    public interface IJoinOn {
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="condition">连接条件</param>
        void On( ICondition condition );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        void On( string column, object value, Operator @operator = Operator.Equal );
    }
}
