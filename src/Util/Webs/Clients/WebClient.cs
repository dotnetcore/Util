using System.Net.Http;
using System.Threading.Tasks;

namespace Util.Webs.Clients {
    /// <summary>
    /// Web客户端
    /// </summary>
    public class WebClient {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest Get( string url ) {
            return new HttpRequest( HttpMethod.Get, url );
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest Post( string url ) {
            return new HttpRequest( HttpMethod.Post, url );
        }

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest Put( string url ) {
            return new HttpRequest( HttpMethod.Put, url );
        }

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest Delete( string url ) {
            return new HttpRequest( HttpMethod.Delete, url );
        }

        /// <summary>
        /// 获取流
        /// </summary>
        /// <param name="url">地址</param>
        public async Task<byte[]> GetStreamAsync( string url ) {
            return await new HttpRequest( HttpMethod.Get, url ).GetStreamAsync(  );
        }
    }

    /// <summary>
    /// Web客户端
    /// </summary>
    /// <typeparam name="TResult">返回的结果类型</typeparam>
    public class WebClient<TResult>  where TResult : class  {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest<TResult> Get( string url ) {
            return new HttpRequest<TResult>( HttpMethod.Get, url );
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest<TResult> Post( string url ) {
            return new HttpRequest<TResult>( HttpMethod.Post, url );
        }

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest<TResult> Put( string url ) {
            return new HttpRequest<TResult>( HttpMethod.Put, url );
        }

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="url">地址</param>
        public IHttpRequest<TResult> Delete( string url ) {
            return new HttpRequest<TResult>( HttpMethod.Delete, url );
        }
    }
}