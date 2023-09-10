namespace Util.Microservices.Dapr;

/// <summary>
/// 状态管理操作扩展
/// </summary>
public static class StateManagerExtensions {

    #region EqualIfNotEmpty

    /// <summary>
    /// 根据规则添加相等查询条件,如果参数值为空，则忽略该查询条件
    /// </summary>
    /// <param name="source">状态管理操作</param>
    /// <param name="property">属性名</param>
    /// <param name="value">属性值,如果为空，则忽略该查询条件</param>
    public static TStateManager EqualIfNotEmpty<TStateManager>( this TStateManager source, string property, object value ) where TStateManager : IStateManagerBase<TStateManager> {
        source.CheckNull( nameof( source ) );
        return value.SafeString().IsEmpty() ? source : source.Equal( property, value );
    }

    #endregion

    #region InIf

    /// <summary>
    /// 根据规则添加In查询条件
    /// </summary>
    /// <param name="source">状态管理操作</param>
    /// <param name="property">属性名</param>
    /// <param name="values">属性值</param>
    /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
    public static TStateManager InIf<TStateManager>( this TStateManager source, string property, IEnumerable<object> values, bool condition ) where TStateManager : IStateManagerBase<TStateManager> {
        source.CheckNull( nameof( source ) );
        return condition ? source.In( property, values ) : source;
    }

    #endregion
}