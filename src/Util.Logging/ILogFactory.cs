using System;

namespace Util.Logging {
    /// <summary>
    /// 日志操作工厂
    /// </summary>
    public interface ILogFactory {
        /// <summary>
        /// 创建日志操作
        /// </summary>
        /// <param name="categoryName">日志类别</param>
        ILog CreateLog( string categoryName );
        /// <summary>
        /// 创建日志操作
        /// </summary>
        /// <param name="type">日志类别类型</param>
        ILog CreateLog( Type type );
    }
}
