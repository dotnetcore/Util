using System;
using System.Collections.Generic;
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
        private IDictionary<string, string> _params;
        /// <summary>
        /// Json参数
        /// </summary>
        private string _json;
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
        /// 初始化Http请求
        /// </summary>
        /// <param name="httpMethod">Http动词</param>
        /// <param name="url">地址</param>
        protected HttpRequestBase( HttpMethod httpMethod, string url ) {
            if( string.IsNullOrWhiteSpace( url ) )
                throw new ArgumentNullException( nameof( url ) );
            _url = url;
            _httpMethod = httpMethod;
            _params = new Dictionary<string, string>();
            _contentType = HttpContentType.FormUrlEncoded.Description();
            _cookieContainer = new CookieContainer();
            _timeout = new TimeSpan( 0, 0, 30 );
            _headers = new Dictionary<string, string>();
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
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
        public TRequest Data( IDictionary<string, string> parameters ) {
            _params = parameters ?? throw new ArgumentNullException( nameof( parameters ) );
            return This();
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public TRequest Data<T>( string key, T value ) {
            if( string.IsNullOrWhiteSpace( key ) )
                throw new ArgumentNullException( nameof( key ) );
            var data = value.SafeString();
            if( string.IsNullOrWhiteSpace( data ) )
                return This();
            _params.Add( key, data );
            return This();
        }

        /// <summary>
        /// 添加Json参数
        /// </summary>
        /// <param name="value">值</param>
        public TRequest JsonData<T>( T value ) {
            ContentType( HttpContentType.Json );
            _json = Util.Helpers.Json.ToJson( value );
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
        /// 获取内容类型
        /// </summary>
        private string GetContentType( HttpResponseMessage response ) {
            return response?.Content?.Headers?.ContentType == null ? string.Empty : response.Content.Headers.ContentType.MediaType;
        }

        /// <summary>
        /// 发送前操作
        /// </summary>
        protected virtual void SendBefore() {
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        private async Task<HttpResponseMessage> SendAsync() {
            HttpClient client = CreateHttpClient();
            return await client.SendAsync( CreateRequestMessage() );
        }

        /// <summary>
        /// 发送后操作
        /// </summary>
        protected virtual void SendAfter( string result, HttpStatusCode statusCode, string contentType ) {
            if( IsSuccess( statusCode ) ) {
                SuccessHandler( result, statusCode, contentType );
                return;
            }
            FailHandler( result, statusCode, contentType );
        }

        /// <summary>
        /// 发送请求是否成功
        /// </summary>
        /// <param name="statusCode">状态码</param>
        protected virtual bool IsSuccess( HttpStatusCode statusCode ) {
            return statusCode.Value() < 400;
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

        /// <summary>
        /// 获取结果
        /// </summary>
        public async Task<string> ResultAsync() {
            SendBefore();
            var response = await SendAsync();
            return await response.Content.ReadAsStringAsync().ContinueWith( ( task, state ) => {
                var result = task.Result;
                SendAfter( result, response.StatusCode, state.SafeString() );
                return result;
            }, GetContentType( response ) );
        }

        /// <summary>
        /// 创建请求客户端
        /// </summary>
        private HttpClient CreateHttpClient() {
            return new HttpClient( new HttpClientHandler { CookieContainer = _cookieContainer,
                ServerCertificateCustomValidationCallback = _serverCertificateCustomValidationCallback } ) { Timeout = _timeout };
        }

        /// <summary>
        /// 创建请求消息
        /// </summary>
        private HttpRequestMessage CreateRequestMessage() {
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
                    return new FormUrlEncodedContent( _params );
                case "application/json":
                    return CreateJsonContent();
            }
            throw new NotImplementedException( "未实现该ContentType" );
        }

        /// <summary>
        /// 创建json内容类型
        /// </summary>
        private HttpContent CreateJsonContent() {
            if( string.IsNullOrWhiteSpace( _json ) )
                _json = Util.Helpers.Json.ToJson( _params );
            return new StringContent( _json, Encoding.UTF8, "application/json" );
        }
    }
}
