using Util.Domains.Sessions;
using Util.Logs;

namespace Util.Applications {
    /// <summary>
    /// 应用服务
    /// </summary>
    public abstract class ServiceBase : IService {
        /// <summary>
        /// 初始化应用服务
        /// </summary>
        protected ServiceBase() {
            Log = Util.Logs.Log.Null;
            Session = Util.Domains.Sessions.Session.Null;
        }

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log { get; set; }

        /// <summary>
        /// 用户会话
        /// </summary>
        public ISession Session { get; set; }
    }
}
