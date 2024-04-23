using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Icons {
    /// <summary>
    /// 图标测试 - 气泡卡片相关测试
    /// </summary>
    public partial class IconTagHelperTest {
        /// <summary>
        /// 测试气泡卡片标题
        /// </summary>
        [Fact]
        public void TestPopoverTitle() {
            _wrapper.SetContextAttribute( UiConst.PopoverTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" nzPopoverTitle=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片标题
        /// </summary>
        [Fact]
        public void TestBindPopoverTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverTitle]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片内容
        /// </summary>
        [Fact]
        public void TestPopoverContent() {
            _wrapper.SetContextAttribute( UiConst.PopoverContent, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" nzPopoverContent=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片内容
        /// </summary>
        [Fact]
        public void TestBindPopoverContent() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverContent, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverContent]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片触发行为
        /// </summary>
        [Fact]
        public void TestPopoverTrigger() {
            _wrapper.SetContextAttribute( UiConst.PopoverTrigger, PopoverTrigger.Focus );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" nzPopoverTrigger=\"focus\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片触发行为
        /// </summary>
        [Fact]
        public void TestBindPopoverTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverTrigger]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片位置
        /// </summary>
        [Fact]
        public void TestPopoverPlacement() {
            _wrapper.SetContextAttribute( UiConst.PopoverPlacement, PopoverPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" nzPopoverPlacement=\"bottomLeft\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片位置
        /// </summary>
        [Fact]
        public void TestBindPopoverPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverPlacement]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片定位元素
        /// </summary>
        [Fact]
        public void TestPopoverOrigin() {
            _wrapper.SetContextAttribute( UiConst.PopoverOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" nzPopoverOrigin=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片定位元素
        /// </summary>
        [Fact]
        public void TestBindPopoverOrigin() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverOrigin]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示气泡卡片
        /// </summary>
        [Fact]
        public void TestPopoverVisible() {
            _wrapper.SetContextAttribute( UiConst.PopoverVisible, "true" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverVisible]=\"true\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示气泡卡片
        /// </summary>
        [Fact]
        public void TestBindonPopoverVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonPopoverVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [(nzPopoverVisible)]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移入延时
        /// </summary>
        [Fact]
        public void TestPopoverMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.PopoverMouseEnterDelay, "1" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverMouseEnterDelay]=\"1\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片移出延时
        /// </summary>
        [Fact]
        public void TestPopoverMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.PopoverMouseLeaveDelay, "1" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverMouseLeaveDelay]=\"1\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式类名
        /// </summary>
        [Fact]
        public void TestPopoverOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.PopoverOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" nzPopoverOverlayClassName=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式类名
        /// </summary>
        [Fact]
        public void TestBindPopoverOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverOverlayClassName]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片样式
        /// </summary>
        [Fact]
        public void TestPopoverOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.PopoverOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverOverlayStyle]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片浮层是否带背景
        /// </summary>
        [Fact]
        public void TestPopoverBackdrop() {
            _wrapper.SetContextAttribute( UiConst.PopoverBackdrop, "true" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-popover=\"\" [nzPopoverBackdrop]=\"true\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnPopoverVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnPopoverVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<i (nzPopoverVisibleChange)=\"a\" nz-icon=\"\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
