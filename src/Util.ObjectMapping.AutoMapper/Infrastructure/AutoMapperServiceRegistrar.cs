using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Util.Helpers;
using Util.Infrastructure;

namespace Util.ObjectMapping.Infrastructure {
    /// <summary>
    /// AutoMapper服务注册器
    /// </summary>
    public class AutoMapperServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 300;

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
            var types = serviceContext.TypeFinder.Find<IAutoMapperConfig>();
            var instances = types.Select( type => Reflection.CreateInstance<IAutoMapperConfig>( type ) ).ToList();
            var expression = new MapperConfigurationExpression();
            instances.ForEach( t => t.Config( expression ) );
            var mapper = new ObjectMapper( expression );
            ObjectMapperExtensions.SetMapper( mapper );
            serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                services.AddSingleton<IObjectMapper>( mapper );
            } );
            return null;
        }
    }
}
