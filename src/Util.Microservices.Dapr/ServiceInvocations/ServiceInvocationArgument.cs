namespace Util.Microservices.Dapr.ServiceInvocations;

/// <summary>
/// 服务调用参数
/// </summary>
/// <param name="AppId">应用标识</param>
/// <param name="MethodName">调用方法名称</param>
/// <param name="HttpMethod">Http方法</param>
/// <param name="RequestData">请求参数</param>
/// <param name="RequestMessage">Http请求消息</param>
/// <param name="ResponseMessage">Http响应消息</param>
/// <param name="Result">响应结果</param>
/// <param name="Exception">异常</param>
/// <param name="Message">消息</param>
public record ServiceInvocationArgument(
    string AppId,
    string MethodName,
    HttpMethod HttpMethod,
    object RequestData,
    HttpRequestMessage RequestMessage,
    HttpResponseMessage ResponseMessage = null,
    object Result = null,
    Exception Exception = null,
    string Message = null
);