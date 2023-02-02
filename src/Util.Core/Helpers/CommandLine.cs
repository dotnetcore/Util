using System;
using System.Diagnostics;
using System.Text;

namespace Util.Helpers {
    /// <summary>
    /// 命令行操作
    /// </summary>
    public class CommandLine {
        /// <summary>
        /// 命令,范例: dotnet
        /// </summary>
        private string _command;
        /// <summary>
        /// 命令参数,范例: --info
        /// </summary>
        private string _arguments;
        /// <summary>
        /// 是否重定向标准输出流
        /// </summary>
        private bool _redirectStandardOutput;
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
        /// 初始化命令行操作
        /// </summary>
        public CommandLine() {
            _redirectStandardOutput = true;
            _outputEncoding = Encoding.UTF8;
            _useShellExecute = false;
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
        /// 设置命令
        /// </summary>
        /// <param name="command">命令,范例: dotnet</param>
        public CommandLine Command( string command ) {
            _command = command;
            return this;
        }

        /// <summary>
        /// 设置命令参数
        /// </summary>
        /// <param name="arguments">命令参数,范例: --info</param>
        public CommandLine Arguments( string arguments  ) {
            _arguments = arguments;
            return this;
        }

        /// <summary>
        /// 设置重定向标准输出流
        /// </summary>
        /// <param name="value">是否重定向标准输出流,默认值: true,注意: 如果要设置UseShellExecute为 false，则必须将RedirectStandardOutput设置为true</param>
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
        /// 执行命令行
        /// </summary>
        public void Execute() {
            var info = CreateProcessStartInfo();
            Process.Start( info );
        }

        /// <summary>
        /// 创建进程启动信息
        /// </summary>
        private ProcessStartInfo CreateProcessStartInfo() {
            if ( _command.IsEmpty() )
                throw new ArgumentException( "命令未设置" );
            return new ProcessStartInfo( _command, _arguments ) {
                RedirectStandardOutput = _redirectStandardOutput,
                StandardOutputEncoding = _outputEncoding,
                UseShellExecute = _useShellExecute,
                WorkingDirectory = _workingDirectory
            };
        }

        /// <summary>
        /// 执行命令行,并返回响应结果
        /// </summary>
        public string ExecuteResult() {
            var info = CreateProcessStartInfo();
            var process = Process.Start( info );
            return process == null ? null : GetResult( process );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Process process ) {
            if ( _redirectStandardOutput == false )
                return null;
            var result = new StringBuilder();
            using var reader = process.StandardOutput;
            while ( !reader.EndOfStream ) {
                result.AppendLine( reader.ReadLine() );
            }
            if ( !process.HasExited )
                process.Kill();
            return result.ToString();
        }
    }
}
