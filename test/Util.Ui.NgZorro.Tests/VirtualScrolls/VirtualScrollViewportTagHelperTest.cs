using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.VirtualScrolls;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.VirtualScrolls {
    /// <summary>
    /// 虚拟滚动窗口测试
    /// </summary>
    public class VirtualScrollViewportTagHelperTest {
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
        public VirtualScrollViewportTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new VirtualScrollViewportTagHelper().ToWrapper();
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
            result.Append( "<cdk-virtual-scroll-viewport></cdk-virtual-scroll-viewport>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列高
        /// </summary>
        [Fact]
        public void TestItemSize() {
            _wrapper.SetContextAttribute( UiConst.ItemSize, 1 );
            var result = new StringBuilder();
            result.Append( "<cdk-virtual-scroll-viewport itemSize=\"1\"></cdk-virtual-scroll-viewport>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列高
        /// </summary>
        [Fact]
        public void TestBindItemSize() {
            _wrapper.SetContextAttribute( AngularConst.BindItemSize, "a" );
            var result = new StringBuilder();
            result.Append( "<cdk-virtual-scroll-viewport [itemSize]=\"a\"></cdk-virtual-scroll-viewport>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<cdk-virtual-scroll-viewport>a</cdk-virtual-scroll-viewport>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}