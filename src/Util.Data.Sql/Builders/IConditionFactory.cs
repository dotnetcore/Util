using Util.Data.Queries;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql条件工厂
    /// </summary>
    public interface IConditionFactory {
        /// <summary>
        /// 创建Sql条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">操作</param>
        /// <param name="isParameterization">是否参数化</param>
        ISqlCondition Create( string column, object value, Operator @operator, bool isParameterization = true );
        /// <summary>
        /// 创建Sql范围条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <param name="boundary">包含边界</param>
        /// <param name="isParameterization">是否参数化</param>
        ISqlCondition Create( string column, object minValue,object maxValue, Boundary boundary, bool isParameterization = true );
    }
}
