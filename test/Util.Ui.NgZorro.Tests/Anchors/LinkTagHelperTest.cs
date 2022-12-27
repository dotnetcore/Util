using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Anchors;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Anchors {
    /// <summary>
    /// 链接测试
    /// </summary>
    public class LinkTagHelperTest {
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
        public LinkTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new LinkTagHelper().ToWrapper();
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
            result.Append( "<nz-link></nz-link>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试锚点链接
        /// </summary>
        [Fact]
        public void TestHref() {
            _wrapper.SetContextAttribute( UiConst.Href, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-link nzHref=\"a\"></nz-link>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试锚点链接
        /// </summary>
        [Fact]
        public void TestBindHref() {
            _wrapper.SetContextAttribute( AngularConst.BindHref, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-link [nzHref]=\"a\"></nz-link>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-link nzTitle=\"a\"></nz-link>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-link [nzTitle]=\"a\"></nz-link>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-link>a</nz-link>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}