using Util.Logs;
using Util.Sessions;

namespace Util.Applications {
    /// <summary>
    /// 应用服务
    /// </summary>
    public abstract partial class ServiceBase : IService {
        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log => _log ?? (_log = GetLog() );

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog() {
            try {
                return Util.Logs.Log.GetLog( this );
            }
            catch {
                return Util.Logs.Log.Null;
            }
        }

        /// <summary>
        /// 用户会话
        /// </summary>
        public virtual ISession Session => Sessions.Session.Instance;
    }
}
