using System;
using System.Collections.Generic;
using Util.Validation.Tests.Infrastructure;
using Util.Validation.Tests.Samples;
using Xunit;

namespace Util.Validation.Tests {
    /// <summary>
    /// 验证拦截器测试
    /// </summary>
    public class ValidAttributeTest : TestBase {
        /// <summary>
        /// 验证单个对象
        /// </summary>
        [Fact]
        public void TestValidate() {
            Sample sample = new Sample();
            var service = GetService<ITestService>();
            Assert.Throws<ArgumentException>( () => {
                service.Call( sample );
            } );
        }

        /// <summary>
        /// 验证单个对象 - 验证通过不会抛出异常
        /// </summary>
        [Fact]
        public void TestValidate_2() {
            Sample sample = new Sample {RequiredValue = "a"};
            var service = GetService<ITestService>();
            service.Call( sample );
        }

        /// <summary>
        /// 验证集合对象
        /// </summary>
        [Fact]
        public void TestValidateCollection() {
            List<Sample> samples = new List<Sample> {new Sample(), new Sample() };
            var service = GetService<ITestService>();
            Assert.Throws<ArgumentException>( () => {
                service.CallCollection( samples );
            } );
        }

        /// <summary>
        /// 验证集合对象 - 验证通过不会抛出异常
        /// </summary>
        [Fact]
        public void TestValidateCollection_2() {
            List<Sample> samples = new List<Sample> { new Sample{RequiredValue = "a"}, new Sample{RequiredValue = "b"} };
            var service = GetService<ITestService>();
            service.CallCollection( samples );
        }
    }
}
