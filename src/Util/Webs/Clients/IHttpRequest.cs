using System;
using System.Net;
using System.Threading.Tasks;

namespace Util.Webs.Clients {
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
        /// <typeparam name="TResult">返回结果类型</typeparam>
        Task<TResult> ResultFromJsonAsync<TResult>();
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
        Task<TResult> ResultFromJsonAsync();
    }
}
