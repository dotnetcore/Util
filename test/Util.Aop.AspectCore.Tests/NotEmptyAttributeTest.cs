using System;
using Util.Aop.AspectCore.Tests.Infrastructure;
using Util.Aop.AspectCore.Tests.Samples;
using Xunit;

namespace Util.Aop.AspectCore.Tests {
    /// <summary>
    /// 测试NotEmptyAttribute拦截器
    /// </summary>
    public class NotEmptyAttributeTest : TestBase {
        /// <summary>
        /// 测试传入空字符串抛出异常
        /// </summary>
        [Fact]
        public void TestNotEmpty_1() {
            var service = GetService<ITestService>();
            Assert.Throws<ArgumentNullException>( () => {
                service.GetNotEmptyValue( "" );
            } );
        }

        /// <summary>
        /// 测试传入值
        /// </summary>
        [Fact]
        public void TestNotEmpty_2() {
            var service = GetService<ITestService>();
            Assert.Equal( "a", service.GetNotEmptyValue( "a" ) );
        }
    }
}
