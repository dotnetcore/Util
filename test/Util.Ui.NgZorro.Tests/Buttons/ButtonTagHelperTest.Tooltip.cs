using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 文字提示相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试提示文字
        /// </summary>
        [Fact]
        public void TestTooltipTitle() {
            _wrapper.SetContextAttribute( UiConst.TooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字 - 多语言
        /// </summary>
        [Fact]
        public void TestTooltipTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipTitle]=\"'a'|i18n\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字
        /// </summary>
        [Fact]
        public void TestBindTooltipTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipTitle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字显示update
        /// </summary>
        [Fact]
        public void TestTooltipTitleUpdate() {
            _wrapper.SetContextAttribute( UiConst.TooltipTitleUpdate, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"Update\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字显示update - 多语言
        /// </summary>
        [Fact]
        public void TestTooltipTitleUpdate_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TooltipTitleUpdate, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipTitle]=\"'util.update'|i18n\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字显示delete
        /// </summary>
        [Fact]
        public void TestTooltipTitleDelete() {
            _wrapper.SetContextAttribute( UiConst.TooltipTitleDelete, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"Delete\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字显示update - 多语言
        /// </summary>
        [Fact]
        public void TestTooltipTitleDelete_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TooltipTitleDelete, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipTitle]=\"'util.delete'|i18n\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字显示detail
        /// </summary>
        [Fact]
        public void TestTooltipTitleDetail() {
            _wrapper.SetContextAttribute( UiConst.TooltipTitleDetail, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"Detail\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字显示detail - 多语言
        /// </summary>
        [Fact]
        public void TestTooltipTitleDetail_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TooltipTitleDetail, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipTitle]=\"'util.detail'|i18n\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示触发行为
        /// </summary>
        [Fact]
        public void TestTooltipTrigger() {
            _wrapper.SetContextAttribute( UiConst.TooltipTrigger, TooltipTrigger.Click );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipTrigger=\"click\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示触发行为
        /// </summary>
        [Fact]
        public void TestBindTooltipTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipTrigger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框位置
        /// </summary>
        [Fact]
        public void TestTooltipPlacement() {
            _wrapper.SetContextAttribute( UiConst.TooltipPlacement, TooltipPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipPlacement=\"bottomLeft\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框位置
        /// </summary>
        [Fact]
        public void TestBindTooltipPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipPlacement]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示背景颜色
        /// </summary>
        [Fact]
        public void TestTooltipColor() {
            _wrapper.SetContextAttribute( UiConst.TooltipColor, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipColor=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示背景颜色
        /// </summary>
        [Fact]
        public void TestBindTooltipColor() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipColor, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipColor]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示定位元素
        /// </summary>
        [Fact]
        public void TestTooltipOrigin() {
            _wrapper.SetContextAttribute( UiConst.TooltipOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipOrigin]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框是否可见
        /// </summary>
        [Fact]
        public void TestTooltipVisible() {
            _wrapper.SetContextAttribute( UiConst.TooltipVisible, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipVisible]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框是否可见
        /// </summary>
        [Fact]
        public void TestBindTooltipVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipVisible]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移入延时
        /// </summary>
        [Fact]
        public void TestTooltipMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.TooltipMouseEnterDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipMouseEnterDelay=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移入延时
        /// </summary>
        [Fact]
        public void TestBindTooltipMouseEnterDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipMouseEnterDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipMouseEnterDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移出延时
        /// </summary>
        [Fact]
        public void TestTooltipMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.TooltipMouseLeaveDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipMouseLeaveDelay=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移出延时
        /// </summary>
        [Fact]
        public void TestBindTooltipMouseLeaveDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipMouseLeaveDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipMouseLeaveDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式类名
        /// </summary>
        [Fact]
        public void TestTooltipOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.TooltipOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" nzTooltipOverlayClassName=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式类名
        /// </summary>
        [Fact]
        public void TestBindTooltipOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipOverlayClassName]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式
        /// </summary>
        [Fact]
        public void TestTooltipOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.TooltipOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-tooltip=\"\" [nzTooltipOverlayStyle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnTooltipVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnTooltipVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzTooltipVisibleChange)=\"a\" nz-button=\"\" nz-tooltip=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
