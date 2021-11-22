using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.Applications.Logging;
using Util.Infrastructure;
using Util.Logging;
using Util.Reflections;

namespace Util.Applications.Infrastructure {
    /// <summary>
    /// Web Api服务注册器
    /// </summary>
    public class WebApiServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 1210;

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => GetId();

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( GetId() );

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configuration">配置</param>
        /// <param name="finder">类型查找器</param>
        public Action Register( IServiceCollection services, IConfiguration configuration, ITypeFinder finder ) {
            services.AddSingleton<ILogContextAccessor, LogContextAccessor>();
            services.AddSingleton<IStartupFilter, LogContextStartupFilter>();
            return null;
        }
    }
}
