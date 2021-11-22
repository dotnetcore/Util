using System;
using Microsoft.Extensions.DependencyInjection;
using Util.Sessions;

namespace Util.Applications {
    /// <summary>
    /// 应用服务
    /// </summary>
    public abstract class ServiceBase : IService {
        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        protected ServiceBase( IServiceProvider serviceProvider ) {
            ServiceProvider = serviceProvider;
            Session = serviceProvider.GetService<ISession>() ?? NullSession.Instance;
        }

        /// <summary>
        /// 服务提供器
        /// </summary>
        protected IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 用户会话
        /// </summary>
        protected ISession Session { get; }
    }
}
