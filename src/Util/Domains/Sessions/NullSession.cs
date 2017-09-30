namespace Util.Domains.Sessions {
    /// <summary>
    /// 空用户会话
    /// </summary>
    public class NullSession : ISession {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId => string.Empty;
    }
}
