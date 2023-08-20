namespace Util.Microservices.Dapr.StateManagements.Queries.Conditions; 

/// <summary>
/// And连接条件
/// </summary>
public class AndCondition : IStateCondition {
    /// <summary>
    /// 初始化And连接条件
    /// </summary>
    /// <param name="condition1">条件1</param>
    /// <param name="condition2">条件2</param>
    public AndCondition( IStateCondition condition1, IStateCondition condition2 = null ) {
        if ( condition1 == null && condition2 == null )
            return;
        And = new List<object>();
        AddCondition( condition1 );
        AddCondition( condition2 );
    }

    /// <summary>
    /// And连接条件
    /// </summary>
    [JsonPropertyName( "AND" )]
    public List<object> And { get; set; }

    /// <summary>
    /// 添加条件
    /// </summary>
    /// <param name="condition">条件</param>
    public void AddCondition( IStateCondition condition ) {
        if ( condition == null )
            return;
        if ( condition is AndCondition andCondition ) {
            foreach ( var item in andCondition.And ) {
                And.Add( item );
            }
            return;
        }
        And.Add( condition );
    }
}