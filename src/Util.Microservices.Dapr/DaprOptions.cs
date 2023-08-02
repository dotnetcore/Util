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
    }

    /// <summary>
    /// 机密存储器名称
    /// </summary>
    public string SecretStoreName { get; set; }
    /// <summary>
    /// 服务调用配置
    /// </summary>
    public ServiceInvocationOptions ServiceInvocation { get; set; }
}