using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Util.Http;

namespace Util.Tests.Infrastructure {
    /// <summary>
    /// 控制器测试基类
    /// </summary>
    public abstract class ControllerTestBase {
        /// <summary>
        /// 测试初始化
        /// </summary>
        protected ControllerTestBase( IHttpClient client, IHttpContextAccessor accessor = null ) {
            Client = client;
            if ( accessor != null )
                Context = accessor.HttpContext;
        }

        /// <summary>
        /// Http客户端
        /// </summary>
        protected IHttpClient Client { get; }

        /// <summary>
        /// Http上下文
        /// </summary>
        protected HttpContext Context { get; }

        /// <summary>
        /// Http Get操作
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="data">参数</param>
        protected async Task<WebApiResult<object>> GetAsync( string url, object data = null ) {
            return await Client.Get<WebApiResult<object>>( url, data ).GetResultAsync();
        }

        /// <summary>
        /// Http Get操作
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="data">参数</param>
        protected async Task<WebApiResult<TResult>> GetAsync<TResult>( string url, object data = null ) {
            return await Client.Get<WebApiResult<TResult>>( url,data ).GetResultAsync();
        }

        /// <summary>
        /// Http Post操作
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="data">参数</param>
        protected async Task<WebApiResult<object>> PostAsync( string url, object data ) {
            return await PostAsync<object>( url, data );
        }

        /// <summary>
        /// Http Post操作
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="data">参数</param>
        protected async Task<WebApiResult<TResult>> PostAsync<TResult>( string url, object data ) {
            return await Client.Post<WebApiResult<TResult>>( url, data ).GetResultAsync();
        }

        /// <summary>
        /// Http Put操作
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="data">参数</param>
        protected async Task<WebApiResult<object>> PutAsync( string url, object data ) {
            return await PutAsync<object>( url, data );
        }

        /// <summary>
        /// Http Put操作
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="data">参数</param>
        protected async Task<WebApiResult<TResult>> PutAsync<TResult>( string url, object data ) {
            return await Client.Put<WebApiResult<TResult>>( url, data ).GetResultAsync();
        }

        /// <summary>
        /// Http Delete操作
        /// </summary>
        /// <param name="url">服务地址</param>
        protected async Task<WebApiResult<object>> DeleteAsync( string url ) {
            return await DeleteAsync<object>( url );
        }

        /// <summary>
        /// Http Delete操作
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="url">服务地址</param>
        protected async Task<WebApiResult<TResult>> DeleteAsync<TResult>( string url ) {
            return await Client.Delete<WebApiResult<TResult>>( url ).GetResultAsync();
        }
    }
}