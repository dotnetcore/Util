using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Data.Metadata;
using Util.Infrastructure;

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
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
            serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                services.TryAddSingleton<IMetadataServiceFactory, MetadataServiceFactory>();
                services.TryAddSingleton<ITypeConverterFactory, TypeConverterFactory>();
            } );
            return null;
        }
    }
}
