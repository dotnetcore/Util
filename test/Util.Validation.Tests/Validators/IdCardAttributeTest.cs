using System.Linq;
using Util.Properties;
using Util.Validation.Tests.Samples;
using Xunit;

namespace Util.Validation.Tests.Validators {
    /// <summary>
    /// 身份证验证测试
    /// </summary>
    public class IdCardAttributeTest {
        /// <summary>
        /// 验证样例2
        /// </summary>
        private readonly Sample2 _sample2;
        /// <summary>
        /// 验证样例3
        /// </summary>
        private readonly Sample3 _sample3;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public IdCardAttributeTest() {
            _sample2 = new Sample2();
            _sample3 = new Sample3();
        }

        /// <summary>
        /// 测试验证身份证 - 有效
        /// </summary>
        [Fact]
        public void TestValidate_Valid() {
            _sample2.IdCard = "522602196011070010";
            var result = DataAnnotationValidation.Validate( _sample2 );
            Assert.True( result.IsValid );
        }

        /// <summary>
        /// 测试验证身份证 - 无效 - 默认错误消息
        /// </summary>
        [Fact]
        public void TestValidate_InValid_1() {
            _sample2.IdCard = "5226021960110700103";
            var result = DataAnnotationValidation.Validate( _sample2 );
            Assert.False( result.IsValid );
            Assert.Equal( R.InvalidIdCard, result.First().ErrorMessage );
        }

        /// <summary>
        /// 测试验证身份证 - 无效
        /// </summary>
        [Fact]
        public void TestValidate_InValid_2() {
            _sample3.IdCard = "5226021960110700103";
            var result = DataAnnotationValidation.Validate( _sample3 );
            Assert.False( result.IsValid );
            Assert.Equal( "IdCard", result.First().ErrorMessage );
        }
    }
}
