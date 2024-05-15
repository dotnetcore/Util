using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
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
        /// 测试气泡卡片标题 - 多语言
        /// </summary>
        [Fact]
        public void TestPopoverTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.PopoverTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popover=\"\" [nzPopoverTitle]=\"'a'|i18n\"></button>" );
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
            result.Append( "<button nz-button=\"\" nzPopoverTrigger=\"focus\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片触发行为
        /// </summary>
        [Fact]
        public void TestBindPopoverTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverTrigger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片位置
        /// </summary>
        [Fact]
        public void TestPopoverPlacement() {
            _wrapper.SetContextAttribute( UiConst.PopoverPlacement, PopoverPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzPopoverPlacement=\"bottomLeft\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片位置
        /// </summary>
        [Fact]
        public void TestBindPopoverPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverPlacement]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试箭头是否指向锚点的中心
        /// </summary>
        [Fact]
        public void TestPopoverArrowPointAtCenter() {
            _wrapper.SetContextAttribute( UiConst.PopoverArrowPointAtCenter, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverArrowPointAtCenter]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片定位元素
        /// </summary>
        [Fact]
        public void TestPopoverOrigin() {
            _wrapper.SetContextAttribute( UiConst.PopoverOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverOrigin]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示气泡卡片
        /// </summary>
        [Fact]
        public void TestPopoverVisible() {
            _wrapper.SetContextAttribute( UiConst.PopoverVisible, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverVisible]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示气泡卡片
        /// </summary>
        [Fact]
        public void TestBindonPopoverVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonPopoverVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [(nzPopoverVisible)]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移入延时
        /// </summary>
        [Fact]
        public void TestPopoverMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.PopoverMouseEnterDelay, "1" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverMouseEnterDelay]=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移出延时
        /// </summary>
        [Fact]
        public void TestPopoverMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.PopoverMouseLeaveDelay, "1" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverMouseLeaveDelay]=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式类名
        /// </summary>
        [Fact]
        public void TestPopoverOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.PopoverOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzPopoverOverlayClassName=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式类名
        /// </summary>
        [Fact]
        public void TestBindPopoverOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverOverlayClassName]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式
        /// </summary>
        [Fact]
        public void TestPopoverOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.PopoverOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverOverlayStyle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片浮层是否带背景
        /// </summary>
        [Fact]
        public void TestPopoverBackdrop() {
            _wrapper.SetContextAttribute( UiConst.PopoverBackdrop, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopoverBackdrop]=\"true\"></button>" );
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
