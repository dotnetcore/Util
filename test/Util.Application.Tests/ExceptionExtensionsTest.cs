using System;
using AspectCore.DynamicProxy;
using Util.Exceptions;
using Util.Properties;
using Xunit;

namespace Util.Applications {
    /// <summary>
    /// 异常扩展测试
    /// </summary>
    public class ExceptionExtensionsTest {
        /// <summary>
        /// 测试获取原始异常
        /// </summary>
        [Fact]
        public void TestGetRawException() {
            var exception = new AspectInvocationException( null, new Exception( "a" ) );
            Assert.Equal( "a",exception.GetRawException().Message );
        }

        /// <summary>
        /// 测试获取异常提示 - 验证空
        /// </summary>
        [Fact]
        public void TestGetPrompt_Null() {
            Exception exception = null;
            Assert.Null( exception.GetPrompt() );
        }

        /// <summary>
        /// 测试获取异常提示 - 生产环境隐藏系统异常消息
        /// </summary>
        [Fact]
        public void TestGetPrompt_IsProduction_True() {
            var exception = new Exception( "a" );
            Assert.Equal( R.SystemError, exception.GetPrompt( true ) );
        }

        /// <summary>
        /// 测试获取异常提示 - 非生产环境显示系统异常消息
        /// </summary>
        [Fact]
        public void TestGetPrompt_IsDevelopment_False() {
            var exception = new Exception( "a" );
            Assert.Equal( "a", exception.GetPrompt() );
        }

        /// <summary>
        /// 测试获取异常提示 - Warning异常生产环境正常显示
        /// </summary>
        [Fact]
        public void TestGetPrompt_Warning_IsProduction_True() {
            var exception = new Warning( "a" );
            Assert.Equal( "a", exception.GetPrompt( true ) );
        }

        /// <summary>
        /// 测试获取异常提示 - 非生产环境显示Warning异常消息
        /// </summary>
        [Fact]
        public void TestGetPrompt_Warning_IsProduction_False() {
            var exception = new Warning( "a" );
            Assert.Equal( "a", exception.GetPrompt() );
        }

        /// <summary>
        /// 测试获取异常提示 - 显示Warning多层异常消息
        /// </summary>
        [Fact]
        public void TestGetPrompt_Warning_2Level() {
            var rawException = new Exception( "a" );
            var exception = new Warning( rawException );
            Assert.Equal( "a", exception.GetPrompt() );
        }

        /// <summary>
        /// 测试获取异常提示 - 显示原始异常消息
        /// </summary>
        [Fact]
        public void TestGetPrompt_AspectInvocationException() {
            var exception = new AspectInvocationException( null, new Exception( "a" ) );
            Assert.Equal( "a", exception.GetPrompt() );
        }
    }
}
