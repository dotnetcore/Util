namespace Util.Logging.Tests {
    /// <summary>
    /// 日志上下文访问器
    /// </summary>
    public class LogContextAccessor : ILogContextAccessor {
        /// <summary>
        /// 日志上下文键名
        /// </summary>
        public const string LogContextKey = "Util.Logging.LogContext";

        /// <summary>
        /// 日志上下文
        /// </summary>
        public LogContext Context {
            get {
                var slot = System.Threading.Thread.GetNamedDataSlot( LogContextKey );
                return Util.Helpers.Convert.To<LogContext>( System.Threading.Thread.GetData( slot ) );
            }
            set {
                var slot = System.Threading.Thread.GetNamedDataSlot( LogContextKey );
                System.Threading.Thread.SetData( slot, value );
            }
        }
    }
}
