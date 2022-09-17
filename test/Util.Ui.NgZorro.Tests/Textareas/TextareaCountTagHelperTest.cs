using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Textareas {
    /// <summary>
    /// 文本域计数测试
    /// </summary>
    public class TextareaCountTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextareaCountTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TextareaCountTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-textarea-count></nz-textarea-count>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数字提示最大值
        /// </summary>
        [Fact]
        public void TestMaxCharacterCount() {
            _wrapper.SetContextAttribute( UiConst.MaxCharacterCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-textarea-count [nzMaxCharacterCount]=\"a\"></nz-textarea-count>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数字提示最大值
        /// </summary>
        [Fact]
        public void TestBindMaxCharacterCount() {
            _wrapper.SetContextAttribute( AngularConst.BindMaxCharacterCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-textarea-count [nzMaxCharacterCount]=\"a\"></nz-textarea-count>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数字提示最大值计算函数
        /// </summary>
        [Fact]
        public void TestComputeCharacterCount() {
            _wrapper.SetContextAttribute( UiConst.ComputeCharacterCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-textarea-count [nzComputeCharacterCount]=\"a\"></nz-textarea-count>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}