namespace Util.Microservices;

/// <summary>
/// 状态对象基类
/// </summary>
public class StateBase : IDataKey, IDataType, IETag {
    /// <inheritdoc />
    public string Id { get; set; }

    /// <inheritdoc />
    public string DataType { get; set; }

    /// <inheritdoc />
    public string ETag { get; set; }
}