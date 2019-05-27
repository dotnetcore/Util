using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Biz.Payments.Alipay.Abstractions;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Factories;
using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Services;

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
            var options = new PayOptions();
            setupAction?.Invoke( options );
            services.TryAddSingleton<IAlipayConfigProvider>( new AlipayConfigProvider( options.AlipayOptions ) );
            services.TryAddSingleton<IWechatpayConfigProvider>( new WechatpayConfigProvider( options.WechatpayOptions ) );
            services.TryAddScoped<IPayFactory, PayFactory>();
            services.TryAddScoped<IAlipayNotifyService, AlipayNotifyService>();
            services.TryAddScoped<IAlipayReturnService, AlipayReturnService>();
            services.TryAddScoped<IWechatpayNotifyService, WechatpayNotifyService>();
            services.TryAddScoped<IWechatpayRefundNotifyService, WechatpayRefundNotifyService>();
        }

        /// <summary>
        /// 注册支付操作
        /// </summary>
        /// <typeparam name="TAlipayConfigProvider">支付宝配置提供器</typeparam>
        /// <typeparam name="TWechatpayConfigProvider">微信配置提供器</typeparam>
        /// <param name="services">服务集合</param>
        public static void AddPay<TAlipayConfigProvider, TWechatpayConfigProvider>( this IServiceCollection services )
            where TAlipayConfigProvider : class, IAlipayConfigProvider
            where TWechatpayConfigProvider : class, IWechatpayConfigProvider {
            services.TryAddScoped<IAlipayConfigProvider, TAlipayConfigProvider>();
            services.TryAddScoped<IWechatpayConfigProvider, TWechatpayConfigProvider>();
            services.TryAddScoped<IPayFactory, PayFactory>();
            services.TryAddScoped<IAlipayNotifyService, AlipayNotifyService>();
            services.TryAddScoped<IAlipayReturnService, AlipayReturnService>();
            services.TryAddScoped<IWechatpayNotifyService, WechatpayNotifyService>();
            services.TryAddScoped<IWechatpayRefundNotifyService, WechatpayRefundNotifyService>();
        }

        /// <summary>
        /// 注册支付宝支付操作
        /// </summary>
        /// <typeparam name="TAlipayConfigProvider">支付宝配置提供器</typeparam>
        /// <param name="services">服务集合</param>
        public static void AddAlipay<TAlipayConfigProvider>( this IServiceCollection services ) where TAlipayConfigProvider :class, IAlipayConfigProvider {
            services.TryAddScoped<IAlipayConfigProvider,TAlipayConfigProvider>();
            services.TryAddScoped<IPayFactory, PayFactory>();
            services.TryAddScoped<IAlipayNotifyService, AlipayNotifyService>();
            services.TryAddScoped<IAlipayReturnService, AlipayReturnService>();
        }

        /// <summary>
        /// 注册微信支付操作
        /// </summary>
        /// <typeparam name="TWechatpayConfigProvider">微信配置提供器</typeparam>
        /// <param name="services">服务集合</param>
        public static void AddWechatpay<TWechatpayConfigProvider>( this IServiceCollection services ) where TWechatpayConfigProvider : class, IWechatpayConfigProvider {
            services.TryAddScoped<IWechatpayConfigProvider, TWechatpayConfigProvider>();
            services.TryAddScoped<IPayFactory, PayFactory>();
            services.TryAddScoped<IWechatpayNotifyService, WechatpayNotifyService>();
            services.TryAddScoped<IWechatpayRefundNotifyService, WechatpayRefundNotifyService>();
        }
    }
}
