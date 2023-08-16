namespace Util.Microservices.Dapr; 

/// <summary>
/// Dapr发布订阅结果
/// </summary>
public class PubsubResult : JsonResult {
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; }

    /// <summary>
    /// 初始化发布订阅结果
    /// </summary>
    /// <param name="status">状态</param>
    public PubsubResult( string status ) : base( null ) {
        Status = status;
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
    public static PubsubResult Success() {
        return new PubsubResult( "SUCCESS" );
    }

    /// <summary>
    /// 重试
    /// </summary>
    public static PubsubResult Retry() {
        return new PubsubResult( "RETRY" );
    }

    /// <summary>
    /// 写警告日志删除消息
    /// </summary>
    public static PubsubResult Drop() {
        return new PubsubResult( "DROP" );
    }

    /// <summary>
    /// 失败并重试
    /// </summary>
    public static PubsubResult Fail() {
        return new PubsubResult( "Others" );
    }
}