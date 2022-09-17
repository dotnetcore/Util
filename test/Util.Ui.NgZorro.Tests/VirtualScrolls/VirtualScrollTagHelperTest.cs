using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.VirtualScrolls;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.VirtualScrolls {
    /// <summary>
    /// 虚拟滚动测试
    /// </summary>
    public class VirtualScrollTagHelperTest {
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
        public VirtualScrollTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new VirtualScrollTagHelper().ToWrapper();
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
            result.Append( "<ng-template nz-virtual-scroll=\"\"></ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据引用
        /// </summary>
        [Fact]
        public void TestLetData() {
            _wrapper.SetContextAttribute( UiConst.LetData, "" );
            var result = new StringBuilder();
            result.Append( "<ng-template let-data=\"\" nz-virtual-scroll=\"\"></ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试索引引用
        /// </summary>
        [Fact]
        public void TestLetIndex() {
            _wrapper.SetContextAttribute( UiConst.LetIndex, "" );
            var result = new StringBuilder();
            result.Append( "<ng-template let-index=\"index\" nz-virtual-scroll=\"\"></ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<ng-template nz-virtual-scroll=\"\">a</ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}