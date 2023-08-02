namespace Util.Microservices;

/// <summary>
/// 服务调用
/// </summary>
/// <typeparam name="TServiceInvocation">服务调用接口类型</typeparam>
public interface IServiceInvocationBase<out TServiceInvocation> where TServiceInvocation : IServiceInvocationBase<TServiceInvocation> {
    /// <summary>
    /// 设置应用标识,即服务名
    /// </summary>
    /// <param name="appId">应用标识,即服务名</param>
    TServiceInvocation Service( string appId );
    /// <summary>
    /// 设置或取消对约定结果进行解包处理,默认为true
    /// </summary>
    /// <param name="isUnpack">是否对结果进行解包处理</param>
    TServiceInvocation UnpackResult( bool isUnpack );
    /// <summary>
    /// 设置访问令牌
    /// </summary>
    /// <param name="token">访问令牌</param>
    TServiceInvocation BearerToken( string token );
    /// <summary>
    /// 设置请求头
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    TServiceInvocation Header( string key, string value );
    /// <summary>
    /// 设置请求头
    /// </summary>
    /// <param name="headers">请求头键值对集合</param>
    TServiceInvocation Header( IDictionary<string, string> headers );
    /// <summary>
    /// 从当前HttpContext导入请求头
    /// </summary>
    /// <param name="key">请求头键名</param>
    TServiceInvocation ImportHeader( string key );
    /// <summary>
    /// 从当前HttpContext导入请求头
    /// </summary>
    /// <param name="keys">请求头键名集合</param>
    TServiceInvocation ImportHeader( IEnumerable<string> keys );
    /// <summary>
    /// 移除请求头
    /// </summary>
    /// <param name="key">请求头键名</param>
    TServiceInvocation RemoveHeader( string key );
    /// <summary>
    /// 服务状态码转换事件
    /// </summary>
    /// <param name="action">转换为服务状态码,参数为业务状态码或Http状态码,取决于是否使用约定结果类型</param>
    TServiceInvocation OnState( Func<string, ServiceState> action );
}