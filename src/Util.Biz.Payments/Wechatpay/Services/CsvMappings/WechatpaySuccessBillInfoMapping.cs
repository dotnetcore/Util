using TinyCsvParser.Mapping;
using Util.Biz.Payments.Wechatpay.Results;

namespace Util.Biz.Payments.Wechatpay.Services.CsvMappings {
    /// <summary>
    /// 微信支付成功支付对账单信息Csv映射
    /// </summary>
    public class WechatpaySuccessBillInfoMapping : CsvMapping<WechatpayBillInfo> {
        /// <summary>
        /// 初始化微信支付成功支付对账单信息Csv映射
        /// </summary>
        public WechatpaySuccessBillInfoMapping() {
            MapProperty( 0, t => t.TransactionTime,new RemovePrefixStringConvert() );
            MapProperty( 1, t => t.AppId, new RemovePrefixStringConvert() );
            MapProperty( 2, t => t.MerchantId, new RemovePrefixStringConvert() );
            MapProperty( 3, t => t.SubMerchantId, new RemovePrefixStringConvert() );
            MapProperty( 4, t => t.DeviceNumber, new RemovePrefixStringConvert() );
            MapProperty( 5, t => t.TradeId, new RemovePrefixStringConvert() );
            MapProperty( 6, t => t.OrderId, new RemovePrefixStringConvert() );
            MapProperty( 7, t => t.OpenId, new RemovePrefixStringConvert() );
            MapProperty( 8, t => t.TradeType, new RemovePrefixStringConvert() );
            MapProperty( 9, t => t.TradeStatus, new RemovePrefixStringConvert() );
            MapProperty( 10, t => t.Bank, new RemovePrefixStringConvert() );
            MapProperty( 11, t => t.CurrencyType, new RemovePrefixStringConvert() );
            MapProperty( 12, t => t.TotalAmount, new RemovePrefixDecimalConvert() );
            MapProperty( 13, t => t.CouponAmount, new RemovePrefixDecimalConvert() );
            MapProperty( 14, t => t.TradeName, new RemovePrefixStringConvert() );
            MapProperty( 15, t => t.MerchantAttach, new RemovePrefixStringConvert() );
            MapProperty( 16, t => t.Commission, new RemovePrefixDecimalConvert() );
            MapProperty( 17, t => t.Rate, new RemovePrefixStringConvert() );
        }
    }
}
