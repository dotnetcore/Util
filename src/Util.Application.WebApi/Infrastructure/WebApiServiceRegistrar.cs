using System;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
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
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Applications.Infrastructure.WebApiServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 1210;

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
                services.AddSingleton<ILogContextAccessor, LogContextAccessor>();
                services.AddSingleton<IStartupFilter, LogContextStartupFilter>();
                ConfigApiBehaviorOptions( services );
            } );
            return null;
        }

        /// <summary>
        /// 配置ApiBehavior
        /// </summary>
        private void ConfigApiBehaviorOptions( IServiceCollection services ) {
            services.Configure<ApiBehaviorOptions>( options => {
                options.SuppressModelStateInvalidFilter = false;
                var builtInFactory = options.InvalidModelStateResponseFactory;
                options.InvalidModelStateResponseFactory = actionContext => {
                    var log = actionContext.HttpContext.RequestServices.GetRequiredService<ILogger<WebApiServiceRegistrar>>();
                    if ( actionContext.ModelState.IsValid )
                        return builtInFactory( actionContext );
                    var error = GetModelError( actionContext );
                    log.LogError( error.Exception, "Model Binding Failed,ErrorMessage: {ErrorMessage}", error.ErrorMessage );
                    var message = GetLocalizedMessages( actionContext.HttpContext, error.ErrorMessage );
                    return GetResult( actionContext.HttpContext, StateCode.Fail, message, 200 );
                };
            } );
        }

        /// <summary>
        /// 获取模型错误
        /// </summary>
        private ModelError GetModelError( ActionContext actionContext ) {
            foreach ( var state in actionContext.ModelState ) {
                foreach ( var error in state.Value.Errors )
                    return error;
            }
            return null;
        }

        /// <summary>
        /// 获取本地化异常消息
        /// </summary>
        protected virtual string GetLocalizedMessages( HttpContext context, string message ) {
            var stringLocalizerFactory = context.RequestServices.GetService<IStringLocalizerFactory>();
            if ( stringLocalizerFactory == null )
                return message;
            var assemblyName = new AssemblyName( GetType().Assembly.FullName );
            var stringLocalizer = stringLocalizerFactory.Create( "Warning", assemblyName.Name );
            var localizedString = stringLocalizer[message];
            if ( localizedString.ResourceNotFound == false )
                return localizedString.Value;
            stringLocalizer = context.RequestServices.GetService<IStringLocalizer>();
            if ( stringLocalizer == null )
                return message;
            return stringLocalizer[message];
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        protected virtual IActionResult GetResult( HttpContext context, string code, string message, int? httpStatusCode ) {
            var resultFactory = context.RequestServices.GetService<IResultFactory>();
            if ( resultFactory == null )
                return new Result( code, message, null, httpStatusCode );
            return resultFactory.CreateResult( code, message, null, httpStatusCode );
        }
    }
}
