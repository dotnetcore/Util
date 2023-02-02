using System;
using Microsoft.Extensions.DependencyInjection;
using Util.Infrastructure;
using Util.Templates.HandlebarsDotNet;

namespace Util.Templates.Infrastructure {
    /// <summary>
    /// Handlebars模板引擎服务注册器
    /// </summary>
    public class HandlebarsServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Templates.Infrastructure.HandlebarsServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 620;

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
                services.AddSingleton<ITemplateEngine, HandlebarsTemplateEngine>();
                services.AddSingleton<IHandlebarsTemplateEngine, HandlebarsTemplateEngine>();
            } );
            return null;
        }
    }
}
