using Util.Biz.Payments.Wechatpay.Signatures;
using Util.Signatures;
using Xunit;

namespace Util.Biz.Tests.Integration.Payments.Wechatpay.Signatures {
    /// <summary>
    /// 微信支付Md5签名服务测试
    /// </summary>
    public class Md5SignManagerTest {
        /// <summary>
        /// 微信支付Md5签名服务
        /// </summary>
        private readonly Md5SignManager _manager;

        /// <summary>
        /// 初始化微信支付Md5签名服务
        /// </summary>
        public Md5SignManagerTest() {
            _manager = new Md5SignManager( new SignKey("a") );
        }

        /// <summary>
        /// 签名
        /// </summary>
        [Fact]
        public void TestSign() {
            _manager.Add( "b", "2" );
            _manager.Add( "a", "1" );
            _manager.Add( "z", "3" );
            Assert.Equal( "E3D13010B5F19586B5F3C14B14D615BD", _manager.Sign() );
        }
    }
}
