namespace Util.Domains.Sessions {
    /// <summary>
    /// 用户会话
    /// </summary>
    public interface ISession {
        /// <summary>
        /// 用户编号
        /// </summary>
        string UserId { get; }
    }
}
