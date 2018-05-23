using Util.Biz.Payments.Alipay.Parameters;
using Util.Biz.Payments.Core;
using Xunit;

namespace Util.Biz.Tests.Integration.Payments.Alipay.Parameters {
    /// <summary>
    /// 支付宝内容参数生成器测试
    /// </summary>
    public class AlipayContentBuilderTest {
        /// <summary>
        /// 支付宝内容参数生成器
        /// </summary>
        private readonly AlipayContentBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayContentBuilderTest() {
            _builder = new AlipayContentBuilder();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        [Fact]
        public void TestInit() {
            _builder.Init( new PayParam { OrderId = "a",AuthCode = "b",Subject = "c",Timeout = 2,Money = 88.88M} );
            Assert.Equal( "out_trade_no=a&subject=c&total_amount=88.88&timeout_express=2m", _builder.ToString() );
        }

        /// <summary>
        /// 添加商户订单号
        /// </summary>
        [Fact]
        public void TestOutTradeNo() {
            _builder.OutTradeNo( "a" );
            Assert.Equal( "out_trade_no=a", _builder.ToString() );
        }

        /// <summary>
        /// 设置场景
        /// </summary>
        [Fact]
        public void TestScene() {
            _builder.Scene( "a" );
            Assert.Equal( "scene=a", _builder.ToString() );
        }

        /// <summary>
        /// 设置用户付款授权码
        /// </summary>
        [Fact]
        public void TestAuthCode() {
            _builder.AuthCode( "a" );
            Assert.Equal( "auth_code=a", _builder.ToString() );
        }

        /// <summary>
        /// 设置订单标题
        /// </summary>
        [Fact]
        public void TestSubject() {
            _builder.Subject( "a" );
            Assert.Equal( "subject=a", _builder.ToString() );
        }

        /// <summary>
        /// 设置支付超时
        /// </summary>
        [Fact]
        public void TestTimeoutExpress() {
            _builder.TimeoutExpress( 2 );
            Assert.Equal( "timeout_express=2m", _builder.ToString() );
        }

        /// <summary>
        /// 设置支付金额
        /// </summary>
        [Fact]
        public void TestTotalAmount() {
            _builder.TotalAmount( 88.88M );
            Assert.Equal( "total_amount=88.88", _builder.ToString() );
        }
    }
}
