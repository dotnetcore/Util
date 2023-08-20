using Util.Microservices.Dapr.StateManagements.Queries.Conditions;

namespace Util.Microservices.Dapr.StateManagements.Queries;

/// <summary>
/// 状态过滤器
/// </summary>
public class StateFilter {
    /// <summary>
    /// 过滤条件
    /// </summary>
    private IStateCondition _condition;

    /// <summary>
    /// 获取过滤条件
    /// </summary>
    public object GetCondition() {
        return _condition;
    }

    /// <summary>
    /// 清理
    /// </summary>
    public StateFilter Clear() {
        _condition = null;
        return this;
    }

    /// <summary>
    /// 相等条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="value">属性值</param>
    public StateFilter Equal( string property, object value ) {
        _condition = _condition.And( new EqualCondition( property, value ) );
        return this;
    }

    /// <summary>
    /// In条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="values">属性值</param>
    public StateFilter In( string property, IEnumerable<object> values ) {
        _condition = _condition.And( new InCondition( property, values ) );
        return this;
    }

    /// <summary>
    /// And连接
    /// </summary>
    /// <param name="condition">查询条件</param>
    public StateFilter And( IStateCondition condition ) {
        _condition = _condition.And( condition );
        return this;
    }

    /// <summary>
    /// Or连接
    /// </summary>
    /// <param name="condition">查询条件</param>
    public StateFilter Or( IStateCondition condition ) {
        _condition = _condition.Or( condition );
        return this;
    }

    /// <summary>
    /// 相等条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="value">属性值</param>
    public StateFilter Equal<T>( Expression<Func<T, object>> expression, object value ) {
        return Equal( StateQueryHelper.GetProperty( expression ), value );
    }

    /// <summary>
    /// In条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="values">属性值</param>
    public StateFilter In<T>( Expression<Func<T, object>> expression, IEnumerable<object> values ) {
        return In( StateQueryHelper.GetProperty( expression ), values );
    }
}