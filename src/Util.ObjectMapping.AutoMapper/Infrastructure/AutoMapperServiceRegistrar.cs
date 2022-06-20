using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Helpers;
using Util.Infrastructure;
using Util.Reflections;

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
        /// <param name="hostBuilder">主机生成器</param>
        /// <param name="finder">类型查找器</param>
        public Action Register( IHostBuilder hostBuilder, ITypeFinder finder ) {
            var types = finder.Find<IAutoMapperConfig>();
            var instances = types.Select( type => Reflection.CreateInstance<IAutoMapperConfig>( type ) ).ToList();
            var expression = new MapperConfigurationExpression();
            instances.ForEach( t => t.Config( expression ) );
            var mapper = new ObjectMapper( expression );
            ObjectMapperExtensions.SetMapper( mapper );
            hostBuilder.ConfigureServices( ( context, services ) => {
                services.AddSingleton<IObjectMapper>( mapper );
            } );
            return null;
        }
    }
}
