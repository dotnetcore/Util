using Util.Sessions;

namespace Util.Datas.Tests.Commons {
    /// <summary>
    /// 用户会话
    /// </summary>
    public class Session : ISession {
        /// <summary>
        /// 初始化用户会话
        /// </summary>
        public Session( string userId ) {
            UserId = userId;
        }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated => throw new System.NotImplementedException();
    }
}