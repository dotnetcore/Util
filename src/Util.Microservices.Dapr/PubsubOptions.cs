namespace Util.Microservices.Dapr; 

/// <summary>
/// 发布订阅配置
/// </summary>
public class PubsubOptions {
    /// <summary>
    /// 初始化发布订阅配置
    /// </summary>
    public PubsubOptions() {
        EventLogStoreName = "event-state-store";
        ImportHeaderKeys = new List<string> {
            "Authorization",
            "x-correlation-id"
        };
        EnableEventLog = true;
        MaxRetry = 3;
    }

    /// <summary>
    /// 是否启用集成事件日志记录,默认值: true
    /// </summary>
    public bool EnableEventLog { get; set; }

    /// <summary>
    /// 集成事件日志记录状态存储组件名称,默认值: event-state-store
    /// </summary>
    public string EventLogStoreName { get; set; }

    /// <summary>
    /// 需要导入的请求头键名集合,从当前Http上下文导入
    /// </summary>
    public IList<string> ImportHeaderKeys { get; set; }

    /// <summary>
    /// 最大订阅失败重试次数,默认值: 3
    /// </summary>
    public int MaxRetry { get; set; }
}