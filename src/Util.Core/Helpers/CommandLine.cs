namespace Util.Helpers;

/// <summary>
/// 命令行操作
/// </summary>
public class CommandLine {
    /// <summary>
    /// 日志操作
    /// </summary>
    private ILogger _logger;
    /// <summary>
    /// 命令,范例: dotnet
    /// </summary>
    private string _command;
    /// <summary>
    /// 命令参数,范例: --info
    /// </summary>
    private string _arguments;
    /// <summary>
    /// 环境变量
    /// </summary>
    private readonly IDictionary<string, string> _environmentVariables;
    /// <summary>
    /// 是否重定向标准输出流
    /// </summary>
    private bool _redirectStandardOutput;
    /// <summary>
    /// 是否重定向标准错误流
    /// </summary>
    private bool _redirectStandardError;
    /// <summary>
    /// 输出流字符编码,默认值: Encoding.UTF8
    /// </summary>
    private Encoding _outputEncoding;
    /// <summary>
    /// 是否使用操作系统shell启动,默认值: false
    /// </summary>
    private bool _useShellExecute;
    /// <summary>
    /// 工作目录
    /// </summary>
    private string _workingDirectory;
    /// <summary>
    /// 启动进程是否不要创建新窗口
    /// </summary>
    private bool _createNoWindow;
    /// <summary>
    /// 命令执行超时间隔
    /// </summary>
    private TimeSpan _timeout;
    /// <summary>
    /// 事件等待句柄
    /// </summary>
    private readonly EventWaitHandle _outputReceived;
    /// <summary>
    /// 预期完成输出消息
    /// </summary>
    private readonly List<string> _outputToMatch;

    /// <summary>
    /// 初始化命令行操作
    /// </summary>
    public CommandLine() {
        _logger = NullLogger.Instance;
        _redirectStandardOutput = true;
        _redirectStandardError = true;
        _outputEncoding = Encoding.UTF8;
        _useShellExecute = false;
        _createNoWindow = true;
        _environmentVariables = new Dictionary<string, string>();
        _timeout = TimeSpan.FromSeconds( 30 );
        _outputReceived = new EventWaitHandle( false, EventResetMode.ManualReset );
        _outputToMatch = new List<string>();
    }

    /// <summary>
    /// 创建命令行操作
    /// </summary>
    /// <param name="command">命令,范例: dotnet</param>
    /// <param name="arguments">命令参数,范例: --info</param>
    public static CommandLine Create( string command, string arguments = null ) {
        return new CommandLine().Command( command ).Arguments( arguments );
    }

    /// <summary>
    /// 设置日志操作
    /// </summary>
    public CommandLine Log( ILogger logger ) {
        _logger = logger ?? NullLogger.Instance;
        return this;
    }

    /// <summary>
    /// 设置命令
    /// </summary>
    /// <param name="command">命令,范例: dotnet</param>
    public CommandLine Command( string command ) {
        _command = command;
        return this;
    }

    /// <summary>
    /// 根据条件设置命令参数
    /// </summary>
    /// <param name="condition">条件,如果为false则不设置命令参数</param>
    /// <param name="arguments">命令参数,范例: --info</param>
    public CommandLine ArgumentsIf( bool condition, params string[] arguments ) {
        if ( condition == false )
            return this;
        return Arguments( arguments );
    }

    /// <summary>
    /// 设置命令参数
    /// </summary>
    /// <param name="arguments">命令参数,范例: --info</param>
    public CommandLine Arguments( params string[] arguments ) {
        if ( arguments == null )
            return this;
        return Arguments( (IEnumerable<string>)arguments );
    }

    /// <summary>
    /// 根据条件设置命令参数
    /// </summary>
    /// <param name="condition">条件,如果为false则不设置命令参数</param>
    /// <param name="arguments">命令参数</param>
    public CommandLine ArgumentsIf( bool condition, IEnumerable<string> arguments ) {
        if ( condition == false )
            return this;
        return Arguments( arguments );
    }

    /// <summary>
    /// 设置命令参数
    /// </summary>
    /// <param name="arguments">命令参数</param>
    public CommandLine Arguments( IEnumerable<string> arguments ) {
        if ( arguments == null )
            return this;
        if ( _arguments.IsEmpty() == false )
            _arguments += " ";
        _arguments += string.Join( " ", arguments );
        return this;
    }

    /// <summary>
    /// 设置环境变量
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    public CommandLine Env( string key, string value ) {
        if ( key.IsEmpty() )
            return this;
        if ( _environmentVariables.ContainsKey( key ) )
            _environmentVariables.Remove( key );
        _environmentVariables.Add( key, value );
        return this;
    }

    /// <summary>
    /// 设置环境变量
    /// </summary>
    /// <param name="env">环境变量</param>
    public CommandLine Env( IDictionary<string, string> env ) {
        if ( env == null )
            return this;
        foreach ( var item in env )
            Env( item.Key, item.Value );
        return this;
    }

