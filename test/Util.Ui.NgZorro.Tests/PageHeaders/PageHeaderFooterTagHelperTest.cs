using System.Text;
using Util.Ui.NgZorro.Components.PageHeaders;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.PageHeaders {
    /// <summary>
    /// 页头底部测试
    /// </summary>
    public class PageHeaderFooterTagHelperTest {
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
        public PageHeaderFooterTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new PageHeaderFooterTagHelper().ToWrapper();
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
            result.Append( "<nz-page-header-footer></nz-page-header-footer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header-footer>a</nz-page-header-footer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}