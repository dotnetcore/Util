using Util.Dependency;

namespace Util.Sessions {
    /// <summary>
    /// 用户会话
    /// </summary>
    public interface ISession : ISingletonDependency {
        /// <summary>
        /// 用户标识
        /// </summary>
        string UserId { get; }
    }
}