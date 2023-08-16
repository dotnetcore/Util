namespace Util.Microservices.Dapr.Events; 

/// <summary>
/// 云事件消息
/// </summary>
/// <typeparam name="TData">内容数据类型</typeparam>
public class CloudEvent<TData> : CloudEvent {
    /// <summary>
    /// 初始化云事件消息
    /// </summary>
    /// <param name="id">事件标识</param>
    /// <param name="data">事件数据</param>
    public CloudEvent( string id, TData data ) {
        Id = id.IsEmpty() ? Guid.NewGuid().ToString() : id;
        Data = data;
        Headers = new Dictionary<string, string>();
        DataContentType = "application/cloudevents+json";
    }

    /// <summary>
    /// 事件标识
    /// </summary>
    [JsonPropertyName( "id" )]
    public string Id { get; }

    /// <summary>
    /// 事件数据
    /// </summary>
    [JsonPropertyName( "data" )]
    public TData Data { get; }

    /// <summary>
    /// 事件标头
    /// </summary>
    [JsonPropertyName( "headers" )]
    public Dictionary<string, string> Headers { get; init; }

    /// <summary>
    /// 事件数据内容类型
    /// </summary>
    [JsonPropertyName( "datacontenttype" )]
    public string DataContentType { get; init; }
}