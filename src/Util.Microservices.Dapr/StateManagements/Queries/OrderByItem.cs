namespace Util.Microservices.Dapr.StateManagements.Queries; 

/// <summary>
/// 排序项
/// </summary>
public class OrderByItem {
    /// <summary>
    /// 初始化排序项
    /// </summary>
    /// <param name="order">排序表达式</param>
    public OrderByItem( string order ) {
        Key = order.SafeString().Trim();
        if ( Key.EndsWith( " Asc", StringComparison.OrdinalIgnoreCase ) ) {
            Key = Key.Substring( 0, Key.Length - 3 ).Trim();
            return;
        }
        if ( Key.EndsWith( " Desc", StringComparison.OrdinalIgnoreCase ) ) {
            Order = "DESC";
            Key = Key.Substring( 0, Key.Length - 4 ).Trim();
        }
    }

    /// <summary>
    /// 排序属性
    /// </summary>
    [JsonPropertyName( "key" )]
    public string Key { get; }

    /// <summary>
    /// 排序方向,可选值: ASC,DESC
    /// </summary>
    [JsonPropertyName( "order" )]
    public string Order { get; }
}