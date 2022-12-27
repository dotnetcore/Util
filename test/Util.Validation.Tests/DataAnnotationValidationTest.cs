using System.Linq;
using Util.Validation.Tests.Samples;
using Xunit;

namespace Util.Validation.Tests {
    /// <summary>
    /// 数据注解验证操作测试
    /// </summary>
    public class DataAnnotationValidationTest {
        /// <summary>
        /// 验证样例
        /// </summary>
        private readonly Sample _sample;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DataAnnotationValidationTest() {
            _sample = new Sample();
        }

        /// <summary>
        /// 测试验证必填
        /// </summary>
        [Fact]
        public void TestValidate_Required() {
            var result = DataAnnotationValidation.Validate( _sample );
            Assert.False( result.IsValid );
            Assert.Single( result );
            Assert.Equal( "Required", result.First().ErrorMessage );
        }

        /// <summary>
        /// 测试验证字符串长度
        /// </summary>
        [Fact]
        public void TestValidate_StringLength() {
            _sample.StringLengthValue = "abcd";
            var result = DataAnnotationValidation.Validate( _sample );
            Assert.False( result.IsValid );
            Assert.Equal( 2,result.Count );
            Assert.Equal( "Required", result[0].ErrorMessage );
            Assert.Equal( "StringLength", result[1].ErrorMessage );
        }
    }
}
