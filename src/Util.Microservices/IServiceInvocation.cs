namespace Util.Microservices;

/// <summary>
/// WebApi服务调用
/// </summary>
public interface IServiceInvocation : IServiceInvocationBase<IServiceInvocation>,ITransientDependency {
    /// <summary>
    /// 调用前事件
    /// </summary>
    /// <param name="action">调用前操作,返回false取消调用</param>
    IServiceInvocation OnBefore( Func<HttpRequestMessage, bool> action );
    /// <summary>
    /// 响应结果转换事件
    /// </summary>
    /// <param name="action">响应结果转换操作</param>
    IServiceInvocation OnResult( Func<HttpResponseMessage, JsonSerializerOptions, CancellationToken, Task<object>> action );
    /// <summary>
    /// 调用后事件
    /// </summary>
    /// <param name="action">调用后处理操作</param>
    IServiceInvocation OnAfter( Action<HttpResponseMessage> action );
    /// <summary>
    /// 调用成功事件
    /// </summary>
    /// <typeparam name="TResult">响应结果类型</typeparam>
    /// <param name="action">调用成功处理操作</param>
    IServiceInvocation OnSuccess<TResult>( Func<HttpRequestMessage, HttpResponseMessage, TResult, Task> action );
    /// <summary>
    /// 调用失败事件
    /// </summary>
    /// <param name="action">调用失败处理操作</param>
    IServiceInvocation OnFail( Func<HttpRequestMessage, HttpResponseMessage, Exception, Task> action );
    /// <summary>
    /// 调用未授权事件
    /// </summary>
    /// <param name="action">调用未授权处理操作</param>
    IServiceInvocation OnUnauthorized( Func<HttpRequestMessage, HttpResponseMessage, Task> action );
    /// <summary>
    /// 调用完成事件
    /// </summary>
    /// <param name="action">调用完成处理操作</param>
    IServiceInvocation OnComplete( Func<HttpRequestMessage, HttpResponseMessage, Task> action );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task InvokeAsync( string methodName, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="httpMethod">Http方法</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task InvokeAsync( string methodName, HttpMethod httpMethod, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="data">请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task InvokeAsync( string methodName,object data, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="data">请求参数</param>
    /// <param name="httpMethod">Http方法</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task InvokeAsync( string methodName, object data, HttpMethod httpMethod, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TResponse> InvokeAsync<TResponse>( string methodName, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="httpMethod">Http方法</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TResponse> InvokeAsync<TResponse>( string methodName, HttpMethod httpMethod, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="data">请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TResponse> InvokeAsync<TResponse>( string methodName, object data, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="data">请求参数</param>
    /// <param name="httpMethod">Http方法</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TResponse> InvokeAsync<TResponse>( string methodName, object data, HttpMethod httpMethod, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="data">请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TResponse> InvokeAsync<TRequest,TResponse>( string methodName, TRequest data, CancellationToken cancellationToken = default );
    /// <summary>
    /// 调用服务方法
    /// </summary>
    /// <param name="methodName">服务方法名</param>
    /// <param name="data">请求参数</param>
    /// <param name="httpMethod">Http方法</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TResponse> InvokeAsync<TRequest, TResponse>( string methodName, TRequest data, HttpMethod httpMethod, CancellationToken cancellationToken = default );
}