using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 气泡卡片相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试气泡卡片标题
        /// </summary>
        [Fact]
        public void TestPopoverTitle() {
            _wrapper.SetContextAttribute( UiConst.PopoverTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverTitle=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片标题
        /// </summary>
        [Fact]
        public void TestBindPopoverTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverTitle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片内容
        /// </summary>
        [Fact]
        public void TestPopoverContent() {
            _wrapper.SetContextAttribute( UiConst.PopoverContent, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverContent=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片内容
        /// </summary>
        [Fact]
        public void TestBindPopoverContent() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverContent, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverContent]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片触发行为
        /// </summary>
        [Fact]
        public void TestPopoverTrigger() {
            _wrapper.SetContextAttribute( UiConst.PopoverTrigger, PopoverTrigger.Focus );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverTrigger=\"focus\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片触发行为
        /// </summary>
        [Fact]
        public void TestBindPopoverTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverTrigger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片位置
        /// </summary>
        [Fact]
        public void TestPopoverPlacement() {
            _wrapper.SetContextAttribute( UiConst.PopoverPlacement, PopoverPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverPlacement=\"bottomLeft\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片位置
        /// </summary>
        [Fact]
        public void TestBindPopoverPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverPlacement]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片定位元素
        /// </summary>
        [Fact]
        public void TestPopoverOrigin() {
            _wrapper.SetContextAttribute( UiConst.PopoverOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverOrigin=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片定位元素
        /// </summary>
        [Fact]
        public void TestBindPopoverOrigin() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverOrigin]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示气泡卡片
        /// </summary>
        [Fact]
        public void TestPopoverVisible() {
            _wrapper.SetContextAttribute( UiConst.PopoverVisible, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverVisible]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示气泡卡片
        /// </summary>
        [Fact]
        public void TestBindPopoverVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverVisible]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移入延时
        /// </summary>
        [Fact]
        public void TestPopoverMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.PopoverMouseEnterDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverMouseEnterDelay=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移入延时
        /// </summary>
        [Fact]
        public void TestBindPopoverMouseEnterDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverMouseEnterDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverMouseEnterDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移出延时
        /// </summary>
        [Fact]
        public void TestPopoverMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.PopoverMouseLeaveDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverMouseLeaveDelay=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移出延时
        /// </summary>
        [Fact]
        public void TestBindPopoverMouseLeaveDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverMouseLeaveDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverMouseLeaveDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式类名
        /// </summary>
        [Fact]
        public void TestPopoverOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.PopoverOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" nzPopoverOverlayClassName=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式类名
        /// </summary>
        [Fact]
        public void TestBindPopoverOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverOverlayClassName]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式
        /// </summary>
        [Fact]
        public void TestPopoverOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.PopoverOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverOverlayStyle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片浮层是否带背景
        /// </summary>
        [Fact]
        public void TestPopoverBackdrop() {
            _wrapper.SetContextAttribute( UiConst.PopoverBackdrop, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverBackdrop]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片浮层是否带背景
        /// </summary>
        [Fact]
        public void TestBindPopoverBackdrop() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverBackdrop, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverBackdrop]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnPopoverVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnPopoverVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzPopoverVisibleChange)=\"a\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
