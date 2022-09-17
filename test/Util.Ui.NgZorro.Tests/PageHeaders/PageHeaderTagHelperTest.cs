using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.PageHeaders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.PageHeaders {
    /// <summary>
    /// 页头测试
    /// </summary>
    public class PageHeaderTagHelperTest {
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
        public PageHeaderTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new PageHeaderTagHelper().ToWrapper();
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
            result.Append( "<nz-page-header></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试透明背景
        /// </summary>
        [Fact]
        public void TestGhost() {
            _wrapper.SetContextAttribute( UiConst.Ghost, true );
            var result = new StringBuilder();
            result.Append( "<nz-page-header [nzGhost]=\"true\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试透明背景
        /// </summary>
        [Fact]
        public void TestBindGhost() {
            _wrapper.SetContextAttribute( AngularConst.BindGhost, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header [nzGhost]=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header nzTitle=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header [nzTitle]=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试子标题
        /// </summary>
        [Fact]
        public void TestSubtitle() {
            _wrapper.SetContextAttribute( UiConst.Subtitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header nzSubtitle=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试子标题
        /// </summary>
        [Fact]
        public void TestBindSubtitle() {
            _wrapper.SetContextAttribute( AngularConst.BindSubtitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header [nzSubtitle]=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示返回按钮
        /// </summary>
        [Fact]
        public void TestShowBack_True() {
            _wrapper.SetContextAttribute( UiConst.ShowBack, true );
            var result = new StringBuilder();
            result.Append( "<nz-page-header nzBackIcon=\"\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示返回按钮
        /// </summary>
        [Fact]
        public void TestShowBack_False() {
            _wrapper.SetContextAttribute( UiConst.ShowBack, false );
            var result = new StringBuilder();
            result.Append( "<nz-page-header></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置返回按钮图标
        /// </summary>
        [Fact]
        public void TestBackIcon() {
            _wrapper.SetContextAttribute( UiConst.BackIcon, AntDesignIcon.Smile );
            var result = new StringBuilder();
            result.Append( "<nz-page-header nzBackIcon=\"smile\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置返回按钮图标
        /// </summary>
        [Fact]
        public void TestBindBackIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindBackIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header [nzBackIcon]=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置返回按钮图标,同时设置ShowBack
        /// </summary>
        [Fact]
        public void TestBindBackIcon_ShowBack() {
            _wrapper.SetContextAttribute( AngularConst.BindBackIcon, "a" ).SetContextAttribute( UiConst.ShowBack, true );
            var result = new StringBuilder();
            result.Append( "<nz-page-header [nzBackIcon]=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header>a</nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试返回事件
        /// </summary>
        [Fact]
        public void TestOnBack() {
            _wrapper.SetContextAttribute( UiConst.OnBack, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-page-header (nzBack)=\"a\"></nz-page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}