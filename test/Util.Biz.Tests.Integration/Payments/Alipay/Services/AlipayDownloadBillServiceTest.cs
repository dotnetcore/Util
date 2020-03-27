using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Xunit;

namespace Util.Biz.Tests.Integration.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝下载对账单服务测试
    /// </summary>
    public class AlipayDownloadBillServiceTest {
        /// <summary>
        /// 下载对账单测试
        /// </summary>
        [Fact(Skip = "更改支付配置后测试")]
        public async Task TestDownloadAsync() {
            var service = new AlipayDownloadBillService( new TestConfigProvider() );
            var request = new AlipayDownloadBillRequest { BillDate = "2016-1-1".ToDate(), IsMonth = true };
            var result = await service.DownloadAsync( request );
            Assert.NotNull( result.DownloadUrl );
            Assert.NotEmpty( result.Bills );
        }
    }
}
