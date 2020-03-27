using TinyCsvParser.Mapping;
using Util.Biz.Payments.Alipay.Results;

namespace Util.Biz.Payments.Alipay.Services.CsvMappings {
    /// <summary>
    /// 支付宝对账单信息Csv映射
    /// </summary>
    public class AlipayBillInfoMapping : CsvMapping<AlipayBillInfo> {
        /// <summary>
        /// 初始化支付宝对账单信息Csv映射
        /// </summary>
        public AlipayBillInfoMapping() {
            MapProperty( 0, t => t.TradeId );
            MapProperty( 1, t => t.OrderId );
            MapProperty( 2, t => t.BusinessType );
            MapProperty( 3, t => t.TradeName );
            MapProperty( 4, t => t.CreationTime );
            MapProperty( 5, t => t.CompletionTime );
            MapProperty( 6, t => t.ShopNumber );
            MapProperty( 7, t => t.ShopName );
            MapProperty( 8, t => t.Operator );
            MapProperty( 9, t => t.Terminal );
            MapProperty( 10, t => t.Account );
            MapProperty( 11, t => t.OrderAmount );
            MapProperty( 12, t => t.MerchantReceipt );
            MapProperty( 13, t => t.AlipayRedEnvelopes );
            MapProperty( 14, t => t.JifenBao );
            MapProperty( 15, t => t.AlipayDiscount );
            MapProperty( 16, t => t.MerchantDiscount );
            MapProperty( 17, t => t.CouponAmount );
            MapProperty( 18, t => t.CouponName );
            MapProperty( 19, t => t.MerchantRedEnvelopes );
            MapProperty( 20, t => t.CardAmount );
            MapProperty( 21, t => t.RefundNumber );
            MapProperty( 22, t => t.ServiceCharge );
            MapProperty( 23, t => t.ShareProfit );
            MapProperty( 24, t => t.Remarks );
        }
    }
}