    /// <summary>
    /// 设置重定向标准输出流
    /// </summary>
    /// <param name="value">是否重定向标准输出流,默认值: true,注意: 如果要设置UseShellExecute为 false,
    /// 则必须将RedirectStandardOutput设置为true</param>
    public CommandLine RedirectStandardOutput( bool value = true ) {
        _redirectStandardOutput = value;
        if ( value ) {
            _useShellExecute = false;
            return this;
        }
        _useShellExecute = true;
        _outputEncoding = null;
        return this;
    }

    /// <summary>
    /// 设置重定向标准错误流
    /// </summary>
    /// <param name="value">是否重定向标准错误流</param>
    public CommandLine RedirectStandardError( bool value = true ) {
        _redirectStandardError = value;
        return this;
    }

    /// <summary>
    /// 设置输出流字符编码
    /// </summary>
    /// <param name="encoding">输出流字符编码,默认值: Encoding.UTF8</param>
    public CommandLine OutputEncoding( Encoding encoding ) {
        _outputEncoding = encoding;
        return this;
    }

    /// <summary>
    /// 设置是否使用操作系统shell启动
    /// </summary>
    /// <param name="value">是否使用操作系统shell启动,默认值: false</param>
    public CommandLine UseShellExecute( bool value = true ) {
        _useShellExecute = value;
        if ( value ) {
            _redirectStandardOutput = false;
            _outputEncoding = null;
            return this;
        }
        _redirectStandardOutput = true;
        return this;
    }

    /// <summary>
    /// 设置工作目录
    /// </summary>
    /// <param name="value">工作目录</param>
    public CommandLine WorkingDirectory( string value ) {
        _workingDirectory = value;
        return this;
    }

    /// <summary>
    /// 启动进程是否不要创建新窗口
    /// </summary>
    /// <param name="value">启动进程是否不要创建新窗口,默认为true</param>
    public CommandLine CreateNoWindow( bool value ) {
        _createNoWindow = value;
        return this;
    }

    /// <summary>
    /// 设置命令执行超时间隔,默认值: 60秒
    /// </summary>
    /// <param name="timeout">命令执行超时间隔</param>
    public CommandLine Timeout( TimeSpan timeout ) {
        _timeout = timeout;
        return this;
    }

    /// <summary>
    /// 设置命令执行完成的预期输出消息
    /// </summary>
    public CommandLine OutputToMatch( params string[] outputs ) {
        _outputToMatch.AddRange( outputs );
        return this;
    }

    /// <summary>
    /// 执行命令行
    /// </summary>
    public Process Execute() {
        if ( _command.IsEmpty() )
            throw new ArgumentException( "命令未设置" );
        _logger.LogDebug( $"Running command: {GetDebugText()}" );
        var process = new Process {
            StartInfo = CreateProcessStartInfo()
        };
        process.OutputDataReceived += OnOutput;
        process.ErrorDataReceived += OnOutput;
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        var done = _outputReceived.WaitOne( _timeout );
        if ( !done )
            throw new Exception( $"命令 \"{GetDebugText()}\" 超时" );
        return process;
    }

    /// <summary>
    /// 创建进程启动信息
    /// </summary>
    private ProcessStartInfo CreateProcessStartInfo() {
        var escapedArgs = _arguments.Replace( "\"", "\\\"" );
        var result = new ProcessStartInfo( _command, escapedArgs ) {
            RedirectStandardOutput = _redirectStandardOutput,
            RedirectStandardError = _redirectStandardError,
            StandardOutputEncoding = _outputEncoding,
            StandardErrorEncoding = _outputEncoding,
            UseShellExecute = _useShellExecute,
            WorkingDirectory = _workingDirectory,
            CreateNoWindow = _createNoWindow,
        };
        foreach ( var item in _environmentVariables )
            result.EnvironmentVariables.Add( item.Key, item.Value );
        return result;
    }

    /// <summary>
    /// 接收输出消息事件处理
    /// </summary>
    private void OnOutput( object sendingProcess, DataReceivedEventArgs e ) {
        if ( e.Data.IsEmpty() )
            return;
        try {
            _logger.LogDebug( e.Data );
        }
        catch ( InvalidOperationException ) {
        }
        if ( _outputToMatch.Any( e.Data.Contains ) )
            _outputReceived.Set();
    }

    /// <summary>
    /// 获取命令调试文本
    /// </summary>
    public string GetDebugText() {
        return $"{_command} {_arguments}";
    }

    /// <summary>
    /// 执行PowerShell命令
    /// </summary>
    /// <param name="command">PowerShell命令,范例: Set-ExecutionPolicy RemoteSigned</param>
    /// <param name="workingDirectory">工作目录</param>
    public static void ExecutePowerShell( string command, string workingDirectory = null ) {
        using Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.CreateNoWindow = false;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.WorkingDirectory = workingDirectory;
        process.Start();
        process.StandardInput.WriteLine( $"powershell {command}" );
        process.StandardInput.WriteLine( "exit" );
        process.StandardInput.AutoFlush = true;
        process.WaitForExit();
    }
}