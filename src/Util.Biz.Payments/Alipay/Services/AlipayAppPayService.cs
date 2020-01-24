using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Abstractions;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Results;
using Util.Biz.Payments.Alipay.Services.Base;
using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝App支付服务
    /// </summary>
    public class AlipayAppPayService : AlipayPayServiceBase, IAlipayAppPayService {
        /// <summary>
        /// 初始化支付宝App支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayAppPayService( IAlipayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public async Task<string> PayAsync( AlipayAppPayRequest request ) {
            var result = await PayAsync( request.ToParam() );
            return result.Result;
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected override Task<AlipayResult> RequstResult( AlipayConfig config, AlipayParameterBuilder builder ) {
            var result = builder.Result( true );
            WriteLog( config, builder, result );
            return Task.FromResult( new AlipayResult { Result = result } );
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        protected override PayResult CreateResult( AlipayResult result ) {
            return new PayResult { Result = result.Result };
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod() {
            return "alipay.trade.app.pay";
        }
    }
}