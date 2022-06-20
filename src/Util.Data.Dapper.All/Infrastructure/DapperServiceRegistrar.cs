using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Data.Metadata;
using Util.Infrastructure;
using Util.Reflections;

namespace Util.Data.Infrastructure {
    /// <summary>
    /// Dapper服务注册器
    /// </summary>
    public class DapperServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 790;

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
        /// <param name="hostBuilder">主机生成器</param>
        /// <param name="finder">类型查找器</param>
        public Action Register( IHostBuilder hostBuilder, ITypeFinder finder ) {
            hostBuilder.ConfigureServices( ( context, services ) => {
                services.TryAddSingleton<IMetadataServiceFactory, MetadataServiceFactory>();
                services.TryAddSingleton<ITypeConverterFactory, TypeConverterFactory>();
            } );
            return null;
        }
    }
}
