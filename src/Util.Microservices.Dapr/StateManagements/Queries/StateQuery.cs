namespace Util.Microservices.Dapr.StateManagements.Queries;

/// <summary>
/// 状态查询对象
/// </summary>
public class StateQuery {
    /// <summary>
    /// 过滤条件
    /// </summary>
    [JsonPropertyName( "filter" )]
    public object Filter { get; set; }
    /// <summary>
    /// 排序条件
    /// </summary>
    [JsonPropertyName( "sort" )]
    public StateSort Sort { get; set; }
    /// <summary>
    /// 分页条件
    /// </summary>
    [JsonPropertyName( "page" )]
    public StatePage Page { get; set; }
}