namespace Util.Microservices.Dapr.StateManagements.Queries.Conditions;

/// <summary>
/// 状态对象相等查询条件
/// </summary>
public class EqualCondition : IStateCondition {
    /// <summary>
    /// 初始化状态对象相等查询条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="value">属性值</param>
    public EqualCondition( string property, object value ) {
        if ( property.IsEmpty() )
            return;
        Equal = new Dictionary<string, object> { { property, value } };
    }

    /// <summary>
    /// 相等操作
    /// </summary>
    [JsonPropertyName( "EQ" )]
    public Dictionary<string, object> Equal { get; set; }
}