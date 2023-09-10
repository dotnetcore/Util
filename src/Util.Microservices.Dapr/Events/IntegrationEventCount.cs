namespace Util.Microservices.Dapr.Events; 

/// <summary>
/// 集成事件计数
/// </summary>
public class IntegrationEventCount : IDataKey, IETag {
    /// <inheritdoc />
    public string Id { get; set; }

    /// <inheritdoc />
    public string ETag { get; set; }

    /// <summary>
    /// 集成事件总条数
    /// </summary>
    public int? Count { get; set; }
}