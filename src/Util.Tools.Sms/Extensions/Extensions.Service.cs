using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Tools.Sms.LuoSiMao;

namespace Util.Tools.Sms.Extensions {
    /// <summary>
    /// 短信服务扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 注册LuoSiMao短信服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="key">密钥</param>
        public static void AddLuoSiMao( this IServiceCollection services, string key ) {
            services.TryAddSingleton<ISmsConfigProvider>( new SmsConfigProvider( key ) );
        }
    }
}
