using System;
using System.Collections.Generic;
using Util.Validation.Tests.Samples;
using Xunit;

namespace Util.Validation.Tests {
    /// <summary>
    /// 验证拦截器测试
    /// </summary>
    public class ValidAttributeTest {
        /// <summary>
        /// 测试服务
        /// </summary>
        private readonly ITestService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ValidAttributeTest( ITestService service ) {
            _service = service;
        }

        /// <summary>
        /// 验证单个对象
        /// </summary>
        [Fact]
        public void TestValidate() {
            Sample sample = new Sample();
            Assert.Throws<ArgumentException>( () => {
                _service.Call( sample );
            } );
        }

        /// <summary>
        /// 验证单个对象 - 验证通过不会抛出异常
        /// </summary>
        [Fact]
        public void TestValidate_2() {
            Sample sample = new Sample {RequiredValue = "a"};
            _service.Call( sample );
        }

        /// <summary>
        /// 验证集合对象
        /// </summary>
        [Fact]
        public void TestValidateCollection() {
            List<Sample> samples = new List<Sample> {new Sample(), new Sample() };
            Assert.Throws<ArgumentException>( () => {
                _service.CallCollection( samples );
            } );
        }

        /// <summary>
        /// 验证集合对象 - 验证通过不会抛出异常
        /// </summary>
        [Fact]
        public void TestValidateCollection_2() {
            List<Sample> samples = new List<Sample> { new Sample{RequiredValue = "a"}, new Sample{RequiredValue = "b"} };
            _service.CallCollection( samples );
        }
    }
}
