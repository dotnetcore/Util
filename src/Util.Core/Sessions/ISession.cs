namespace Util.Sessions {
    /// <summary>
    /// 用户会话
    /// </summary>
    public interface ISession {
        /// <summary>
        /// 是否认证
        /// </summary>
        bool IsAuthenticated { get; }
        /// <summary>
        /// 用户标识
        /// </summary>
        string UserId { get; }
    }
}