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
            result.Append( "<span nz-typography=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试code子标签
        /// </summary>
        [Fact]
        public void TestChildTag_Code() {
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
            _wrapper.SetContextAttribute( AngularConst.BindTooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipTitle]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示触发行为
        /// </summary>
        [Fact]
        public void TestTooltipTrigger() {
            _wrapper.SetContextAttribute( UiConst.TooltipTrigger, TooltipTrigger.Click );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" nzTooltipTrigger=\"click\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示触发行为
        /// </summary>
        [Fact]
        public void TestBindTooltipTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipTrigger]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框位置
        /// </summary>
        [Fact]
        public void TestTooltipPlacement() {
            _wrapper.SetContextAttribute( UiConst.TooltipPlacement, TooltipPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" nzTooltipPlacement=\"bottomLeft\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框位置
        /// </summary>
        [Fact]
        public void TestBindTooltipPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipPlacement]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示背景颜色
        /// </summary>
        [Fact]
        public void TestTooltipColor() {
            _wrapper.SetContextAttribute( UiConst.TooltipColor, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" nzTooltipColor=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示背景颜色
        /// </summary>
        [Fact]
        public void TestBindTooltipColor() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipColor, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipColor]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示定位元素
        /// </summary>
        [Fact]
        public void TestTooltipOrigin() {
            _wrapper.SetContextAttribute( UiConst.TooltipOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipOrigin]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框是否可见
        /// </summary>
        [Fact]
        public void TestTooltipVisible() {
            _wrapper.SetContextAttribute( UiConst.TooltipVisible, true );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipVisible]=\"true\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框是否可见
        /// </summary>
        [Fact]
        public void TestBindTooltipVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipVisible]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移入延时
        /// </summary>
        [Fact]
        public void TestTooltipMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.TooltipMouseEnterDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" nzTooltipMouseEnterDelay=\"1\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移入延时
        /// </summary>
        [Fact]
        public void TestBindTooltipMouseEnterDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipMouseEnterDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipMouseEnterDelay]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移出延时
        /// </summary>
        [Fact]
        public void TestTooltipMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.TooltipMouseLeaveDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" nzTooltipMouseLeaveDelay=\"1\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移出延时
        /// </summary>
        [Fact]
        public void TestBindTooltipMouseLeaveDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipMouseLeaveDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipMouseLeaveDelay]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式类名
        /// </summary>
        [Fact]
        public void TestTooltipOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.TooltipOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" nzTooltipOverlayClassName=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式类名
        /// </summary>
        [Fact]
        public void TestBindTooltipOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipOverlayClassName]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式
        /// </summary>
        [Fact]
        public void TestTooltipOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.TooltipOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-tooltip=\"\" nz-typography=\"\" [nzTooltipOverlayStyle]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnTooltipVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnTooltipVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<span (nzTooltipVisibleChange)=\"a\" nz-tooltip=\"\" nz-typography=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}