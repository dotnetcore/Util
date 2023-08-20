namespace Util.Microservices;

/// <summary>
/// 状态管理
/// </summary>
public interface IStateManage : IStateManageBase<IStateManage> {
    /// <summary>
    /// 设置升序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManage OrderBy<T>( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置降序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManage OrderByDescending<T>( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置相等条件
    /// </summary>
    /// <param name="expression">属性表达式</param>
    /// <param name="value">属性值</param>
    IStateManage Equal<T>( Expression<Func<T, object>> expression, object value );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性表达式</param>
    /// <param name="values">属性值</param>
    IStateManage In<T>( Expression<Func<T, object>> expression, IEnumerable<object> values );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性表达式</param>
    /// <param name="values">属性值</param>
    IStateManage In<T>( Expression<Func<T, object>> expression, params object[] values );
}

/// <summary>
/// 状态管理
/// </summary>
public interface IStateManage<T> : IStateManageBase<IStateManage<T>> {
    /// <summary>
    /// 设置升序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManage<T> OrderBy( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置降序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    IStateManage<T> OrderByDescending( Expression<Func<T, object>> expression );
    /// <summary>
    /// 设置相等条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="value">属性值</param>
    IStateManage<T> Equal( Expression<Func<T, object>> expression, object value );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="values">属性值</param>
    IStateManage<T> In( Expression<Func<T, object>> expression, IEnumerable<object> values );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="expression">属性名表达式</param>
    /// <param name="values">属性值</param>
    IStateManage<T> In( Expression<Func<T, object>> expression, params object[] values );
}