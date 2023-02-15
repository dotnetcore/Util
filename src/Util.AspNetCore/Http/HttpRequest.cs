using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Util.Helpers;
using Util.SystemTextJson;

namespace Util.Http {
    /// <summary>
    /// Http请求
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public class HttpRequest<TResult> : IHttpRequest<TResult> where TResult : class {

        #region 字段

        /// <summary>
        /// Http客户端工厂
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;
        /// <summary>
        /// Http客户端
        /// </summary>
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Http方法
        /// </summary>
        private readonly HttpMethod _httpMethod;
        /// <summary>
        /// 服务地址
        /// </summary>
        private readonly string _url;
        /// <summary>
        /// Json序列化配置
        /// </summary>
        private JsonSerializerOptions _jsonSerializerOptions;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Http请求
        /// </summary>
        /// <param name="httpClientFactory">Http客户端工厂</param>
        /// <param name="httpClient">Http客户端工厂</param>
        /// <param name="httpMethod">Http方法</param>
        /// <param name="url">服务地址</param>
        public HttpRequest( IHttpClientFactory httpClientFactory, HttpClient httpClient, HttpMethod httpMethod, string url ) {
            if( httpClientFactory == null && httpClient == null )
                throw new ArgumentNullException( nameof( httpClientFactory ) );
            if( url.IsEmpty() )
                throw new ArgumentNullException( nameof( url ) );
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClient;
            _httpMethod = httpMethod;
            _url = url;
            HeaderParams = new Dictionary<string, string>();
            QueryParams = new Dictionary<string, string>();
            Params = new Dictionary<string, object>();
            HttpContentType = Util.Http.HttpContentType.Json.Description();
            CharacterEncoding = System.Text.Encoding.UTF8;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 证书路径
        /// </summary>
        protected string CertificatePath { get; private set; }
        /// <summary>
        /// 证书密码
        /// </summary>
        protected string CertificatePassword { get; private set; }
        /// <summary>
        /// 内容类型
        /// </summary>
        protected string HttpContentType { get; private set; }
        /// <summary>
        /// 字符编码
        /// </summary>
        protected Encoding CharacterEncoding { get; private set; }
        /// <summary>
        /// 请求头参数集合
        /// </summary>
        protected IDictionary<string, string> HeaderParams { get; }
        /// <summary>
        /// 查询字符串参数集合
        /// </summary>
        protected IDictionary<string, string> QueryParams { get; }
        /// <summary>
        /// 参数集合
        /// </summary>
        protected IDictionary<string, object> Params { get; }
        /// <summary>
        /// 参数
        /// </summary>
        protected object Param { get; private set; }
        /// <summary>
        /// 发送前操作
        /// </summary>
        protected Func<HttpRequestMessage, bool> SendBeforeAction { get; private set; }
        /// <summary>
        /// 发送后操作
        /// </summary>
        protected Func<HttpResponseMessage, Task<TResult>> SendAfterAction { get; private set; }
        /// <summary>
        /// 结果转换操作
        /// </summary>
        protected Func<string, TResult> ConvertAction { get; private set; }
        /// <summary>
        /// 执行成功操作
        /// </summary>
        protected Action<TResult> SuccessAction { get; private set; }
        /// <summary>
        /// 执行失败操作
        /// </summary>
        protected Action<HttpResponseMessage, object> FailAction { get; private set; }
        /// <summary>
        /// 执行完成操作
        /// </summary>
        protected Action<HttpResponseMessage, object> CompleteAction { get; private set; }

        #endregion

        #region ContentType(设置内容类型)

        /// <inheritdoc />
        public IHttpRequest<TResult> ContentType( HttpContentType contentType ) {
            return ContentType( contentType.Description() );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> ContentType( string contentType ) {
            HttpContentType = contentType;
            return this;
        }

        #endregion

        #region Encoding(设置字符编码)

        /// <inheritdoc />
        public IHttpRequest<TResult> Encoding( string encoding ) {
            return Encoding( System.Text.Encoding.GetEncoding( encoding ) );
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Encoding( Encoding encoding ) {
            CharacterEncoding = encoding;
            return this;
        }

        #endregion

        #region Certificate(设置证书)

        /// <inheritdoc />
        public IHttpRequest<TResult> Certificate( string path, string password ) {
            CertificatePath = path;
            CertificatePassword = password;
            return this;
        }

        #endregion

        #region JsonSerializerOptions(设置Json序列化配置)

        /// <inheritdoc />
        public IHttpRequest<TResult> JsonSerializerOptions( JsonSerializerOptions options ) {
            _jsonSerializerOptions = options;
            return this;
        }

        #endregion

        #region Header(设置请求头)

        /// <inheritdoc />
        public IHttpRequest<TResult> Header( string key, string value ) {
            if( key.IsEmpty() )
                return this;
            if( HeaderParams.ContainsKey( key ) )
                HeaderParams.Remove( key );
            HeaderParams.Add( key, value );
            return this;
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Header( IDictionary<string, string> headers ) {
            if( headers == null )
                return this;
            foreach( var header in headers )
                Header( header.Key, header.Value );
            return this;
        }

        #endregion

        #region QueryString(设置查询字符串)

        /// <inheritdoc />
        public IHttpRequest<TResult> QueryString( string key, string value ) {
            if( key.IsEmpty() )
                return this;
            if( QueryParams.ContainsKey( key ) )
                QueryParams.Remove( key );
            QueryParams.Add( key, value );
            return this;
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> QueryString( IDictionary<string, string> queryString ) {
            if( queryString == null )
                return this;
            foreach( var param in queryString )
                QueryString( param.Key, param.Value );
            return this;
        }

        /// <summary>
        /// 设置查询字符串,即url中?后面的参数
        /// </summary>
        /// <param name="queryString">查询字符串对象</param>
        public IHttpRequest<TResult> QueryString( object queryString ) {
            var dic = ToDictionary( queryString );
            foreach( var param in dic )
                QueryString( param.Key, param.Value.ToString() );
            return this;
        }

        #endregion

        #region Content(添加内容参数)

        /// <inheritdoc />
        public IHttpRequest<TResult> Content( string key, object value ) {
            if( key.IsEmpty() )
                return this;
            if( value == null )
                return this;
            if( Params.ContainsKey( key ) )
                Params.Remove( key );
            Params.Add( key, value );
            return this;
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Content( IDictionary<string, object> parameters ) {
            if( parameters == null )
                return this;
            foreach( var param in parameters )
                Content( param.Key, param.Value );
            return this;
        }

        /// <inheritdoc />
        public IHttpRequest<TResult> Content( object value ) {
            Param = value;
            return this;
        }

        #endregion

        #region JsonContent(添加Json参数)

        /// <inheritdoc />
        public IHttpRequest<TResult> JsonContent( object value ) {
            ContentType( Http.HttpContentType.Json );
            return Content( value );
        }

        #endregion

        #region XmlContent(添加Xml参数)

        /// <inheritdoc />
        public IHttpRequest<TResult> XmlContent( string value ) {
            ContentType( Http.HttpContentType.Xml );
            return Content( value );
        }

        #endregion

        #region OnSendBefore(发送前事件)

        /// <inheritdoc />
        public IHttpRequest<TResult> OnSendBefore( Func<HttpRequestMessage, bool> action ) {
            SendBeforeAction = action;
            return this;
        }

        #endregion

        #region OnSendAfter(发送后事件)

        /// <inheritdoc />
        public IHttpRequest<TResult> OnSendAfter( Func<HttpResponseMessage, Task<TResult>> action ) {
            SendAfterAction = action;
            return this;
        }

        #endregion

        #region OnConvert(结果转换事件)

        /// <inheritdoc />
        public IHttpRequest<TResult> OnConvert( Func<string, TResult> action ) {
            ConvertAction = action;
            return this;
        }

        #endregion

        #region OnSuccess(请求成功事件)

        /// <inheritdoc />
        public IHttpRequest<TResult> OnSuccess( Action<TResult> action ) {
            SuccessAction = action;
            return this;
        }

        #endregion

        #region OnFail(请求失败事件)

        /// <inheritdoc />
        public IHttpRequest<TResult> OnFail( Action<HttpResponseMessage, object> action ) {
            FailAction = action;
            return this;
        }

        #endregion

        #region OnComplete(请求完成事件)

        /// <inheritdoc />
        public IHttpRequest<TResult> OnComplete( Action<HttpResponseMessage, object> action ) {
            CompleteAction = action;
            return this;
        }

        #endregion

        #region GetResultAsync(获取结果)

        /// <inheritdoc />
        public async Task<TResult> GetResultAsync() {
            var message = CreateMessage();
            if( SendBefore( message ) == false )
                return default;
            var response = await SendAsync( message );
            return await SendAfterAsync( response );
        }

        #endregion

        #region CreateMessage(创建请求消息)

        /// <summary>
        /// 创建请求消息
        /// </summary>
        protected virtual HttpRequestMessage CreateMessage() {
            var message = new HttpRequestMessage( _httpMethod, GetUrl( _url ) );
            AddHeaders( message );
            message.Content = CreateHttpContent();
            return message;
        }

        /// <summary>
        /// 获取服务地址
        /// </summary>
        /// <param name="url">服务地址</param>
        protected virtual string GetUrl( string url ) {
            return QueryHelpers.AddQueryString( url, QueryParams );
        }

        /// <summary>
        /// 添加请求头
        /// </summary>
        /// <param name="message">请求消息</param>
        protected virtual void AddHeaders( HttpRequestMessage message ) {
            foreach( var header in HeaderParams )
                message.Headers.Add( header.Key, header.Value );
        }

        /// <summary>
        /// 创建请求内容
        /// </summary>
        protected virtual HttpContent CreateHttpContent() {
            var contentType = HttpContentType.SafeString().ToLower();
            switch( contentType ) {
                case "application/x-www-form-urlencoded":
                    return CreateFormContent();
                case "application/json":
                    return CreateJsonContent();
                case "text/xml":
                    return CreateXmlContent();
            }
            return null;
        }

        /// <summary>
        /// 创建表单内容
        /// </summary>
        protected virtual HttpContent CreateFormContent() {
            return new FormUrlEncodedContent( GetParameters().ToDictionary( t => t.Key, t => t.Value.SafeString() ) );
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        protected IDictionary<string, object> GetParameters() {
            var result = new Dictionary<string, object>( Params );
            var dictionary = ToDictionary( Param );
            if( dictionary == null )
                return result;
            foreach( var parameter in dictionary ) {
                if( result.ContainsKey( parameter.Key ) )
                    continue;
                result.Add( parameter.Key, parameter.Value );
            }
            return result;
        }

        /// <summary>
        /// 对象转换为字典
        /// </summary>
        /// <param name="data">对象</param>
        protected IDictionary<string, object> ToDictionary( object data ) {
            var result = Util.Helpers.Convert.ToDictionary( data );
            return result.Where( t => t.Value != null ).ToDictionary( t => t.Key, t => t.Value );
        }

        /// <summary>
        /// 创建json内容
        /// </summary>
        protected virtual HttpContent CreateJsonContent() {
            var content = GetJsonContentValue();
            if( content.IsEmpty() )
                return null;
            return new StringContent( content, CharacterEncoding, "application/json" );
        }

        /// <summary>
        /// 获取json内容值
        /// </summary>
        private string GetJsonContentValue() {
            var options = GetJsonSerializerOptions();
            if( Param != null && Params.Count > 0 )
                return Json.ToJson( GetParameters(), options );
            if( Param != null )
                return Json.ToJson( Param, options );
            if( Params.Count > 0 )
                return Json.ToJson( Params, options );
            return null;
        }

        /// <summary>
        /// 获取Json序列化配置
        /// </summary>
        protected virtual JsonSerializerOptions GetJsonSerializerOptions() {
            if ( _jsonSerializerOptions != null )
                return _jsonSerializerOptions;
            return new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = {
                    new DateTimeJsonConverter(),
                    new NullableDateTimeJsonConverter()
                }
            };
        }

        /// <summary>
        /// 创建xml内容
        /// </summary>
        protected virtual HttpContent CreateXmlContent() {
            return new StringContent( Param.SafeString(), CharacterEncoding, "text/xml" );
        }

        #endregion

        #region SendBefore(发送前操作)

        /// <summary>
        /// 发送前操作
        /// </summary>
        /// <param name="message">请求消息</param>
        protected virtual bool SendBefore( HttpRequestMessage message ) {
            if( SendBeforeAction == null )
                return true;
            return SendBeforeAction( message );
        }

        #endregion

        #region SendAsync(发送请求)

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="message">请求消息</param>
        protected async Task<HttpResponseMessage> SendAsync( HttpRequestMessage message ) {
            var client = GetClient();
            return await client.SendAsync( message );
        }

        #endregion

        #region GetClient(获取Http客户端)

        /// <summary>
        /// 获取Http客户端
        /// </summary>
        protected HttpClient GetClient() {
            if( _httpClient != null )
                return _httpClient;
            var clientHandler = CreateHttpClientHandler();
            InitHttpClientHandler( clientHandler );
            return _httpClientFactory.CreateClient();
        }

        /// <summary>
        /// 创建Http客户端处理器
        /// </summary>
        protected HttpClientHandler CreateHttpClientHandler() {
            var handlerFactory = _httpClientFactory as IHttpMessageHandlerFactory;
            var handler = handlerFactory.CreateHandler();
            while( handler is DelegatingHandler delegatingHandler ) {
                handler = delegatingHandler.InnerHandler;
            }
            return handler as HttpClientHandler;
        }

        /// <summary>
        /// 初始化Http客户端处理器
        /// </summary>
        /// <param name="handler">Http客户端处理器</param>
        protected virtual void InitHttpClientHandler( HttpClientHandler handler ) {
            InitCertificate( handler );
        }

        #endregion

        #region InitCertificate(初始化证书)

        /// <summary>
        /// 初始化证书
        /// </summary>
        protected void InitCertificate( HttpClientHandler handler ) {
            if( CertificatePath.IsEmpty() )
                return;
            var certificate = new X509Certificate2( CertificatePath, CertificatePassword, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet );
            handler.ClientCertificates.Add( certificate );
        }

        #endregion

        #region SendAfterAsync(发送后操作)

        /// <summary>
        /// 发送后操作
        /// </summary>
        /// <param name="response">响应消息</param>
        protected virtual async Task<TResult> SendAfterAsync( HttpResponseMessage response ) {
            if( SendAfterAction != null )
                return await SendAfterAction( response );
            string content = null;
            try {
                content = await response.Content.ReadAsStringAsync();
                if( response.IsSuccessStatusCode )
                    return SuccessHandler( response, content );
                FailHandler( response, content );
                return null;
            }
            finally {
                CompleteHandler( response, content );
            }
        }

        #endregion

        #region SuccessHandler(成功处理操作)

        /// <summary>
        /// 成功处理操作
        /// </summary>
        protected virtual TResult SuccessHandler( HttpResponseMessage response, string content ) {
            TResult result = ConvertTo( content, response.GetContentType() );
            return result;
        }

        #endregion

        #region ConvertTo(将内容转换为结果)

        /// <summary>
        /// 将内容转换为结果
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="contentType">内容类型</param>
        protected virtual TResult ConvertTo( string content, string contentType ) {
            if( ConvertAction != null )
                return ConvertAction( content );
            if( typeof( TResult ) == typeof( string ) )
                return (TResult)(object)content;
            if( contentType.SafeString().ToLower() == "application/json" ) {
                var options = new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true,
                    Converters = {
                        new DateTimeJsonConverter(),
                        new NullableDateTimeJsonConverter()
                    }
                };
                return Json.ToObject<TResult>( content, options );
            }
            return null;
        }

        #endregion

        #region FailHandler(失败处理操作)

        /// <summary>
        /// 失败处理操作
        /// </summary>
        protected virtual void FailHandler( HttpResponseMessage response, object content ) {
            FailAction?.Invoke( response, content );
        }

        #endregion

        #region CompleteHandler(执行完成操作)

        /// <summary>
        /// 执行完成操作
        /// </summary>
        protected virtual void CompleteHandler( HttpResponseMessage response, object content ) {
            CompleteAction?.Invoke( response, content );
        }

        #endregion

        #region GetStreamAsync(获取流)

        /// <inheritdoc />
        public async Task<byte[]> GetStreamAsync() {
            var message = CreateMessage();
            if( SendBefore( message ) == false )
                return default;
            var response = await SendAsync( message );
            return await GetStream( response );
        }

        /// <summary>
        /// 发送后操作
        /// </summary>
        /// <param name="response">响应消息</param>
        protected virtual async Task<byte[]> GetStream( HttpResponseMessage response ) {
            byte[] content = null;
            try {
                content = await response.Content.ReadAsByteArrayAsync();
                if( response.IsSuccessStatusCode )
                    return content;
                FailHandler( response, content );
                return null;
            }
            finally {
                CompleteHandler( response, content );
            }
        }

        #endregion

        #region WriteAsync(写入文件)

        /// <inheritdoc />
        public async Task WriteAsync( string filePath ) {
            var bytes = await GetStreamAsync();
            await File.WriteAsync( filePath, bytes );
        }

        #endregion
    }
}
