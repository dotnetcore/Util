namespace Util.Domains.Sessions {
    /// <summary>
    /// 空用户上下文
    /// </summary>
    public class NullSession : ISession{
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId => string.Empty;
    }
}
