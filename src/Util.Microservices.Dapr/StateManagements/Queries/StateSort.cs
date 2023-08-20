namespace Util.Microservices.Dapr.StateManagements.Queries;

/// <summary>
/// 状态排序
/// </summary>
public class StateSort : List<OrderByItem> {
    /// <summary>
    /// 添加升序排序属性
    /// </summary>
    /// <param name="property">升序排序属性</param>
    public void OrderBy( string property ) {
        Add( property );
    }

    /// <summary>
    /// 添加降序排序属性
    /// </summary>
    /// <param name="property">降序排序属性</param>
    public void OrderByDescending( string property ) {
        Add( $"{property} DESC" );
    }

    /// <summary>
    /// 添加排序条件
    /// </summary>
    /// <param name="orderBy">排序条件</param>
    public void Add( string orderBy ) {
        if ( orderBy.IsEmpty() )
            return;
        var items = orderBy.Split( "," );
        foreach ( var item in items ) {
            Add( new OrderByItem( item ) );
        }
    }

    /// <summary>
    /// 添加升序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    public void OrderBy<T>( Expression<Func<T, object>> expression ) {
        OrderBy( StateQueryHelper.GetProperty( expression ) );
    }

    /// <summary>
    /// 添加降序排序属性
    /// </summary>
    /// <param name="expression">属性表达式</param>
    public void OrderByDescending<T>( Expression<Func<T, object>> expression ) {
        OrderByDescending( StateQueryHelper.GetProperty( expression ) );
    }
}