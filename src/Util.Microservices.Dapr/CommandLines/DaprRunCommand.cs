using System.Net.Sockets;
using Util.Helpers;

namespace Util.Microservices.Dapr.CommandLines;

/// <summary>
/// dapr run 命令
/// </summary>
public class DaprRunCommand {
    /// <summary>
    /// 日志操作
    /// </summary>
    private ILogger _logger;
    /// <summary>
    /// 应用标识
    /// </summary>
    private string _appId;
    /// <summary>
    /// 应用端口
    /// </summary>
    private int _appPort;
    /// <summary>
    /// 应用访问协议
    /// </summary>
    private string _appProtocol;
    /// <summary>
    /// Dapr Http端口
    /// </summary>
    private int _daprHttpPort;
    /// <summary>
    /// Dapr Grpc端口
    /// </summary>
    private int _daprGrpcPort;
    /// <summary>
    /// 度量端口
    /// </summary>
    private int _metricsPort;
    /// <summary>
    /// Dapr组件配置目录路径
    /// </summary>
    private string _componentsPath;
    /// <summary>
    /// Dapr配置目录路径
    /// </summary>
    private string _configPath;
    /// <summary>
    /// dotnet项目文件路径
    /// </summary>
    private string _project;
    /// <summary>
    /// 是否使用空闲端口
    /// </summary>
    private bool _isUseFreePorts;

    /// <summary>
    /// 封闭构造方法
    /// </summary>
    private DaprRunCommand() {
        _logger = NullLogger.Instance;
    }

    /// <summary>
    /// 创建dapr run命令
    /// </summary>
    /// <param name="appId">应用标识</param>
    public static DaprRunCommand Create( string appId ) {
        return new DaprRunCommand().AppId( appId );
    }

    /// <summary>
    /// 获取应用协议
    /// </summary>
    public string GetAppProtocol() {
        return _appProtocol;
    }

    /// <summary>
    /// 获取应用端口
    /// </summary>
    public int GetAppPort() {
        return _appPort;
    }

    /// <summary>
    /// 获取Dapr Http端口
    /// </summary>
    public int GetDaprHttpPort() {
        return _daprHttpPort;
    }

    /// <summary>
    /// 获取Dapr Grpc端口
    /// </summary>
    public int GetDaprGrpcPort() {
        return _daprGrpcPort;
    }

    /// <summary>
    /// 获取度量端口
    /// </summary>
    public int GetMetricsPort() {
        return _metricsPort;
    }

    /// <summary>
    /// 设置应用标识
    /// </summary>
    /// <param name="id">应用标识</param>
    private DaprRunCommand AppId( string id ) {
        _appId = id;
        return this;
    }

    /// <summary>
    /// 设置日志操作
    /// </summary>
    public DaprRunCommand Log( ILogger logger ) {
        _logger = logger;
        return this;
    }

    /// <summary>
    /// 设置应用端口,如果未设置则自动获取
    /// </summary>
    /// <param name="port">应用Http端口</param>
    public DaprRunCommand AppPort( int port ) {
        _appPort = port;
        return this;
    }

    /// <summary>
    /// 设置Dapr访问应用协议
    /// </summary>
    /// <param name="protocol">访问协议,可选值为: Http,Grpc,默认值为: Http</param>
    public DaprRunCommand AppProtocol( string protocol ) {
        _appProtocol = protocol;
        return this;
    }

    /// <summary>
    /// 设置Dapr Http端口,如果未设置则自动获取
    /// </summary>
    /// <param name="port">Dapr Http端口</param>
    public DaprRunCommand DaprHttpPort( int port ) {
        _daprHttpPort = port;
        return this;
    }

    /// <summary>
    /// 设置Dapr Grpc端口,如果未设置则自动获取
    /// </summary>
    /// <param name="port">Dapr Grpc端口</param>
    public DaprRunCommand DaprGrpcPort( int port ) {
        _daprGrpcPort = port;
        return this;
    }

    /// <summary>
    /// 设置度量端口,如果未设置则自动获取
    /// </summary>
    /// <param name="port">度量端口</param>
    public DaprRunCommand MetricsPort( int port ) {
        _metricsPort = port;
        return this;
    }

