using Microsoft.Extensions.DependencyInjection;
using Util.Events.Handlers;

namespace Util.Events.Default {
    /// <summary>
    /// 事件总线扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 注册事件总线服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddEventBus( this IServiceCollection services ) {
            return services.AddSingleton<IEventHandlerManager, EventHandlerManager>()
                .AddSingleton<IEventBus, Util.Events.Default.EventBus>();
        }
    }
}
