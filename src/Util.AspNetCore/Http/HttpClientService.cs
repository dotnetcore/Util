using System.Net.Http;

namespace Util.Http {
    /// <summary>
    /// Http客户端服务
    /// </summary>
    public class HttpClientService : IHttpClient {

        #region 字段

        /// <summary>
        /// Http客户端工厂
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;
        /// <summary>
        /// Http客户端
        /// </summary>
        private HttpClient _httpClient;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Http客户端服务
        /// </summary>
        /// <param name="factory">Http客户端工厂</param>
        public HttpClientService( IHttpClientFactory factory = null ) {
            _httpClientFactory = factory;
        }

        #endregion

        #region SetHttpClient(设置Http客户端)
        /// <summary>
        /// 设置Http客户端
        /// </summary>
        /// <param name="client">Http客户端</param>
        public void SetHttpClient( HttpClient client ) {
            _httpClient = client;
        } 
        #endregion

        #region Get

        /// <inheritdoc />
        public IHttpRequest<string> Get( string url ) {
            return new HttpRequest<string>( _httpClientFactory, _httpClient, HttpMethod.Get, url );
        }

        /// <inheritdoc />
        public IHttpRequest<string> Get( string url, object queryString ) {
            var result = new HttpRequest<string>( _httpClientFactory, _httpClient, HttpMethod.Get, url );
            return result.QueryString( queryString );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Get<TResult>( string url ) where TResult : class {
            return new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Get, url );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Get<TResult>( string url, object queryString ) where TResult : class {
            var result = new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Get, url );
            return result.QueryString( queryString );
        }

        #endregion

        #region Post

        /// <inheritdoc />
        public IHttpRequest<string> Post( string url ) {
            return new HttpRequest<string>( _httpClientFactory, _httpClient, HttpMethod.Post, url );
        }

        /// <inheritdoc />
        public IHttpRequest<string> Post( string url, object content ) {
            var result = new HttpRequest<string>( _httpClientFactory, _httpClient, HttpMethod.Post, url );
            return result.Content( content );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Post<TResult>( string url ) where TResult : class {
            return new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Post, url );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Post<TResult>( string url, object content ) where TResult : class {
            var result = new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Post, url );
            return result.Content( content );
        }

        #endregion

        #region Put

        /// <inheritdoc />
        public IHttpRequest<string> Put( string url ) {
            return new HttpRequest<string>( _httpClientFactory, _httpClient, HttpMethod.Put, url );
        }

        /// <inheritdoc />
        public IHttpRequest<string> Put( string url, object content ) {
            var result = new HttpRequest<string>( _httpClientFactory, _httpClient, HttpMethod.Put, url );
            return result.Content( content );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Put<TResult>( string url ) where TResult : class {
            return new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Put, url );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Put<TResult>( string url, object content ) where TResult : class {
            var result = new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Put, url );
            return result.Content( content );
        }

        #endregion

        #region Delete

        /// <inheritdoc />
        public IHttpRequest<string> Delete( string url ) {
            return new HttpRequest<string>( _httpClientFactory, _httpClient, HttpMethod.Delete, url );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Delete<TResult>( string url ) where TResult : class {
            return new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Delete, url );
        }

        #endregion
    }
}
