using System.Linq;
using Util.Tests.Samples;
using Util.Validations;
using Xunit;

namespace Util.Tests.Validations {
    /// <summary>
    /// 测试验证操作
    /// </summary>
    public class ValidationTest {
        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        private readonly AggregateRootSample _sample;

        /// <summary>
        /// 验证操作
        /// </summary>
        private readonly IValidation _validation;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ValidationTest() {
            _sample = AggregateRootSample.CreateSample();
            _validation = ValidationFactory.Create();
        }

        /// <summary>
        /// 测试验证
        /// </summary>
        [Fact]
        public void TestValidate() {
            _sample.Name = null;
            _sample.EnglishName = "  ";
            var result = _validation.Validate( _sample );
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试验证 - 名称为必填项
        /// </summary>
        [Fact]
        public void TestValidate_Name_Required() {
            _sample.Name = null;
            var result = _validation.Validate( _sample );
            Assert.Equal( "姓名不能为空", result.First().ErrorMessage );
        }

        /// <summary>
        /// 测试验证 - 从资源文件中加载错误消息
        /// </summary>
        [Fact]
        public void TestValidate_Resource() {
            _sample.EnglishName = null;
            var result = _validation.Validate( _sample );
            Assert.Equal( "英文名不能为空", result.First().ErrorMessage );
        }
    }
}
