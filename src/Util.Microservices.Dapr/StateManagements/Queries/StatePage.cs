namespace Util.Microservices.Dapr.StateManagements.Queries;

/// <summary>
/// 状态分页
/// </summary>
public class StatePage {
    /// <summary>
    /// 分页大小,相对于PageSize
    /// </summary>
    [JsonPropertyName( "limit" )]
    public int? Limit { get; set; }

    /// <summary>
    /// 迭代令牌
    /// </summary>
    [JsonPropertyName( "token" )]
    public string Token { get; set; }
}