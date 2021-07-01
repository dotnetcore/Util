using System;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        /// <param name="services">服务集合</param>
        /// <param name="configuration">配置</param>
        /// <param name="finder">类型查找器</param>
        public Action Register( IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration, ITypeFinder finder ) {
            var types = finder.Find<IAutoMapperConfig>();
            var instances = types.Select( type => Reflection.CreateInstance<IAutoMapperConfig>( type ) ).ToList();
            var expression = new MapperConfigurationExpression();
            instances.ForEach( t => t.Config( expression ) );
            var config = new MapperConfiguration( expression );
            var mapper = new ObjectMapper( config );
            ObjectMapperExtensions.SetMapper( mapper );
            services.AddSingleton<IObjectMapper>( mapper );
            return null;
        }
    }
}
