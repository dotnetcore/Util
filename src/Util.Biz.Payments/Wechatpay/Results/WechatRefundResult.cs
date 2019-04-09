using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Signatures;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Parameters;
using Util.Validations;

namespace Util.Biz.Payments.Wechatpay.Results
{
    /// <summary>
    /// 微信退款结果
    /// </summary>
    public class WechatRefundResult : WechatpayResult
    {


        /// <summary>
        /// 初始化微信支付结果
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        /// <param name="response">xml响应消息</param>
        public WechatRefundResult(IWechatpayConfigProvider configProvider, string response)
        : base(configProvider, response)
        {

        }



        /// <summary>
        /// 写日志
        /// </summary>
        protected new void WriteLog()
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("微信退款返回")
                .Content("参数:")
                .Content(GetParams())
                .Content()
                .Content("原始响应:")
                .Content(Raw)
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
        /// <summary>
        /// 获取微信退款单号
        /// </summary>
        /// <returns></returns>
        public string GetRefundId()
        {
            return GetParam("refund_id");
        }
    }
}
