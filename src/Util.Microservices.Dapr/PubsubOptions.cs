namespace Util.Microservices.Dapr; 

/// <summary>
/// 发布订阅配置
/// </summary>
public class PubsubOptions {
    /// <summary>
    /// 初始化发布订阅配置
    /// </summary>
    public PubsubOptions() {
        ImportHeaderKeys = new List<string> {
            "Authorization",
            "x-correlation-id"
        };
    }

    /// <summary>
    /// 需要导入的请求头键名集合,从当前Http上下文导入
    /// </summary>
    public IList<string> ImportHeaderKeys { get; set; }
}