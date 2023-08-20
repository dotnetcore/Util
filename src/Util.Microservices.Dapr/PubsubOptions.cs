namespace Util.Microservices.Dapr; 

/// <summary>
/// 发布订阅配置
/// </summary>
public class PubsubOptions {
    /// <summary>
    /// 初始化发布订阅配置
    /// </summary>
    public PubsubOptions() {
        EventLogStoreName = "statestore";
        ImportHeaderKeys = new List<string> {
            "Authorization",
            "x-correlation-id"
        };
    }

    /// <summary>
    /// 集成事件日志记录状态存储组件名称,默认值: statestore
    /// </summary>
    public string EventLogStoreName { get; set; }

    /// <summary>
    /// 需要导入的请求头键名集合,从当前Http上下文导入
    /// </summary>
    public IList<string> ImportHeaderKeys { get; set; }
}