using Moq;

namespace Util.Logging.Tests {
    /// <summary>
    /// 日志操作测试
    /// </summary>
    public partial class LogTest {
        /// <summary>
        /// 模拟日志
        /// </summary>
        private readonly Mock<ILoggerWrapper> _mockLogger;
        /// <summary>
        /// 日志操作
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LogTest() {
            _mockLogger = new Mock<ILoggerWrapper>();
            _log = new Log( _mockLogger.Object );
        }
    }
}
