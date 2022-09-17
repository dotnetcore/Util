using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Util.Applications.Logging;
using Util.Infrastructure;
using Util.Logging;

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
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
            serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                services.AddSingleton<ILogContextAccessor, LogContextAccessor>();
                services.AddSingleton<IStartupFilter, LogContextStartupFilter>();
                services.Configure<ApiBehaviorOptions>( options => {
                    options.SuppressModelStateInvalidFilter = false;
                    var builtInFactory = options.InvalidModelStateResponseFactory;
                    options.InvalidModelStateResponseFactory = actionContext => {
                        var log = actionContext.HttpContext.RequestServices.GetRequiredService<ILogger<WebApiServiceRegistrar>>();
                        if ( actionContext.ModelState.IsValid == false ) {
                            foreach ( var state in actionContext.ModelState ) {
                                foreach ( var error in state.Value.Errors )
                                    log.LogError( error.Exception, "模型绑定失败,ErrorMessage: {ErrorMessage}", error.ErrorMessage );
                            }
                        }
                        return builtInFactory( actionContext );
                    };
                } );
            } );
            return null;
        }
    }
}
