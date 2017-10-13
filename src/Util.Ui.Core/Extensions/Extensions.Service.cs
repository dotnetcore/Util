using Microsoft.Extensions.DependencyInjection;
using Util.Ui.Services;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加组件服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddUi( this IServiceCollection services ) {
            services.CheckNull( nameof(services) );
            services.AddSingleton<IUiService,UiService>();
            return services;
        }
    }
}
