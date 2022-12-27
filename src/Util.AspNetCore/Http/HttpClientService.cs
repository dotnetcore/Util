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
            return Get<string>( url );
        }

        /// <inheritdoc />
        public IHttpRequest<string> Get( string url, object queryString ) {
            return Get<string>( url, queryString );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Get<TResult>( string url ) where TResult : class {
            return Get<TResult>( url, null );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Get<TResult>( string url, object queryString ) where TResult : class {
            var result = new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Get, url );
            if ( queryString.SafeString().IsEmpty() )
                return result;
            return result.QueryString( queryString );
        }

        #endregion

        #region Post

        /// <inheritdoc />
        public IHttpRequest<string> Post( string url ) {
            return Post<string>( url );
        }

        /// <inheritdoc />
        public IHttpRequest<string> Post( string url, object content ) {
            return Post<string>( url, content );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Post<TResult>( string url ) where TResult : class {
            return Post<TResult>( url, null );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Post<TResult>( string url, object content ) where TResult : class {
            var result = new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Post, url );
            if ( content == null )
                return result;
            return result.Content( content );
        }

        #endregion

        #region Put

        /// <inheritdoc />
        public IHttpRequest<string> Put( string url ) {
            return Put<string>( url );
        }

        /// <inheritdoc />
        public IHttpRequest<string> Put( string url, object content ) {
            return Put<string>( url, content );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Put<TResult>( string url ) where TResult : class {
            return Put<TResult>( url,null );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Put<TResult>( string url, object content ) where TResult : class {
            var result = new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Put, url );
            if ( content == null )
                return result;
            return result.Content( content );
        }

        #endregion

        #region Delete

        /// <inheritdoc />
        public IHttpRequest<string> Delete( string url ) {
            return Delete<string>( url );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Delete<TResult>( string url ) where TResult : class {
            return new HttpRequest<TResult>( _httpClientFactory, _httpClient, HttpMethod.Delete, url );
        }

        #endregion
    }
}
