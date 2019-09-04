using System.Diagnostics;
using Util.Logs.Abstractions;

namespace Util.Logs.Core {
    /// <summary>
    /// 空日志上下文
    /// </summary>
    public class NullLogContext : ILogContext {
        /// <summary>
        /// 空日志上下文实例
        /// </summary>
        public static readonly ILogContext Instance = new NullLogContext();
        /// <summary>
        /// 日志标识
        /// </summary>
        public string LogId => string.Empty;
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId => string.Empty;
        /// <summary>
        /// 计时器
        /// </summary>
        public Stopwatch Stopwatch => new Stopwatch();
        /// <summary>
        /// IP
        /// </summary>
        public string Ip => string.Empty;
        /// <summary>
        /// 主机
        /// </summary>
        public string Host => string.Empty;
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser => string.Empty;
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url => string.Empty;
        /// <summary>
        /// 排序
        /// </summary>
        public int Order => 0;

        /// <summary>
        /// 更新上下文
        /// </summary>
        public void UpdateContext()
        {
        }
    }
}
