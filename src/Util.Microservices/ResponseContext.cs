namespace Util.Microservices;

/// <summary>
/// WebApi服务调用响应上下文
/// </summary>
public class ResponseContext {
    /// <summary>
    /// 初始化WebApi服务调用响应上下文
    /// </summary>
    /// <param name="responseMessage">响应消息</param>
    /// <param name="context">Http上下文</param>
    public ResponseContext( HttpResponseMessage responseMessage, HttpContext context ) {
        ResponseMessage = responseMessage;
        HttpContext = context;
    }

    /// <summary>
    /// 响应消息
    /// </summary>
    public HttpResponseMessage ResponseMessage { get; }

    /// <summary>
    /// Http上下文
    /// </summary>
    public HttpContext HttpContext { get; }
}