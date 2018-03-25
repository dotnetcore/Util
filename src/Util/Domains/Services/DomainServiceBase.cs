using Util.Domains.Sessions;
using Util.Logs;
using Util.Logs.Core;

namespace Util.Domains.Services {
    /// <summary>
    /// 领域服务
    /// </summary>
    public class DomainServiceBase : IDomainService {
        /// <summary>
        /// 初始化领域服务
        /// </summary>
        public DomainServiceBase() {
            Logger = NullLog.Instance;
            Session = Util.Domains.Sessions.Session.Null;
        }

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Logger { get; set; }

        /// <summary>
        /// 用户会话
        /// </summary>
        public ISession Session { get; set; }
    }
}
