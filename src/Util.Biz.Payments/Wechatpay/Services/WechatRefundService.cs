using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Parameters;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Exceptions;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Biz.Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信退款
    /// </summary>
    public class WechatRefundService : IWechatRefundService
    {
        /// <summary>
        /// 微信配置提供器
        /// </summary>
        private IWechatpayConfigProvider ConfigProvider { get; set; }
        /// <summary>
        /// 证书
        /// </summary>
        private string Cert { get; set; }
        /// <summary>
        /// 证书密码
        /// </summary>
        private string Password { get; set; }

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSend { get; set; } = true;

        /// <summary>
        /// 初始化微信支付退款服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatRefundService(IWechatpayConfigProvider provider)
        {
            ConfigProvider = provider;
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="request">退款参数</param>
        /// <returns></returns>
        public async Task<RefundResult> RefundAsync(WechatRefundRequest request)
        {
            var param = request.ToParam();
            var config = await ConfigProvider.GetConfigAsync();
            if (param.Password.IsEmpty())
                param.Password = config.MerchantId;
            Validate(config, param);
            var builder = new WechatRefundParameterBuilder(config);
            Config(builder, param);
            Cert = param.Cert;
            Password = param.Password;
          return  await RequstResult(config, builder);
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate(WechatpayConfig config, RefundParam param)
        {
            config.CheckNull(nameof(config));
            param.CheckNull(nameof(param));
            config.Validate();
            param.Validate();
            ValidateParam(param);
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected void ValidateParam(RefundParam param)
        {
            if (param.TransactionId.IsEmpty() && param.OrderId.IsEmpty())
                throw new Warning("商户订单号和微信订单号必须设置一个");
            if (param.Cert.IsEmpty())
                throw new Exception("证书路径不能为空!");
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected void Config(WechatRefundParameterBuilder builder, RefundParam param)
        {
            builder.Init(param);
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected virtual async Task<RefundResult> RequstResult(WechatpayConfig config, WechatRefundParameterBuilder builder)
        {
            var response = await Request(config, builder);
            var result = new WechatRefundResult(ConfigProvider, response);
            WriteLog(config, builder, result);
            return await CreateResult(config, builder, result);
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> Request(WechatpayConfig config, WechatRefundParameterBuilder builder)
        {
            if (IsSend == false)
                return string.Empty;
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            };
            var certificate = new X509Certificate2(Cert, Password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
            handler.ClientCertificates.Add(certificate);
            var http = new HttpClient(handler) { Timeout = new TimeSpan(0, 0, 15) };
            var request = new HttpRequestMessage(HttpMethod.Post, config.GetRefundUrl())
            {
                Content = new StringContent(builder.ToXml(), System.Text.Encoding.UTF8, "text/xml")
            };
            var result = await http.SendAsync(request).Result.Content.ReadAsStringAsync();
            return result;
        }

        /// <summary>
        /// 创建退款结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual async Task<RefundResult> CreateResult(WechatpayConfig config, WechatRefundParameterBuilder builder, WechatRefundResult result)
        {
            var success = (await result.ValidateAsync()).IsValid;
            return new RefundResult(success, result.GetPrepayId(), result.Raw)
            {
                Parameter = builder.ToString(),
                Message = result.GetReturnMessage(),
                Result = success ? GetResult(config, builder, result) : null
            };
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected string GetResult(WechatpayConfig config, WechatRefundParameterBuilder builder, WechatRefundResult result)
        {
            return new WechatpayParameterBuilder(config)
                .Add("appId", config.AppId)
                .Add("timeStamp", Time.GetUnixTimestamp().SafeString())
                .Add("nonceStr", Id.Guid())
                .Add("signType", config.SignType.Description())
                .SignParamName("paySign")
                .ToJson();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog(WechatpayConfig config, WechatRefundParameterBuilder builder, WechatpayResult result)
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("微信退款")
                .Content($"支付网关 : {config.GetOrderUrl()}")
                .Content("请求参数:")
                .Content(builder.ToXml())
                .Content()
                .Content("返回结果:")
                .Content(result.GetParams())
                .Content()
                .Content("原始响应: ")
                .Content(result.Raw)
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog()
        {
            try
            {
                return Log.GetLog(WechatpayConst.TraceLogName);
            }
            catch
            {
                return Log.Null;
            }
        }
    }
}
