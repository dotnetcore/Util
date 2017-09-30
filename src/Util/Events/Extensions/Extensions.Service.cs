using Microsoft.Extensions.DependencyInjection;
using Util.Events.Handlers;

namespace Util.Events.Extensions {
    /// <summary>
    /// 事件总线扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 注册事件总线服务 - 内存同步事件
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddEventBus( this IServiceCollection services ) {
            services.AddSingleton<IEventHandlerManager, DefaultEventHandlerManager>();
            services.AddSingleton<IEventBus, DefaultEventBus>();
        }
    }
}
