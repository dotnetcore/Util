using Util.Biz.Payments.Wechatpay.Signatures;
using Util.Signatures;
using Xunit;

namespace Util.Biz.Tests.Integration.Payments.Wechatpay.Signatures {
    /// <summary>
    /// 微信支付签名服务测试
    /// </summary>
    public class SignManagerTest {
        /// <summary>
        /// Md5签名
        /// </summary>
        [Fact]
        public void TestSign_Md5() {
            var manager = new Md5SignManager( new SignKey( "a" ) );
            manager.Add( "b", "2" );
            manager.Add( "a", "1" );
            manager.Add( "z", "3" );
            Assert.Equal( "E3D13010B5F19586B5F3C14B14D615BD", manager.Sign() );
        }

        /// <summary>
        /// HmacSha256签名
        /// </summary>
        [Fact]
        public void TestSign_HmacSha256() {
            var manager = new HmacSha256SignManager( new SignKey( "a" ) );
            manager.Add( "b", "2" );
            manager.Add( "a", "1" );
            manager.Add( "z", "3" );
            Assert.Equal( "4A251DD0AABE69956F77EFA679D8A3DD930B140F3CAF54A6E07F3C18B7E7296F", manager.Sign() );
        }
    }
}
