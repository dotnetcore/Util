namespace Util.Logs {
    /// <summary>
    /// 日志服务
    /// </summary>
    public interface ILogManager {
        /// <summary>
        /// 获取日志操作
        /// </summary>
        ILog GetLog();
    }
}
