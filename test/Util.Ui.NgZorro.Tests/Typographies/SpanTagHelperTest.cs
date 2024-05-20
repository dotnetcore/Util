using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Typographies;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Typographies {
    /// <summary>
    /// span组件测试
    /// </summary>
    public class SpanTagHelperTest {
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
        public SpanTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SpanTagHelper().ToWrapper();
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
            result.Append( "<span></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试*ngIf
        /// </summary>
        [Fact]
        public void TestNgIf() {
            _wrapper.SetContextAttribute( AngularConst.NgIf, "a" );
            var result = new StringBuilder();
            result.Append( "<span *ngIf=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试code子标签
        /// </summary>
        [Fact]
        public void TestChildTag_Code() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.ChildTag, SpanChildTag.Code );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-typography=\"\"><code>a</code></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试del子标签
        /// </summary>
        [Fact]
        public void TestChildTag_Delete() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.ChildTag, SpanChildTag.Delete );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-typography=\"\"><del>a</del></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试kbd子标签
        /// </summary>
        [Fact]
        public void TestChildTag_Keyboard() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.ChildTag, SpanChildTag.Keyboard );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-typography=\"\"><kbd>a</kbd></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试mark子标签
        /// </summary>
        [Fact]
        public void TestChildTag_Mark() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.ChildTag, SpanChildTag.Mark );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-typography=\"\"><mark>a</mark></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试strong子标签
        /// </summary>
        [Fact]
        public void TestChildTag_Strong() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.ChildTag, SpanChildTag.Strong );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-typography=\"\"><strong>a</strong></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试u子标签
        /// </summary>
        [Fact]
        public void TestChildTag_Underline() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.ChildTag, SpanChildTag.Underline );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-typography=\"\"><u>a</u></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字
        /// </summary>
        [Fact]
        public void TestTooltipTitle() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.TooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" nzTooltipTitle=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字
        /// </summary>
        [Fact]
        public void TestBindTooltipTitle() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( AngularConst.BindTooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipTitle]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置html
        /// </summary>
        [Fact]
        public void TestHtml() {
            _wrapper.SetContextAttribute( UiConst.Html, "a" );
            var result = new StringBuilder();
            result.Append( "<span [innerHTML]=\"'a'\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置html
        /// </summary>
        [Fact]
        public void TestBindHtml() {
            _wrapper.SetContextAttribute( AngularConst.BindHtml, "a" );
            var result = new StringBuilder();
            result.Append( "<span [innerHTML]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<span *nzSpaceItem=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnTooltipVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.Typography, true );
            _wrapper.SetContextAttribute( UiConst.OnTooltipVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<span (nzTooltipVisibleChange)=\"a\" nz-typography=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上下文菜单事件
        /// </summary>
        [Fact]
        public void TestOnContextmenu() {
            _wrapper.SetContextAttribute( UiConst.OnContextmenu, "a" );
            var result = new StringBuilder();
            result.Append( "<span (contextmenu)=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}