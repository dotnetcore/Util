using Util.Helpers;

namespace Util.Microservices.Dapr.CommandLines;

/// <summary>
/// dapr stop命令
/// </summary>
public class DaprStopCommand {
    /// <summary>
    /// 日志操作
    /// </summary>
    private ILogger _logger;
    /// <summary>
    /// 应用标识
    /// </summary>
    private string _appId;

    /// <summary>
    /// 封闭构造方法
    /// </summary>
    private DaprStopCommand() {
        _logger = NullLogger.Instance;
    }

    /// <summary>
    /// 创建dapr stop命令
    /// </summary>
    /// <param name="appId">应用标识</param>
    public static DaprStopCommand Create( string appId ) {
        return new DaprStopCommand().AppId( appId );
    }

    /// <summary>
    /// 设置应用标识
    /// </summary>
    /// <param name="id">应用标识</param>
    private DaprStopCommand AppId( string id ) {
        _appId = id;
        return this;
    }

    /// <summary>
    /// 设置日志操作
    /// </summary>
    public DaprStopCommand Log( ILogger logger ) {
        _logger = logger;
        return this;
    }

    /// <summary>
    /// 执行命令
    /// </summary>
    public void Execute() {
        CreateCommandLine()
            .OutputToMatch( "app stopped successfully" )
            .OutputToMatch( "failed to stop app id" )
            .Execute();
    }

    /// <summary>
    /// 创建命令行操作
    /// </summary>
    private CommandLine CreateCommandLine() {
        return CommandLine.Create( "dapr" )
            .Log( _logger )
            .Arguments( "stop" )
            .Arguments( "--app-id", _appId );
    }

    /// <summary>
    /// 获取命令调试文本
    /// </summary>
    public string GetDebugText() {
        return CreateCommandLine().GetDebugText();
    }
}