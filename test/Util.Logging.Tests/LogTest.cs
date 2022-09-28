using Moq;

namespace Util.Logging.Tests {
    /// <summary>
    /// ��־��������
    /// </summary>
    public partial class LogTest {
        /// <summary>
        /// ģ����־
        /// </summary>
        private readonly Mock<ILoggerWrapper> _mockLogger;
        /// <summary>
        /// ��־����
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// ���Գ�ʼ��
        /// </summary>
        public LogTest() {
            _mockLogger = new Mock<ILoggerWrapper>();
            _log = new Log( _mockLogger.Object );
        }
    }
}
