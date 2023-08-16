namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 云事件标头处理中间件
/// </summary>
public class CloudEventHeadersMiddleware {
    /// <summary>
    /// 中间件管道
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// 初始化云事件标头处理中间件
    /// </summary>
    /// <param name="next">中间件管道</param>
    public CloudEventHeadersMiddleware( RequestDelegate next ) {
        _next = next;
    }

    /// <summary>
    /// 执行管道
    /// </summary>
    /// <param name="httpContext">Http上下文</param>
    public async Task InvokeAsync( HttpContext httpContext ) {
        if ( _next == null )
            return;
        if ( httpContext == null ) {
            await _next( httpContext );
            return;
        }
        await ImportHeaders( httpContext );
        await _next( httpContext );
    }

    /// <summary>
    /// 导入请求头
    /// </summary>
    protected virtual async Task ImportHeaders( HttpContext httpContext ) {
        if ( httpContext.Request.ContentType != "application/cloudevents+json" )
            return;
        httpContext.Request.EnableBuffering();
        var jsonElement = await JsonSerializer.DeserializeAsync<JsonElement>( httpContext.Request.Body );
        httpContext.Request.Body.Seek( 0, SeekOrigin.Begin );
        if ( jsonElement.TryGetProperty( "headers", out var headers ) == false )
            return;
        var result = headers.Deserialize<Dictionary<string, string>>();
        foreach ( var item in result )
            httpContext.Request.Headers[item.Key] = item.Value;
    }
}