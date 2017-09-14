namespace Util.Logs {
    /// <summary>
    /// 日志格式化器
    /// </summary>
    public interface ILogFormat {
        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="content">日志内容</param>
        string Format( ILogContent content );
    }
}
