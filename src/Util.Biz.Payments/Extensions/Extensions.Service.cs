using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Biz.Payments.Alipay.Abstractions;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Factories;

namespace Util.Biz.Payments.Extensions {
    /// <summary>
    /// 支付扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 注册支付操作
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction">配置操作</param>
        public static void AddPay( this IServiceCollection services, Action<PayOptions> setupAction ) {
            services.TryAddScoped<IPayFactory, PayFactory>();
            var options = new PayOptions();
            setupAction?.Invoke( options );
            services.TryAddSingleton<IAlipayConfigProvider>( new AlipayConfigProvider( options.AlipayOptions ) );
            services.TryAddScoped<IAlipayNotifyService, AlipayNotifyService>();
            services.TryAddScoped<IAlipayReturnService, AlipayReturnService>();
        }
    }
}
