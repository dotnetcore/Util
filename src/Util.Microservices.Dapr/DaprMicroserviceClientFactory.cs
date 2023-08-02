namespace Util.Microservices.Dapr; 

/// <summary>
/// Dapr微服务客户端工厂
/// </summary>
public class DaprMicroserviceClientFactory : IMicroserviceClientFactory {
    /// <summary>
    /// Dapr客户端
    /// </summary>
    private readonly DaprClient _client;
    /// <summary>
    /// 应用标识
    /// </summary>
    private string _appId;
    /// <summary>
    /// Dapr Http端口
    /// </summary>
    private int _daprHttpPort;
    /// <summary>
    /// Dapr配置
    /// </summary>
    private readonly IOptions<DaprOptions> _options;
    /// <summary>
    /// 日志工厂
    /// </summary>
    private readonly ILoggerFactory _loggerFactory;


    /// <summary>
    /// 初始化Dapr微服务客户端生成器
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="loggerFactory">日志工厂</param>
    public DaprMicroserviceClientFactory( DaprClient client = null, IOptions<DaprOptions> options = null, ILoggerFactory loggerFactory = null ) {
        _client = client;
        _options = options;
        _loggerFactory = loggerFactory;
    }

    /// <summary>
    /// 设置应用标识
    /// </summary>
    /// <param name="appId">应用标识</param>
    public void AppId( string appId ) {
        _appId = appId;
    }

    /// <summary>
    /// 设置Dapr Http端口
    /// </summary>
    /// <param name="daprHttpPort">Dapr Http端口</param>
    public void DaprHttpPort( int daprHttpPort ) {
        _daprHttpPort = daprHttpPort;
    }

    /// <inheritdoc />
    public virtual IMicroserviceClient Create() {
        var client = CreateDaprClient();
        var httpClient = CreateHttpClient();
        return new DaprMicroserviceClient( client, httpClient, _options, _appId, _loggerFactory );
    }

    /// <summary>
    /// 创建Dapr客户端
    /// </summary>
    protected virtual DaprClient CreateDaprClient() {
        var httpEndpoint = GetDaprHttpEndpoint();
        if ( httpEndpoint.IsEmpty() == false ) {
            return new DaprClientBuilder()
                .UseHttpEndpoint( httpEndpoint )
                .Build();
        }
        return _client ?? new DaprClientBuilder().Build();
    }

    /// <summary>
    /// 获取Dapr Http端点
    /// </summary>
    protected virtual string GetDaprHttpEndpoint() {
        return _daprHttpPort > 0 ? $"http://localhost:{_daprHttpPort}" : null;
    }

    /// <summary>
    /// 创建Dapr Http客户端
    /// </summary>
    protected virtual HttpClient CreateHttpClient() {
        if ( _appId.IsEmpty() )
            return DaprClient.CreateInvokeHttpClient();
        var endpoint = GetDaprHttpEndpoint();
        return endpoint.IsEmpty() ? DaprClient.CreateInvokeHttpClient( _appId ) : DaprClient.CreateInvokeHttpClient( _appId, endpoint );
    }
}