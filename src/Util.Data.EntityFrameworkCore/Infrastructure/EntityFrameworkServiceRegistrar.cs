using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.Data.EntityFrameworkCore.Filters;
using Util.Domain;
using Util.Infrastructure;
using Util.Reflections;

namespace Util.Data.EntityFrameworkCore.Infrastructure {
    /// <summary>
    /// EntityFrameworkCore服务注册器
    /// </summary>
    public class EntityFrameworkServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 710;

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
            FilterManager.AddFilterType<IDelete>();
            return null;
        }
    }
}
