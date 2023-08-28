namespace Util.Microservices.Dapr; 

/// <summary>
/// Dapr配置
/// </summary>
public class DaprOptions {
    /// <summary>
    /// 初始化Dapr配置
    /// </summary>
    public DaprOptions() {
        ServiceInvocation = new ServiceInvocationOptions();
        Pubsub = new PubsubOptions();
    }

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; set; }
    /// <summary>
    /// 机密存储器名称
    /// </summary>
    public string SecretStoreName { get; set; }
    /// <summary>
    /// 服务调用配置
    /// </summary>
    public ServiceInvocationOptions ServiceInvocation { get; set; }
    /// <summary>
    /// 发布订阅配置
    /// </summary>
    public PubsubOptions Pubsub { get; set; }
}