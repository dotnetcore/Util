using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Validations;

namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付通知服务
    /// </summary>
    public interface INotifyService {
        /// <summary>
        /// 商户订单号
        /// </summary>
        string OrderId { get; }
        /// <summary>
        /// 支付订单号
        /// </summary>
        string TradeNo { get; }
        /// <summary>
        /// 支付金额
        /// </summary>
        decimal Money { get; }
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        string GetParam( string name );
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        T GetParam<T>( string name );
        /// <summary>
        /// 获取参数集合
        /// </summary>
        IDictionary<string, string> GetParams();
        /// <summary>
        /// 验证
        /// </summary>
        Task<ValidationResultCollection> ValidateAsync();
        /// <summary>
        /// 返回成功消息
        /// </summary>
        string Success();
        /// <summary>
        /// 返回失败消息
        /// </summary>
        string Fail();
    }
}
