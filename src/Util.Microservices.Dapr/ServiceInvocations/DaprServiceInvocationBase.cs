namespace Util.Microservices.Dapr.ServiceInvocations;

/// <summary>
/// Dapr服务调用操作
/// </summary>
/// <typeparam name="TServiceInvocation">服务调用接口类型</typeparam>
public abstract class DaprServiceInvocationBase<TServiceInvocation> : IServiceInvocationBase<TServiceInvocation> where TServiceInvocation : IServiceInvocationBase<TServiceInvocation> {
    /// <summary>
    /// Dapr客户端
    /// </summary>
    protected DaprClient Client { get; }
    /// <summary>
    /// 配置
    /// </summary>
    protected DaprOptions Options { get; }
    /// <summary>
    /// 日志
    /// </summary>
    protected ILogger Log { get; set; }
    /// <summary>
    /// 应用标识
    /// </summary>
    protected string AppId { get; set; }
    /// <summary>
    /// 是否对结果解包
    /// </summary>
    protected bool IsUnpackResult { get; set; }
    /// <summary>
    /// 请求头集合
    /// </summary>
    protected IDictionary<string,string> Headers { get; set; }
    /// <summary>
    /// 导入请求头键名集合
    /// </summary>
    protected List<string> ImportHeaderKeys { get; set; }
    /// <summary>
    /// 移除请求头键名集合
    /// </summary>
    protected IList<string> RemoveHeaderKeys { get; set; }
    /// <summary>
    /// 服务状态码转换事件
    /// </summary>
    protected Func<string, ServiceState> OnStateAction { get; set; }

    /// <summary>
    /// 初始化Dapr服务调用操作
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="loggerFactory">日志工厂</param>
    protected DaprServiceInvocationBase( DaprClient client,IOptions<DaprOptions> options, ILoggerFactory loggerFactory ) {
        Client = client ?? throw new ArgumentNullException( nameof( client ) );
        Options = options?.Value ?? new DaprOptions();
        Log = loggerFactory?.CreateLogger( typeof( IServiceInvocation ) ) ?? NullLogger.Instance;
        Headers = new Dictionary<string, string>();
        ImportHeaderKeys = new List<string>();
        RemoveHeaderKeys = new List<string>();
        IsUnpackResult = Options.ServiceInvocation.IsUnpackResult;
    }

    /// <inheritdoc />
    public TServiceInvocation Service( string appId ) {
        AppId = appId;
        return Return();
    }

    /// <summary>
    /// 返回
    /// </summary>
    private TServiceInvocation Return() {
        return (TServiceInvocation)(object)this;
    }

    /// <inheritdoc />
    public TServiceInvocation UnpackResult( bool isUnpack ) {
        IsUnpackResult = isUnpack;
        return Return();
    }

    /// <inheritdoc />
    public TServiceInvocation BearerToken( string token ) {
        Header( "Authorization",$"Bearer {token}" );
        return Return();
    }

    /// <inheritdoc />
    public TServiceInvocation Header( string key, string value ) {
        if ( key.IsEmpty() )
            return Return();
        if ( Headers.ContainsKey( key ) )
            Headers.Remove( key );
        Headers.Add( key, value );
        return Return();
    }

    /// <inheritdoc />
    public TServiceInvocation Header( IDictionary<string, string> headers ) {
        if ( headers == null )
            return Return();
        foreach ( var header in headers )
            Header( header.Key, header.Value );
        return Return();
    }

    /// <inheritdoc />
    public TServiceInvocation ImportHeader( string key ) {
        if ( key.IsEmpty() )
            return Return();
        if( ImportHeaderKeys.Contains( key ) == false )
            ImportHeaderKeys.Add( key );
        return Return();
    }

    /// <inheritdoc />
    public TServiceInvocation ImportHeader( IEnumerable<string> keys ) {
        if ( keys == null )
            return Return();
        foreach ( var key in keys )
            ImportHeader( key );
        return Return();
    }

    /// <inheritdoc />
    public TServiceInvocation RemoveHeader( string key ) {
        if ( key.IsEmpty() )
            return Return();
        if ( RemoveHeaderKeys.Contains( key ) == false )
            RemoveHeaderKeys.Add( key );
        return Return();
    }

    /// <summary>
    /// 服务状态码转换事件
    /// </summary>
    /// <param name="action">转换为服务状态码,参数为业务状态码或Http状态码,取决于是否使用约定结果类型</param>
    public TServiceInvocation OnState( Func<string, ServiceState> action ) {
        OnStateAction = action;
        return Return();
    }
}