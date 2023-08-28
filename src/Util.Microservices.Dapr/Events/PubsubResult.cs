namespace Util.Microservices.Dapr.Events;

/// <summary>
/// Dapr发布订阅结果
/// </summary>
public class PubsubResult : JsonResult {
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; }

    /// <summary>
    /// 消息
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// 初始化发布订阅结果
    /// </summary>
    /// <param name="status">状态</param>
    /// <param name="message">消息</param>
    public PubsubResult( string status, string message = null ) : base( null ) {
        Status = status;
        Message = message;
        SerializerSettings = GetOptions();
    }

    /// <summary>
    /// 获取Json序列化配置
    /// </summary>
    private JsonSerializerOptions GetOptions() {
        return new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    /// <summary>
    /// 执行结果
    /// </summary>
    public override Task ExecuteResultAsync( ActionContext context ) {
        Value = new { Status };
        return base.ExecuteResultAsync( context );
    }

    /// <summary>
    /// 成功
    /// </summary>
    public static readonly PubsubResult Success = new( "SUCCESS" );

    /// <summary>
    /// 失败并重试
    /// </summary>
    /// <param name="message">错误消息</param>
    public static PubsubResult Fail( string message ) {
        return new PubsubResult( "RETRY", message );
    }

    /// <summary>
    /// 失败并删除消息
    /// </summary>
    /// <param name="message">错误消息</param>
    public static PubsubResult Drop( string message ) {
        return new PubsubResult( "DROP", message );
    }
}