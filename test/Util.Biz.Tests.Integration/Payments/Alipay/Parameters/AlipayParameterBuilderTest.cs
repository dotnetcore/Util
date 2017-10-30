using System;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay.Parameters {
    /// <summary>
    /// 支付宝参数生成器测试
    /// </summary>
    public class AlipayParameterBuilderTest : IDisposable {
        /// <summary>
        /// 输出
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 支付宝参数生成器
        /// </summary>
        private AlipayParameterBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayParameterBuilderTest( ITestOutputHelper output ) {
            _output = output;
            Time.SetTime( "2000-10-10 10:10:10" );
            _builder = new AlipayParameterBuilder( new AlipayConfig() );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 添加设置配置
        /// </summary>
        [Fact]
        public void TestConfig() {
            _builder = new AlipayParameterBuilder( new AlipayConfig { AppId = "a" } );
            _output.WriteLine( _builder.ToString() );
            Assert.Equal( "app_id=a&charset=utf-8&format=json&sign_type=RSA2&timestamp=2000-10-10 10:10:10&version=1.0", _builder.ToString() );
        }

        /// <summary>
        /// 添加应用Id
        /// </summary>
        [Fact]
        public void TestAppId() {
            _builder.AppId( "a" );
            Assert.Equal( "app_id=a&charset=utf-8&format=json&sign_type=RSA2&timestamp=2000-10-10 10:10:10&version=1.0", _builder.ToString() );
        }

        /// <summary>
        /// 添加请求方法
        /// </summary>
        [Fact]
        public void TestMethod() {
            _builder.Method( "a" );
            Assert.Equal( "charset=utf-8&format=json&method=a&sign_type=RSA2&timestamp=2000-10-10 10:10:10&version=1.0", _builder.ToString() );
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        [Fact]
        public void TestContent() {
            var contentBuilder = new AlipayContentBuilder();
            contentBuilder.OutTradeNo( "a" );
            _builder.Content( contentBuilder );
            Assert.Equal( "biz_content={\"out_trade_no\":\"a\"}&charset=utf-8&format=json&sign_type=RSA2&timestamp=2000-10-10 10:10:10&version=1.0", _builder.ToString() );
        }
    }
}
