namespace Util.Microservices.Dapr.StateManagements.Queries.Conditions;

/// <summary>
/// 状态对象In查询条件
/// </summary>
public class InCondition : IStateCondition {
    /// <summary>
    /// 初始化状态对象In查询条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="values">属性值</param>
    public InCondition( string property, IEnumerable<object> values ) {
        if ( property.IsEmpty() )
            return;
        In = new Dictionary<string, IEnumerable<object>> { { property, values } };
    }

    /// <summary>
    /// In操作
    /// </summary>
    [JsonPropertyName( "IN" )]
    public Dictionary<string, IEnumerable<object>> In { get; set; }
}