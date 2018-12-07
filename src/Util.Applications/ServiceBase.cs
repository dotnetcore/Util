using Util.Logs;
using Util.Sessions;

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
            Session = Util.Security.Sessions.Session.Instance;
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
