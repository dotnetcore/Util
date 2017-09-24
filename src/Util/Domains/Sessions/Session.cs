namespace Util.Domains.Sessions {
    /// <summary>
    /// 用户会话
    /// </summary>
    public class Session : ISession {
        /// <summary>
        /// 初始化用户会话
        /// </summary>
        /// <param name="userId">用户编号</param>
        public Session( string userId ) {
            UserId = userId;
        }

        /// <summary>
        /// 空用户会话
        /// </summary>
        public static readonly ISession Null = new NullSession();

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; }
    }
}
