namespace Util.Microservices;

/// <summary>
/// 状态管理
/// </summary>
public interface IStateManager : IStateManagerBase<IStateManager> {
    /// <summary>
    /// 设置升序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManager OrderBy<T>( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置降序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManager OrderByDescending<T>( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置相等条件
    /// </summary>
    /// <param name="expression">属性表达式</param>
    /// <param name="value">属性值</param>
    IStateManager Equal<T>( Expression<Func<T, object>> expression, object value );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性表达式</param>
    /// <param name="values">属性值</param>
    IStateManager In<T>( Expression<Func<T, object>> expression, IEnumerable<object> values );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性表达式</param>
    /// <param name="values">属性值</param>
    IStateManager In<T>( Expression<Func<T, object>> expression, params object[] values );
}

/// <summary>
/// 状态管理
/// </summary>
public interface IStateManager<T> : IStateManagerBase<IStateManager<T>> {
    /// <summary>
    /// 设置升序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManager<T> OrderBy( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置降序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManager<T> OrderByDescending( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置相等条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="value">属性值</param>
    IStateManager<T> Equal( Expression<Func<T, object>> expression, object value );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="values">属性值</param>
    IStateManager<T> In( Expression<Func<T, object>> expression, IEnumerable<object> values );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="values">属性值</param>
    IStateManager<T> In( Expression<Func<T, object>> expression, params object[] values );
}