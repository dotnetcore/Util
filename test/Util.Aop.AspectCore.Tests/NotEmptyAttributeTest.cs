using System;
using Util.Aop.AspectCore.Tests.Samples;
using Xunit;

namespace Util.Aop.AspectCore.Tests {
    /// <summary>
    /// 测试NotEmptyAttribute拦截器
    /// </summary>
    public class NotEmptyAttributeTest {
        /// <summary>
        /// 测试服务
        /// </summary>
        private readonly ITestService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public NotEmptyAttributeTest( ITestService service ) {
            _service = service;
        }

        /// <summary>
        /// 测试传入空字符串抛出异常
        /// </summary>
        [Fact]
        public void TestNotEmpty_1() {
            Assert.Throws<ArgumentNullException>( () => {
                _service.GetNotEmptyValue( "" );
            } );
        }

        /// <summary>
        /// 测试传入值
        /// </summary>
        [Fact]
        public void TestNotEmpty_2() {
            Assert.Equal( "a", _service.GetNotEmptyValue( "a" ) );
        }
    }
}
