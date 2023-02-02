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
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Data.Infrastructure.DapperServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 790;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

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
