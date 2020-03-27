using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Util.Helpers;

namespace Util.Webs.Clients {
    /// <summary>
    /// Http请求
    /// </summary>
    public abstract class HttpRequestBase<TRequest> where TRequest : IRequest<TRequest> {

        #region 字段

        /// <summary>
        /// 地址
        /// </summary>
        private readonly string _url;
        /// <summary>
        /// Http动词
        /// </summary>
        private readonly HttpMethod _httpMethod;
        /// <summary>
        /// 参数集合
        /// </summary>
        private IDictionary<string, object> _params;
        /// <summary>
        /// 参数
        /// </summary>
        private string _data;
        /// <summary>
        /// 字符编码
        /// </summary>
        private Encoding _encoding;
        /// <summary>
        /// 内容类型
        /// </summary>
        private string _contentType;
        /// <summary>
        /// Cookie容器
        /// </summary>
        private readonly CookieContainer _cookieContainer;
        /// <summary>
        /// 超时时间
        /// </summary>
        private TimeSpan _timeout;
        /// <summary>
        /// 请求头集合
        /// </summary>
        private readonly Dictionary<string, string> _headers;
        /// <summary>
        /// 执行失败的回调函数
        /// </summary>
        private Action<string> _failAction;
        /// <summary>
        /// 执行失败的回调函数
        /// </summary>
        private Action<string, HttpStatusCode> _failStatusCodeAction;
        /// <summary>
        /// ssl证书验证委托
        /// </summary>
        private Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> _serverCertificateCustomValidationCallback;
        /// <summary>
        /// 令牌
        /// </summary>
        private string _token;
        /// <summary>
        /// 证书路径
        /// </summary>
        private string _certificatePath;
        /// <summary>
        /// 证书密码
        /// </summary>
        private string _certificatePassword;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Http请求
        /// </summary>
        /// <param name="httpMethod">Http动词</param>
        /// <param name="url">地址</param>
        protected HttpRequestBase( HttpMethod httpMethod, string url ) {
            if( string.IsNullOrWhiteSpace( url ) )
                throw new ArgumentNullException( nameof( url ) );
            System.Text.Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
            _url = url;
            _httpMethod = httpMethod;
            _params = new Dictionary<string, object>();
            _contentType = HttpContentType.FormUrlEncoded.Description();
            _cookieContainer = new CookieContainer();
            _timeout = new TimeSpan( 0, 0, 30 );
            _headers = new Dictionary<string, string>();
            _encoding = System.Text.Encoding.UTF8;
        }

        #endregion

        #region 配置

        /// <summary>
        /// 设置字符编码
        /// </summary>
        /// <param name="encoding">字符编码</param>
        public TRequest Encoding( Encoding encoding ) {
            _encoding = encoding;
            return This();
        }

        /// <summary>
        /// 设置字符编码
        /// </summary>
        /// <param name="encoding">字符编码</param>
        public TRequest Encoding( string encoding ) {
            return Encoding( System.Text.Encoding.GetEncoding( encoding ) );
        }

        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        public TRequest ContentType( HttpContentType contentType ) {
            return ContentType( contentType.Description() );
        }

        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        public TRequest ContentType( string contentType ) {
            _contentType = contentType;
            return This();
        }

