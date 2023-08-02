namespace Util.Microservices; 

/// <summary>
/// WebApi服务调用请求上下文
/// </summary>
public class RequestContext {
    /// <summary>
    /// 初始化WebApi服务调用请求上下文
    /// </summary>
    /// <param name="requestMessage">请求消息</param>
    /// <param name="context">Http上下文</param>
    public RequestContext( HttpRequestMessage requestMessage, HttpContext context ) {
        RequestMessage = requestMessage;
        HttpContext = context;
    }

    /// <summary>
    /// 请求消息
    /// </summary>
    public HttpRequestMessage RequestMessage { get; }

    /// <summary>
    /// Http上下文
    /// </summary>
    public HttpContext HttpContext { get; }
}