    /// <summary>
    /// 设置Dapr组件配置目录路径
    /// </summary>
    /// <param name="path">Dapr组件配置目录路径</param>
    public DaprRunCommand ComponentsPath( string path ) {
        _componentsPath = path;
        return this;
    }

    /// <summary>
    /// 设置Dapr配置文件路径
    /// </summary>
    /// <param name="path">Dapr配置文件路径</param>
    public DaprRunCommand ConfigPath( string path ) {
        _configPath = path;
        return this;
    }

    /// <summary>
    /// 设置dotnet项目文件路径
    /// </summary>
    /// <param name="project">dotnet项目文件路径,范例: ../../test/app.csproj</param>
    public DaprRunCommand Project( string project ) {
        _project = project;
        return this;
    }

    /// <summary>
    /// 设置或取消使用空闲端口
    /// </summary>
    /// <param name="isUseFreePorts">是否使用空闲端口</param>
    public DaprRunCommand UseFreePorts( bool isUseFreePorts = true ) {
        _isUseFreePorts = isUseFreePorts;
        return this;
    }

    /// <summary>
    /// 执行命令
    /// </summary>
    public void Execute() {
        CreateCommandLine()
            .OutputToMatch( "dapr initialized. Status: Running." )
            .Execute();
    }

    /// <summary>
    /// 创建命令行操作
    /// </summary>
    private CommandLine CreateCommandLine() {
        if ( _isUseFreePorts )
            GetFreePorts();
        return CommandLine.Create( "dapr" )
            .Log( _logger )
            .Arguments( "run" )
            .Arguments( "--app-id", _appId )
            .ArgumentsIf( _appPort != 0, "--app-port", _appPort.ToString( CultureInfo.InvariantCulture ) )
            .ArgumentsIf( _appProtocol.IsEmpty() == false, "--app-protocol", _appProtocol )
            .ArgumentsIf( _daprHttpPort != 0, "--dapr-http-port", _daprHttpPort.ToString( CultureInfo.InvariantCulture ) )
            .ArgumentsIf( _daprGrpcPort != 0, "--dapr-grpc-port", _daprGrpcPort.ToString( CultureInfo.InvariantCulture ) )
            .ArgumentsIf( _metricsPort != 0, "--metrics-port", _metricsPort.ToString( CultureInfo.InvariantCulture ) )
            .ArgumentsIf( _componentsPath.IsEmpty() == false, "--resources-path", _componentsPath )
            .ArgumentsIf( _configPath.IsEmpty() == false, "--config", _configPath )
            .Arguments( "--log-level", "debug" )
            .ArgumentsIf( _project.IsEmpty() == false, "--" )
            .ArgumentsIf( _project.IsEmpty() == false, "dotnet", "run" )
            .ArgumentsIf( _project.IsEmpty() == false, "--project", _project )
            .ArgumentsIf( _project.IsEmpty() == false && _appPort != 0, "--urls", $"http://localhost:{_appPort.ToString( CultureInfo.InvariantCulture )}" );
    }

    /// <summary>
    /// 获取空闲端口
    /// </summary>
    private void GetFreePorts() {
        const int NUM_LISTENERS = 4;
        IPAddress ip = IPAddress.Loopback;
        var listeners = new TcpListener[NUM_LISTENERS];
        var ports = new int[NUM_LISTENERS];
        for ( int i = 0; i < NUM_LISTENERS; i++ ) {
            listeners[i] = new TcpListener( ip, 0 );
            listeners[i].Start();
            ports[i] = ( (IPEndPoint)listeners[i].LocalEndpoint ).Port;
        }
        for ( int i = 0; i < NUM_LISTENERS; i++ ) {
            listeners[i].Stop();
        }
        if ( _appPort == 0 )
            _appPort = ports[0];
        if ( _daprHttpPort == 0 )
            _daprHttpPort = ports[1];
        if ( _daprGrpcPort == 0 )
            _daprGrpcPort = ports[2];
        if ( _metricsPort == 0 )
            _metricsPort = ports[3];
    }

    /// <summary>
    /// 获取命令调试文本
    /// </summary>
    public string GetDebugText() {
        return CreateCommandLine().GetDebugText();
    }
}