namespace Util.Domains.Sessions {
    /// <summary>
    /// 当前用户上下文
    /// </summary>
    public interface ISession {
        /// <summary>
        /// 用户编号
        /// </summary>
        string UserId { get; }
    }
}
