using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Descriptions;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Descriptions {
    /// <summary>
    /// 描述列表项测试
    /// </summary>
    public partial class DescriptionItemTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DescriptionItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DescriptionItemTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-descriptions-item></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            _wrapper.SetContextAttribute( UiConst.Span, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzSpan=\"1\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列跨度
        /// </summary>
        [Fact]
        public void TestBindSpan() {
            _wrapper.SetContextAttribute( AngularConst.BindSpan, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzSpan]=\"a\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item>a</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}