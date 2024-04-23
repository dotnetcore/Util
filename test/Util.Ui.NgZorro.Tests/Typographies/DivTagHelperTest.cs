using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Typographies;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Typographies {
    /// <summary>
    /// div组件测试
    /// </summary>
    public class DivTagHelperTest {
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
        public DivTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DivTagHelper().ToWrapper();
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
            result.Append( "<div></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排版指令
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<div #a=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排版指令
        /// </summary>
        [Fact]
        public void TestTypography() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            var result = new StringBuilder();
            result.Append( "<div nz-typography=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}