namespace Util.Microservices.Dapr.Tests.CommandLines; 

/// <summary>
/// dapr run启动命令测试
/// </summary>
public class DaprRunCommandTest {
    /// <summary>
    /// 输出操作
    /// </summary>
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public DaprRunCommandTest( ITestOutputHelper output ) {
        _output = output;
    }

    /// <summary>
    /// 测试默认设置
    /// </summary>
    [Fact]
    public void TestDefault() {
        var result = new StringBuilder();
        result.Append( "dapr run --app-id app" );
        var command = DaprRunCommand.Create( "app" ).GetDebugText();
        _output.WriteLine( command );
        Assert.Contains( result.ToString(), command );
    }

    /// <summary>
    /// 测试设置命令参数
    /// </summary>
    [Fact]
    public void TestArguments() {
        var result = new StringBuilder();
        result.Append( "dapr run --app-id app " );
        result.Append( "--app-port 80 " );
        result.Append( "--app-protocol grpc " );
        result.Append( "--dapr-http-port 81 " );
        result.Append( "--dapr-grpc-port 82 " );
        result.Append( "--metrics-port 83 " );
        result.Append( "--resources-path components-path " );
        result.Append( "--config config-path " );
        result.Append( "--log-level debug " );
        result.Append( "-- dotnet run --project ../app.csproj " );
        result.Append( "--urls http://localhost:80" );
        var command = DaprRunCommand.Create( "app" )
            .UseFreePorts()
            .AppPort( 80 ).AppProtocol( "grpc" )
            .DaprHttpPort( 81 ).DaprGrpcPort( 82 ).MetricsPort( 83 )
            .ComponentsPath( "components-path" )
            .ConfigPath( "config-path" )
            .Project( "../app.csproj" )
            .GetDebugText();
        Assert.Equal( result.ToString(), command );
    }

    /// <summary>
    /// 测试设置命令参数
    /// </summary>
    [Fact]
    public void TestArguments_2() {
        var result = new StringBuilder();
        result.Append( "dapr run --app-id app " );
        result.Append( "--app-port 80 " );
        result.Append( "--app-protocol grpc " );
        result.Append( "--dapr-http-port 81 " );
        result.Append( "--dapr-grpc-port 82 " );
        result.Append( "--metrics-port 83 " );
        result.Append( "--resources-path components-path " );
        result.Append( "--config config-path " );
        result.Append( "--log-level debug" );
        var command = DaprRunCommand.Create( "app" )
            .UseFreePorts()
            .AppPort( 80 ).AppProtocol( "grpc" )
            .DaprHttpPort( 81 ).DaprGrpcPort( 82 ).MetricsPort( 83 )
            .ComponentsPath( "components-path" )
            .ConfigPath( "config-path" )
            .GetDebugText();
        Assert.Equal( result.ToString(), command );
    }
}