using Util.Helpers;
using Util.Sessions;

namespace Util.FileStorage {
    /// <summary>
    /// 基于用户标识和时间的文件名处理器
    /// </summary>
    public class UserTimeFileNameProcessor : IFileNameProcessor {
        /// <summary>
        /// 策略名称
        /// </summary>
        public const string Policy = "usertime";
        /// <summary>
        /// 用户会话
        /// </summary>
        private readonly ISession _session;

        /// <summary>
        /// 初始化基于用户标识和时间的文件名处理器
        /// </summary>
        /// <param name="session">用户会话</param>
        public UserTimeFileNameProcessor( ISession session ) {
            _session = session ?? NullSession.Instance;
        }

        /// <inheritdoc />
        public ProcessedName Process( string fileName ) {
            var result = $"{GetUserId()}{GetTime()}{fileName}";
            return new ProcessedName( result );
        }

        /// <summary>
        /// 获取用户标识
        /// </summary>
        private string GetUserId() {
            if ( _session.UserId.IsEmpty() )
                return null;
            return $"{_session.UserId}/";
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        private string GetTime() {
            return $"{Time.Now:yyyy-MM-dd-HH-mm-ss-fff}/";
        }
    }
}
