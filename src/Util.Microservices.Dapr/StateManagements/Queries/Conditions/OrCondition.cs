namespace Util.Microservices.Dapr.StateManagements.Queries.Conditions; 

/// <summary>
/// Or连接条件
/// </summary>
public class OrCondition : IStateCondition {
    /// <summary>
    /// 初始化Or连接条件
    /// </summary>
    /// <param name="condition1">条件1</param>
    /// <param name="condition2">条件2</param>
    public OrCondition( IStateCondition condition1, IStateCondition condition2 = null ) {
        if ( condition1 == null && condition2 == null )
            return;
        Or = new List<object>();
        AddCondition( condition1 );
        AddCondition( condition2 );
    }

    /// <summary>
    /// Or连接条件
    /// </summary>
    [JsonPropertyName( "OR" )]
    public List<object> Or { get; set; }

    /// <summary>
    /// 添加条件
    /// </summary>
    /// <param name="condition">条件</param>
    public void AddCondition( IStateCondition condition ) {
        if ( condition == null )
            return;
        if ( condition is OrCondition orCondition ) {
            foreach ( var item in orCondition.Or ) {
                Or.Add( item );
            }
            return;
        }
        Or.Add( condition );
    }
}