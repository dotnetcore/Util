namespace Util.Domains.Sessions {
    /// <summary>
    /// 空用户上下文
    /// </summary>
    public class NullSession : ISession{
        /// <summary>
        /// 空用户上下文实例
        /// </summary>
        public static readonly ISession Instance = new NullSession();

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId => string.Empty;
    }
}
