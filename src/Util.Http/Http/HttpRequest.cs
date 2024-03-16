using Util.Helpers;

namespace Util.Http;

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
    /// Http客户端名称
    /// </summary>
    private string _httpClientName;
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
    /// <summary>
    /// 是否忽略SSL证书
    /// </summary>
    private bool _ignoreSsl;
    /// <summary>
    /// 响应完成模式
    /// </summary>
    private HttpCompletionOption _completionOption;

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
        if ( httpClientFactory == null && httpClient == null )
            throw new ArgumentNullException( nameof( httpClientFactory ) );
        if ( url.IsEmpty() )
            throw new ArgumentNullException( nameof( url ) );
        _httpClientFactory = httpClientFactory;
        _httpClient = httpClient;
        _httpMethod = httpMethod;
        _url = url;
        HeaderParams = new Dictionary<string, string>();
        QueryParams = new Dictionary<string, string>();
        Params = new Dictionary<string, object>();
        Files = new List<FileData>();
        Cookies = new Dictionary<string, string>();
        HttpContentType = Util.Http.HttpContentType.Json.Description();
        CharacterEncoding = System.Text.Encoding.UTF8;
        IsUseCookies = true;
        IsFileParameterQuotes = true;
        _completionOption = HttpCompletionOption.ResponseContentRead;
    }

    #endregion

    #region 属性

    /// <summary>
    /// 超时间隔
    /// </summary>
    protected TimeSpan? HttpTimeout { get; private set; }
    /// <summary>
    /// 基地址
    /// </summary>
    protected string BaseAddressUri { get; private set; }
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
    /// Cookie参数集合
    /// </summary>
    protected IDictionary<string, string> Cookies { get; }
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
    /// 文件数据列表
    /// </summary>
    protected List<FileData> Files { get; private set; }
    /// <summary>
    /// 是否自动携带cookie
    /// </summary>
    protected bool IsUseCookies { get; private set; }
    /// <summary>
    /// 文件上传参数是否添加双引号
    /// </summary>
    protected bool IsFileParameterQuotes { get; private set; }
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
    /// 执行成功操作
    /// </summary>
    protected Func<TResult, Task> SuccessFunc { get; private set; }
    /// <summary>
    /// 执行失败操作
    /// </summary>
    protected Action<HttpResponseMessage, object> FailAction { get; private set; }
    /// <summary>
    /// 执行完成操作
    /// </summary>
    protected Action<HttpResponseMessage, object> CompleteAction { get; private set; }

    #endregion

    #region Timeout(设置超时间隔)

    /// <inheritdoc />
    public IHttpRequest<TResult> Timeout( TimeSpan timeout ) {
        HttpTimeout = timeout;
        return this;
    }

    #endregion

    #region HttpClientName(设置Http客户端名称)

    /// <inheritdoc />
    public IHttpRequest<TResult> HttpClientName( string name ) {
        _httpClientName = name;
        return this;
    }

    #endregion

    #region BaseAddress(设置基地址)

    /// <summary>
    /// 设置基地址
    /// </summary>
    /// <param name="baseAddress">基地址</param>
    public IHttpRequest<TResult> BaseAddress( string baseAddress ) {
        BaseAddressUri = baseAddress;
        return this;
    }

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

    #region HttpCompletion(设置响应完成模式)

    /// <inheritdoc />
    public IHttpRequest<TResult> HttpCompletion( HttpCompletionOption option ) {
        _completionOption = option;
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

    #region BearerToken(设置访问令牌)

    /// <inheritdoc />
    public IHttpRequest<TResult> BearerToken( string token ) {
        Header( "Authorization", $"Bearer {token}" );
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

    #region IgnoreSsl(是否忽略SSL证书)

    /// <inheritdoc />
    public IHttpRequest<TResult> IgnoreSsl() {
        _ignoreSsl = true;
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

    #region GetJsonSerializerOptions(获取Json序列化配置)

    /// <summary>
    /// 获取Json序列化配置
    /// </summary>
    protected virtual JsonSerializerOptions GetJsonSerializerOptions() {
        if ( _jsonSerializerOptions != null )
            return _jsonSerializerOptions;
        return new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.All ),
            Converters = {
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter()
            }
        };
    }

    #endregion

    #region Header(设置请求头)

    /// <inheritdoc />
    public IHttpRequest<TResult> Header( string key, string value ) {
        if ( key.IsEmpty() )
            return this;
        if ( HeaderParams.ContainsKey( key ) )
            HeaderParams.Remove( key );
        HeaderParams.Add( key, value );
        return this;
    }

    /// <inheritdoc />
    public IHttpRequest<TResult> Header( IDictionary<string, string> headers ) {
        if ( headers == null )
            return this;
        foreach ( var header in headers )
            Header( header.Key, header.Value );
        return this;
    }

    #endregion

    #region QueryString(设置查询字符串)

    /// <inheritdoc />
    public IHttpRequest<TResult> QueryString( string key, string value ) {
        if ( key.IsEmpty() )
            return this;
        if ( QueryParams.ContainsKey( key ) )
            QueryParams.Remove( key );
        QueryParams.Add( key, value );
        return this;
    }

    /// <inheritdoc />
    public IHttpRequest<TResult> QueryString( IDictionary<string, string> queryString ) {
        if ( queryString == null )
            return this;
        foreach ( var param in queryString )
            QueryString( param.Key, param.Value );
        return this;
    }

    /// <summary>
    /// 设置查询字符串,即url中?后面的参数
    /// </summary>
    /// <param name="queryString">查询字符串对象</param>
    public IHttpRequest<TResult> QueryString( object queryString ) {
        var dic = ToDictionary( queryString );
        foreach ( var param in dic )
            QueryString( param.Key, param.Value.ToString() );
        return this;
    }

    #endregion

    #region UseCookies(设置是否自动携带cookie)

    /// <inheritdoc />
    public IHttpRequest<TResult> UseCookies( bool isUseCookies ) {
        IsUseCookies = isUseCookies;
        return this;
    }

    #endregion

    #region Cookie(设置Cookie)

    /// <inheritdoc />
    public IHttpRequest<TResult> Cookie( string key, string value ) {
        if ( key.IsEmpty() )
            return this;
        if ( Cookies.ContainsKey( key ) )
            Cookies.Remove( key );
        Cookies.Add( key, value );
        return this;
    }

    /// <inheritdoc />
    public IHttpRequest<TResult> Cookie( IDictionary<string, string> cookies ) {
        if ( cookies == null )
            return this;
        foreach ( var cookie in cookies )
            Cookie( cookie.Key, cookie.Value );
        return this;
    }

    #endregion

    #region Content(添加内容参数)

    /// <inheritdoc />
    public IHttpRequest<TResult> Content( string key, object value ) {
        if ( key.IsEmpty() )
            return this;
        if ( value == null )
            return this;
        if ( Params.ContainsKey( key ) )
            Params.Remove( key );
        Params.Add( key, value );
        return this;
    }

    /// <inheritdoc />
    public IHttpRequest<TResult> Content( IDictionary<string, object> parameters ) {
        if ( parameters == null )
            return this;
        foreach ( var param in parameters )
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

    #region FileContent(添加文件参数)

    /// <inheritdoc />
    public IHttpRequest<TResult> FileContent( Stream file, string fileName, string name = "file" ) {
        ContentType( Http.HttpContentType.FormData );
        if ( Files.Any( t => t.Name == name ) )
            Files.RemoveAll( t => t.Name == name );
        Files.Add( new FileData( file, fileName, name ) );
        return this;
    }

    /// <inheritdoc />
    public IHttpRequest<TResult> FileContent( string filePath, string name = "file" ) {
        ContentType( Http.HttpContentType.FormData );
        if ( Files.Any( t => t.Name == name ) )
            Files.RemoveAll( t => t.Name == name );
        Files.Add( new FileData( filePath, name ) );
        return this;
    }

    #endregion

    #region FileParameterQuotes(文件上传参数是否添加双引号)

    /// <inheritdoc />
    public IHttpRequest<TResult> FileParameterQuotes( bool isQuote = true ) {
        IsFileParameterQuotes = isQuote;
        return this;
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

    /// <summary>
    /// 请求成功事件
    /// </summary>
    /// <param name="action">执行成功操作,参数为响应结果</param>
    public IHttpRequest<TResult> OnSuccess( Func<TResult, Task> action ) {
        SuccessFunc = action;
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
    public async Task<TResult> GetResultAsync( CancellationToken cancellationToken = default ) {
        var message = await CreateMessage();
        if ( SendBefore( message ) == false )
            return default;
        var response = await SendAsync( message, cancellationToken );
        return await SendAfterAsync( response );
    }

    #endregion

    #region CreateMessage(创建请求消息)

    /// <summary>
    /// 创建请求消息
    /// </summary>
    protected virtual async Task<HttpRequestMessage> CreateMessage() {
        var message = new HttpRequestMessage( _httpMethod, GetUrl( _url ) );
        AddCookies();
        AddHeaders( message );
        message.Content = await CreateHttpContent();
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
    /// 添加Cookie
    /// </summary>
    protected virtual void AddCookies() {
        if ( Cookies.Count == 0 )
            return;
        var cookieValues = new List<CookieHeaderValue>();
        foreach ( var cookie in Cookies )
            cookieValues.Add( new CookieHeaderValue( cookie.Key, cookie.Value ) );
        Header( "Cookie", cookieValues.Select( t => t.ToString() ).Join() );
    }

    /// <summary>
    /// 添加请求头
    /// </summary>
    /// <param name="message">请求消息</param>
    protected virtual void AddHeaders( HttpRequestMessage message ) {
        foreach ( var header in HeaderParams )
            message.Headers.Add( header.Key, header.Value );
    }

    /// <summary>
    /// 创建请求内容
    /// </summary>
    protected virtual async Task<HttpContent> CreateHttpContent() {
        var contentType = HttpContentType.SafeString().ToLower();
        switch ( contentType ) {
            case "application/x-www-form-urlencoded":
                return CreateFormContent();
            case "application/json":
                return CreateJsonContent();
            case "text/xml":
                return CreateXmlContent();
            case "multipart/form-data":
                return await CreateFileUploadContent();
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
        if ( dictionary == null )
            return result;
        foreach ( var parameter in dictionary ) {
            if ( result.ContainsKey( parameter.Key ) )
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
        if ( content.IsEmpty() )
            return null;
        return new StringContent( content, CharacterEncoding, "application/json" );
    }

    /// <summary>
    /// 获取json内容值
    /// </summary>
    private string GetJsonContentValue() {
        var options = GetJsonSerializerOptions();
        if ( Param != null && Params.Count > 0 )
            return Json.ToJson( GetParameters(), options );
        if ( Param != null )
            return Json.ToJson( Param, options );
        if ( Params.Count > 0 )
            return Json.ToJson( Params, options );
        return null;
    }

    /// <summary>
    /// 创建xml内容
    /// </summary>
    protected virtual HttpContent CreateXmlContent() {
        return new StringContent( Param.SafeString(), CharacterEncoding, "text/xml" );
    }

    /// <summary>
    /// 创建文件上传内容
    /// </summary>
    protected virtual async Task<HttpContent> CreateFileUploadContent() {
        var result = new MultipartFormDataContent( GetBoundary() );
        AddFileParameters( result );
        await AddFileData( result );
        ClearBoundaryQuotes( result );
        return result;
    }

    /// <summary>
    /// 获取 multipart/form-data 分隔符
    /// </summary>
    protected virtual string GetBoundary() {
        return $"-----{Guid.NewGuid()}";
    }

    /// <summary>
    /// 添加文件参数
    /// </summary>
    protected void AddFileParameters( MultipartFormDataContent content ) {
        var parameters = GetParameters();
        foreach ( var parameter in parameters ) {
            var item = new ByteArrayContent( System.Text.Encoding.UTF8.GetBytes( parameter.Value.SafeString() ) );
            content.Add( item, GetFileParameter( parameter.Key ) );
        }
    }

    /// <summary>
    /// 获取参数
    /// </summary>
    protected string GetFileParameter( string param ) {
        return IsFileParameterQuotes ? "\"" + param + "\"" : param;
    }

    /// <summary>
    /// 添加文件数据
    /// </summary>
    protected async Task AddFileData( MultipartFormDataContent content ) {
        foreach ( var file in Files ) {
            if ( file.Stream != null ) {
                await using var fileStream = file.Stream;
                var bytes = await Util.Helpers.File.ReadToBytesAsync( fileStream );
                AddFileData( content, bytes, file.Name, file.FileName );
                continue;
            }
            if ( file.FilePath.IsEmpty() )
                continue;
            if ( Util.Helpers.File.FileExists( file.FilePath ) == false )
                return;
            var fileName = Path.GetFileName( file.FilePath );
            var stream = await Util.Helpers.File.ReadToMemoryStreamAsync( file.FilePath );
            AddFileData( content, stream.ToArray(), file.Name, fileName );
        }
    }

    /// <summary>
    /// 添加文件数据
    /// </summary>
    protected void AddFileData( MultipartFormDataContent content, byte[] stream, string name, string fileName ) {
        if ( stream == null )
            return;
        var fileContent = new ByteArrayContent( stream );
        content.Add( fileContent, GetFileParameter( name ), GetFileParameter( fileName ) );
        if ( fileContent.Headers is { ContentDisposition: not null } )
            fileContent.Headers.ContentDisposition.FileNameStar = null;
    }

    /// <summary>
    /// 清除分隔符双引号
    /// </summary>
    protected void ClearBoundaryQuotes( MultipartFormDataContent content ) {
        var boundary = content?.Headers?.ContentType?.Parameters.FirstOrDefault( o => o.Name == "boundary" );
        if ( boundary == null )
            return;
        boundary.Value = boundary.Value?.Replace( "\"", null );
    }

    #endregion

    #region SendBefore(发送前操作)

    /// <summary>
    /// 发送前操作
    /// </summary>
    /// <param name="message">请求消息</param>
    protected virtual bool SendBefore( HttpRequestMessage message ) {
        if ( SendBeforeAction == null )
            return true;
        return SendBeforeAction( message );
    }

    #endregion

    #region SendAsync(发送请求)

    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="message">请求消息</param>
    /// <param name="cancellationToken">取消令牌</param>
    protected async Task<HttpResponseMessage> SendAsync( HttpRequestMessage message, CancellationToken cancellationToken ) {
        var client = GetClient();
        client.CheckNull( nameof( client ) );
        InitHttpClient( client );
        return await client.SendAsync( message, _completionOption, cancellationToken );
    }

    #endregion

    #region GetClient(获取Http客户端)

    /// <summary>
    /// 获取Http客户端
    /// </summary>
    protected HttpClient GetClient() {
        if ( _httpClient != null )
            return _httpClient;
        var clientHandler = CreateHttpClientHandler();
        InitHttpClientHandler( clientHandler );
        return _httpClientName.IsEmpty() ? _httpClientFactory.CreateClient() : _httpClientFactory.CreateClient( _httpClientName );
    }

    /// <summary>
    /// 创建Http客户端处理器
    /// </summary>
    protected HttpClientHandler CreateHttpClientHandler() {
        var handlerFactory = _httpClientFactory as IHttpMessageHandlerFactory;
        if ( handlerFactory == null )
            return null;
        var handler = _httpClientName.IsEmpty() ? handlerFactory.CreateHandler() : handlerFactory.CreateHandler( _httpClientName );
        while ( handler is DelegatingHandler delegatingHandler ) {
            handler = delegatingHandler.InnerHandler;
        }
        return handler as HttpClientHandler;
    }

    /// <summary>
    /// 初始化Http客户端处理器
    /// </summary>
    /// <param name="handler">Http客户端处理器</param>
    protected virtual void InitHttpClientHandler( HttpClientHandler handler ) {
        if ( handler == null )
            return;
        InitCertificate( handler );
        InitUseCookies( handler );
        IgnoreSsl( handler );
    }

    #endregion

    #region InitCertificate(初始化证书)

    /// <summary>
    /// 初始化证书
    /// </summary>
    protected virtual void InitCertificate( HttpClientHandler handler ) {
        if ( CertificatePath.IsEmpty() )
            return;
        var certificate = new X509Certificate2( CertificatePath, CertificatePassword, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet );
        handler.ClientCertificates.Clear();
        handler.ClientCertificates.Add( certificate );
    }

    #endregion

    #region InitUseCookies(初始化是否携带Cookie)

    /// <summary>
    /// 初始化是否携带Cookie
    /// </summary>
    protected virtual void InitUseCookies( HttpClientHandler handler ) {
        if ( handler.UseCookies != IsUseCookies )
            handler.UseCookies = IsUseCookies;
    }

    #endregion

    #region IgnoreSsl(忽略SSL证书错误)

    /// <summary>
    /// 忽略SSL证书错误
    /// </summary>
    protected virtual void IgnoreSsl( HttpClientHandler handler ) {
        if ( _ignoreSsl == false )
            return;
        handler.ServerCertificateCustomValidationCallback ??= ( _, _, _, _ ) => true;
    }

    #endregion

    #region InitHttpClient(初始化Http客户端)

    /// <summary>
    /// 初始化Http客户端
    /// </summary>
    protected virtual void InitHttpClient( HttpClient client ) {
        InitBaseAddress( client );
        InitTimeout( client );
    }

    #endregion

    #region InitBaseAddress(初始化基地址)

    /// <summary>
    /// 初始化基地址
    /// </summary>
    protected virtual void InitBaseAddress( HttpClient client ) {
        if ( BaseAddressUri.IsEmpty() )
            return;
        client.BaseAddress = new Uri( BaseAddressUri );
    }

    #endregion

    #region InitTimeout(初始化超时间隔)

    /// <summary>
    /// 初始化超时间隔
    /// </summary>
    protected virtual void InitTimeout( HttpClient client ) {
        if ( HttpTimeout == null )
            return;
        client.Timeout = HttpTimeout.SafeValue();
    }

    #endregion

    #region SendAfterAsync(发送后操作)

    /// <summary>
    /// 发送后操作
    /// </summary>
    /// <param name="response">响应消息</param>
    protected virtual async Task<TResult> SendAfterAsync( HttpResponseMessage response ) {
        if ( SendAfterAction != null )
            return await SendAfterAction( response );
        string content = null;
        try {
            content = await response.Content.ReadAsStringAsync();
            if ( response.IsSuccessStatusCode )
                return await SuccessHandlerAsync( response, content );
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
    protected virtual async Task<TResult> SuccessHandlerAsync( HttpResponseMessage response, string content ) {
        var result = ConvertTo( content, response.GetContentType() );
        SuccessAction?.Invoke( result );
        if ( SuccessFunc != null )
            await SuccessFunc( result );
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
        if ( ConvertAction != null )
            return ConvertAction( content );
        if ( typeof( TResult ) == typeof( string ) )
            return (TResult)(object)content;
        return contentType.SafeString().ToLower() == "application/json" ? Json.ToObject<TResult>( content, GetJsonSerializerOptions() ) : null;
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
    public async Task<byte[]> GetStreamAsync( CancellationToken cancellationToken = default ) {
        var message = await CreateMessage();
        if ( SendBefore( message ) == false )
            return default;
        var response = await SendAsync( message, cancellationToken );
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
            if ( response.IsSuccessStatusCode )
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
    public async Task WriteAsync( string filePath, CancellationToken cancellationToken = default ) {
        var bytes = await GetStreamAsync( cancellationToken );
        await Util.Helpers.File.WriteAsync( filePath, bytes, cancellationToken );
    }

    #endregion
}