using System;
using Util.Aop.AspectCore.Tests.Infrastructure;
using Util.Aop.AspectCore.Tests.Samples;
using Xunit;

namespace Util.Aop.AspectCore.Tests {
    /// <summary>
    /// 测试NotNullAttribute拦截器
    /// </summary>
    public class NotNullAttributeTest : TestBase {
        /// <summary>
        /// 测试传入null抛出异常
        /// </summary>
        [Fact]
        public void TestNotNull_1() {
            var service = GetService<ITestService>();
            Assert.Throws<ArgumentNullException>( () => {
                service.GetNotNullValue( null );
            } );
        }

        /// <summary>
        /// 测试传入空字符串
        /// </summary>
        [Fact]
        public void TestNotNull_2() {
            var service = GetService<ITestService>();
            Assert.Equal( "", service.GetNotNullValue( "" ) );
        }

        /// <summary>
        /// 测试传入值
        /// </summary>
        [Fact]
        public void TestNotNull_3() {
            var service = GetService<ITestService>();
            Assert.Equal( "a", service.GetNotNullValue( "a" ) );
        }
    }
}
