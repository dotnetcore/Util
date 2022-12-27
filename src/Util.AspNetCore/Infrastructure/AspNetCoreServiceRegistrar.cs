using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Helpers;
using Util.Http;
using Util.SystemTextJson;

namespace Util.Infrastructure {
    /// <summary>
    /// AspNetCore服务注册器
    /// </summary>
    public class AspNetCoreServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 200;

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
                RegisterHttpContextAccessor( services );
                services.AddHttpClient();
                RegisterServiceLocator();
                RegisterSession( services );
                RegisterHttpClient( services );
                ConfigJsonOptions( services );
            } );
            return null;
        }

        /// <summary>
        /// 注册Http上下文访问器
        /// </summary>
        private void RegisterHttpContextAccessor( IServiceCollection services ) {
            var httpContextAccessor = new HttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor>( httpContextAccessor );
            Web.HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 注册服务定位器
        /// </summary>
        private void RegisterServiceLocator() {
            Ioc.SetServiceProviderAction( () => Web.ServiceProvider );
        }

        /// <summary>
        /// 注册用户会话
        /// </summary>
        private void RegisterSession( IServiceCollection services ) {
            services.TryAddSingleton<Util.Sessions.ISession, Util.Sessions.Session>();
        }

        /// <summary>
        /// 注册Http客户端
        /// </summary>
        private void RegisterHttpClient( IServiceCollection services ) {
            services.TryAddSingleton<IHttpClient, HttpClientService>();
        }

        /// <summary>
        /// 配置Json
        /// </summary>
        private void ConfigJsonOptions( IServiceCollection services ) {
            services.Configure( (Microsoft.AspNetCore.Mvc.JsonOptions options) => {
                options.JsonSerializerOptions.Converters.Add( new DateTimeJsonConverter() );
                options.JsonSerializerOptions.Converters.Add( new NullableDateTimeJsonConverter() );
            } );
        }
    }
}
