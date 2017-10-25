using System;
using System.Net;
using System.Threading.Tasks;

namespace Util.Webs.Clients {
    /// <summary>
    /// Http请求
    /// </summary>
    public interface IRequest<out TRequest> where TRequest : IRequest<TRequest> {
        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        TRequest ContentType( HttpContentType contentType );
        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        TRequest ContentType( string contentType );
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">有效时间，单位：天</param>
        TRequest Cookie( string name, string value, double expiresDate );
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">到期时间</param>
        TRequest Cookie( string name, string value, DateTime expiresDate );
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="path">源服务器URL子集</param>
        /// <param name="domain">所属域</param>
        /// <param name="expiresDate">到期时间</param>
        TRequest Cookie( string name, string value, string path = "/", string domain = null, DateTime? expiresDate = null );
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookie">cookie</param>
        TRequest Cookie( Cookie cookie );
        /// <summary>
        /// 超时时间
        /// </summary>
        /// <param name="timeout">超时时间,单位：秒</param>
        TRequest Timeout( int timeout );
        /// <summary>
        /// 请求头
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        TRequest Header<T>( string key, T value );
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        TRequest Data<T>( string key, T value );
        /// <summary>
        /// 添加Json参数
        /// </summary>
        /// <param name="value">值</param>
        TRequest JsonData<T>( T value );
        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,参数为响应结果</param>
        TRequest OnFail( Action<string> action );
        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,第一个参数为响应结果，第二个参数为状态码</param>
        TRequest OnFail( Action<string, HttpStatusCode> action );
        /// <summary>
        /// 获取结果
        /// </summary>
        string Result();
        /// <summary>
        /// 获取结果
        /// </summary>
        Task<string> ResultAsync();
    }

    /// <summary>
    /// Http请求
    /// </summary>
    public interface IHttpRequest : IRequest<IHttpRequest> {
        /// <summary>
        /// 请求成功回调函数
        /// </summary>
        /// <param name="action">执行成功的回调函数,参数为响应结果</param>
        IHttpRequest OnSuccess( Action<string> action );
        /// <summary>
        /// 请求成功回调函数
        /// </summary>
        /// <param name="action">执行成功的回调函数,第一个参数为响应结果，第二个参数为状态码</param>
        IHttpRequest OnSuccess( Action<string, HttpStatusCode> action );
        /// <summary>
        /// 获取Json结果
        /// </summary>
        T ResultFromJson<T>();
        /// <summary>
        /// 获取Json结果
        /// </summary>
        Task<T> ResultFromJsonAsync<T>();
    }

    /// <summary>
    /// Http请求
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public interface IHttpRequest<TResult> : IRequest<IHttpRequest<TResult>> where TResult : class {
        /// <summary>
        /// 请求成功回调函数
        /// </summary>
        /// <param name="action">执行成功的回调函数,参数为响应结果</param>
        /// <param name="convertAction">将结果字符串转换为指定类型，当默认转换实现无法转换时使用</param>
        IHttpRequest<TResult> OnSuccess( Action<TResult> action, Func<string, TResult> convertAction = null );
        /// <summary>
        /// 请求成功回调函数
        /// </summary>
        /// <param name="action">执行成功的回调函数,第一个参数为响应结果，第二个参数为状态码</param>
        /// <param name="convertAction">将结果字符串转换为指定类型，当默认转换实现无法转换时使用</param>
        IHttpRequest<TResult> OnSuccess( Action<TResult, HttpStatusCode> action, Func<string, TResult> convertAction = null );
        /// <summary>
        /// 获取Json结果
        /// </summary>
        TResult ResultFromJson();
        /// <summary>
        /// 获取Json结果
        /// </summary>
        Task<TResult> ResultFromJsonAsync();
    }
}
