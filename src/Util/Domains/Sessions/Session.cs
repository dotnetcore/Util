namespace Util.Domains.Sessions {
    /// <summary>
    /// 用户上下文
    /// </summary>
    public class Session : ISession {
        /// <summary>
        /// 初始化用户上下文
        /// </summary>
        /// <param name="userId">用户编号</param>
        public Session( string userId ) {
            UserId = userId;
        }

        /// <summary>
        /// 空用户上下文
        /// </summary>
        public static ISession Null => NullSession.Instance;

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; }
    }
}
