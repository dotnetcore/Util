using Util.Microservices.Dapr.ServiceInvocations;

namespace Util.Microservices.Dapr;

/// <summary>
/// 服务调用配置
/// </summary>
public class ServiceInvocationOptions {
    /// <summary>
    /// 初始化服务调用配置
    /// </summary>
    public ServiceInvocationOptions() {
        RequestFilters = new List<IRequestFilter>();
        ResponseFilters = new List<IResponseFilter>();
        ImportHeaderKeys = new List<string> {
            "Authorization",
            "x-correlation-id",
            "Content-Language"
        };
        IsUnpackResult = true;
    }

    /// <summary>
    /// 是否使用ServiceResult对结果解包
    /// </summary>
    public bool IsUnpackResult { get; set; }
    /// <summary>
    /// 服务状态码转换事件,参数为业务状态码或Http状态码,取决于是否使用约定结果类型
    /// </summary>
    public Func<string, ServiceState> OnState { get; set; }
    /// <summary>
    /// 调用前事件
    /// </summary>
    public Func<ServiceInvocationArgument, Task> OnBefore { get; set; }
    /// <summary>
    /// 调用成功事件
    /// </summary>
    public Func<ServiceInvocationArgument, Task> OnSuccess { get; set; }
    /// <summary>
    /// 调用失败事件
    /// </summary>
    public Func<ServiceInvocationArgument, Task> OnFail { get; set; }
    /// <summary>
    /// 调用未授权事件
    /// </summary>
    public Func<ServiceInvocationArgument, Task> OnUnauthorized { get; set; }
    /// <summary>
    /// 调用完成事件
    /// </summary>
    public Func<ServiceInvocationArgument, Task> OnComplete { get; set; }
    /// <summary>
    /// 请求过滤器集合
    /// </summary>
    public IList<IRequestFilter> RequestFilters { get; set; }
    /// <summary>
    /// 响应过滤器集合
    /// </summary>
    public IList<IResponseFilter> ResponseFilters { get; set; }
    /// <summary>
    /// 需要导入的请求头键名集合,从当前Http上下文导入
    /// </summary>
    public IList<string> ImportHeaderKeys { get; set; }
}