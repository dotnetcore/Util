using System;
using Util.Aop.AspectCore.Tests.Samples;
using Xunit;

namespace Util.Aop.AspectCore.Tests {
    /// <summary>
    /// 测试NotNullAttribute拦截器
    /// </summary>
    public class NotNullAttributeTest {
        /// <summary>
        /// 测试服务
        /// </summary>
        private readonly ITestService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public NotNullAttributeTest( ITestService service ) {
            _service = service;
        }

        /// <summary>
        /// 测试传入null抛出异常
        /// </summary>
        [Fact]
        public void TestNotNull_1() {
            Assert.Throws<ArgumentNullException>( () => {
                _service.GetNotNullValue( null );
            } );
        }

        /// <summary>
        /// 测试传入空字符串
        /// </summary>
        [Fact]
        public void TestNotNull_2() {
            Assert.Equal( "", _service.GetNotNullValue( "" ) );
        }

        /// <summary>
        /// 测试传入值
        /// </summary>
        [Fact]
        public void TestNotNull_3() {
            Assert.Equal( "a", _service.GetNotNullValue( "a" ) );
        }
    }
}
