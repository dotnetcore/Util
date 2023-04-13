using System;
using Util.Sessions;

namespace Util.FileStorage {
    /// <summary>
    /// 文件名处理器工厂
    /// </summary>
    public class FileNameProcessorFactory : IFileNameProcessorFactory {
        /// <summary>
        /// 用户会话
        /// </summary>
        private readonly ISession _session;

        /// <summary>
        /// 初始化文件名处理器工厂
        /// </summary>
        /// <param name="session">用户会话</param>
        public FileNameProcessorFactory( ISession session ) {
            _session = session ?? NullSession.Instance;
        }

        /// <inheritdoc />
        public IFileNameProcessor CreateProcessor( string policy ) {
            if ( policy.IsEmpty() )
                return new FileNameProcessor();
            if ( policy.ToLowerInvariant() == UserTimeFileNameProcessor.Policy )
                return new UserTimeFileNameProcessor( _session );
            throw new NotImplementedException( $"文件名处理策略 {policy} 未实现." );
        }
    }
}