        /// <summary>
        /// 返回自身
        /// </summary>
        private TRequest This() {
            return (TRequest)(object)this;
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">有效时间，单位：天</param>
        public TRequest Cookie( string name, string value, double expiresDate ) {
            return Cookie( name, value, null, null, DateTime.Now.AddDays( expiresDate ) );
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">到期时间</param>
        public TRequest Cookie( string name, string value, DateTime expiresDate ) {
            return Cookie( name, value, null, null, expiresDate );
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="path">源服务器URL子集</param>
        /// <param name="domain">所属域</param>
        /// <param name="expiresDate">到期时间</param>
        public TRequest Cookie( string name, string value, string path = "/", string domain = null, DateTime? expiresDate = null ) {
            return Cookie( new Cookie( name, value, path, domain ) {
                Expires = expiresDate ?? DateTime.Now.AddYears( 1 )
            } );
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookie">cookie</param>
        public TRequest Cookie( Cookie cookie ) {
            _cookieContainer.Add( new Uri( _url ), cookie );
            return This();
        }

        /// <summary>
        /// 超时时间
        /// </summary>
        /// <param name="timeout">超时时间</param>
        public TRequest Timeout( int timeout ) {
            _timeout = new TimeSpan( 0, 0, timeout );
            return This();
        }

        /// <summary>
        /// 请求头
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public TRequest Header<T>( string key, T value ) {
            _headers.Add( key, value.SafeString() );
            return This();
        }

        /// <summary>
        /// 添加参数字典
        /// </summary>
        /// <param name="parameters">参数字典</param>
        public TRequest Data( IDictionary<string, object> parameters ) {
            _params = parameters ?? throw new ArgumentNullException( nameof( parameters ) );
            return This();
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public TRequest Data( string key, object value ) {
            if( string.IsNullOrWhiteSpace( key ) )
                throw new ArgumentNullException( nameof( key ) );
            if( string.IsNullOrWhiteSpace( value.SafeString() ) )
                return This();
            _params.Add( key, value );
            return This();
        }

        /// <summary>
        /// 添加Json参数
        /// </summary>
        /// <param name="value">值</param>
        public TRequest JsonData<T>( T value ) {
            ContentType( HttpContentType.Json );
            _data = Json.ToJson( value );
            return This();
        }

        /// <summary>
        /// 添加Xml参数
        /// </summary>
        /// <param name="value">值</param>
        public TRequest XmlData( string value ) {
            ContentType( HttpContentType.Xml );
            _data = value;
            return This();
        }

        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,参数为响应结果</param>
        public TRequest OnFail( Action<string> action ) {
            _failAction = action;
            return This();
        }

        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,第一个参数为响应结果，第二个参数为状态码</param>
        public TRequest OnFail( Action<string, HttpStatusCode> action ) {
            _failStatusCodeAction = action;
            return This();
        }
        /// <summary>
        /// 忽略Ssl
        /// </summary>
        public TRequest IgnoreSsl() {
            _serverCertificateCustomValidationCallback = ( a, b, c, d ) => true;
            return This();
        }

        /// <summary>
        /// 设置Bearer令牌
        /// </summary>
        /// <param name="token">令牌</param>
        public TRequest BearerToken( string token ) {
            _token = token;
            return This();
        }

        /// <summary>
        /// 设置证书
        /// </summary>
        /// <param name="path">证书路径</param>
        /// <param name="password">证书密码</param>
        public TRequest Certificate( string path, string password ) {
            _certificatePath = path;
            _certificatePassword = password;
            return This();
        }

        #endregion

        #region ResultAsync(获取结果)

        /// <summary>
        /// 获取结果
        /// </summary>
        public async Task<string> ResultAsync() {
            SendBefore();
            var response = await SendAsync();
            var result = await response.Content.ReadAsStringAsync();
            SendAfter( result, response );
            return result;
        }

        #endregion

        #region SendBefore(发送前操作)

        /// <summary>
        /// 发送前操作
        /// </summary>
        protected virtual void SendBefore() {
        }

        #endregion

        #region SendAsync(发送请求)

        /// <summary>
        /// 发送请求
        /// </summary>
        protected async Task<HttpResponseMessage> SendAsync() {
            var client = CreateHttpClient();
            InitHttpClient( client );
            return await client.SendAsync( CreateRequestMessage() );
        }

        /// <summary>
        /// 创建Http客户端
        /// </summary>
        protected virtual HttpClient CreateHttpClient() {
            return new HttpClient( CreateHttpClientHandler() ) { Timeout = _timeout };
        }

        /// <summary>
        /// 创建Http客户端处理器
        /// </summary>
        protected HttpClientHandler CreateHttpClientHandler() {
            var handler = new HttpClientHandler {
                CookieContainer = _cookieContainer,
                ServerCertificateCustomValidationCallback = _serverCertificateCustomValidationCallback
            };
            if ( string.IsNullOrWhiteSpace( _certificatePath ) )
                return handler;
            var certificate = new X509Certificate2( _certificatePath, _certificatePassword, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet );
            handler.ClientCertificates.Add( certificate );
            return handler;
        }

        /// <summary>
        /// 初始化Http客户端
        /// </summary>
        /// <param name="client">Http客户端</param>
        protected virtual void InitHttpClient( HttpClient client ) {
            InitToken();
            if ( string.IsNullOrWhiteSpace( _token ) )
                return;
            client.SetBearerToken( _token );
        }

        /// <summary>
        /// 初始化访问令牌
        /// </summary>
        protected virtual void InitToken() {
            if( string.IsNullOrWhiteSpace( _token ) == false )
                return;
            _token = Web.AccessToken;
        }

        /// <summary>
        /// 创建请求消息
        /// </summary>
        protected virtual HttpRequestMessage CreateRequestMessage() {
            var message = new HttpRequestMessage {
                Method = _httpMethod,
                RequestUri = new Uri( _url ),
                Content = CreateHttpContent()
            };
            foreach( var header in _headers )
                message.Headers.Add( header.Key, header.Value );
            return message;
        }

        /// <summary>
        /// 创建请求内容
        /// </summary>
        private HttpContent CreateHttpContent() {
            var contentType = _contentType.SafeString().ToLower();
            switch( contentType ) {
                case "application/x-www-form-urlencoded":
                    return new FormUrlEncodedContent( _params.ToDictionary( t => t.Key, t => t.Value.SafeString() ) );
                case "application/json":
                    return CreateJsonContent();
                case "text/xml":
                    return CreateXmlContent();
            }
            throw new NotImplementedException( "未实现该ContentType" );
        }

        /// <summary>
        /// 创建json内容
        /// </summary>
        private HttpContent CreateJsonContent() {
            if( string.IsNullOrWhiteSpace( _data ) )
                _data = Json.ToJson( _params );
            return new StringContent( _data, _encoding, "application/json" );
        }

        /// <summary>
        /// 创建xml内容
        /// </summary>
        private HttpContent CreateXmlContent() {
            return new StringContent( _data, _encoding, "text/xml" );
        }

        #endregion

        #region SendAfter(发送后操作)

        /// <summary>
        /// 发送后操作
        /// </summary>
        protected virtual void SendAfter( string result, HttpResponseMessage response ) {
            var contentType = GetContentType( response );
            if( response.IsSuccessStatusCode ) {
                SuccessHandler( result, response.StatusCode, contentType );
                return;
            }
            FailHandler( result, response.StatusCode, contentType );
        }

        /// <summary>
        /// 获取内容类型
        /// </summary>
        private string GetContentType( HttpResponseMessage response ) {
            return response?.Content?.Headers?.ContentType == null ? string.Empty : response.Content.Headers.ContentType.MediaType;
        }

        /// <summary>
        /// 成功处理操作
        /// </summary>
        protected virtual void SuccessHandler( string result, HttpStatusCode statusCode, string contentType ) {
        }

        /// <summary>
        /// 失败处理操作
        /// </summary>
        protected virtual void FailHandler( string result, HttpStatusCode statusCode, string contentType ) {
            _failAction?.Invoke( result );
            _failStatusCodeAction?.Invoke( result, statusCode );
        }

        #endregion

        #region GetStreamAsync(获取流)

        /// <summary>
        /// 获取流
        /// </summary>
        public async Task<byte[]> GetStreamAsync() {
            using( var client = new HttpClient() ) {
                using( var result = await client.GetAsync( _url ) ) {
                    if( result.IsSuccessStatusCode ) {
                        return await result.Content.ReadAsByteArrayAsync();
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
