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
        /// 测试提示框位置
        /// </summary>
        [Fact]
        public void TestTooltipPlacement() {
            _wrapper.SetContextAttribute( UiConst.TooltipPlacement, TooltipPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzTooltipPlacement=\"bottomLeft\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框位置
        /// </summary>
        [Fact]
        public void TestBindTooltipPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipPlacement]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试箭头是否指向锚点的中心
        /// </summary>
        [Fact]
        public void TestTooltipArrowPointAtCenter() {
            _wrapper.SetContextAttribute( UiConst.TooltipArrowPointAtCenter, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipArrowPointAtCenter]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字模板上下文
        /// </summary>
        [Fact]
        public void TestTooltipTitleContext() {
            _wrapper.SetContextAttribute( UiConst.TooltipTitleContext, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipTitleContext]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示触发行为
        /// </summary>
        [Fact]
        public void TestTooltipTrigger() {
            _wrapper.SetContextAttribute( UiConst.TooltipTrigger, TooltipTrigger.Click );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzTooltipTrigger=\"click\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示触发行为
        /// </summary>
        [Fact]
        public void TestBindTooltipTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipTrigger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示背景颜色
        /// </summary>
        [Fact]
        public void TestTooltipColor() {
            _wrapper.SetContextAttribute( UiConst.TooltipColor, AntDesignColor.Blue );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzTooltipColor=\"blue\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示背景颜色
        /// </summary>
        [Fact]
        public void TestBindTooltipColor() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipColor, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipColor]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字提示定位元素
        /// </summary>
        [Fact]
        public void TestTooltipOrigin() {
            _wrapper.SetContextAttribute( UiConst.TooltipOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipOrigin]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框是否可见
        /// </summary>
        [Fact]
        public void TestTooltipVisible() {
            _wrapper.SetContextAttribute( UiConst.TooltipVisible, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipVisible]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框是否可见
        /// </summary>
        [Fact]
        public void TestBindonTooltipVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonTooltipVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [(nzTooltipVisible)]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移入延时
        /// </summary>
        [Fact]
        public void TestTooltipMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.TooltipMouseEnterDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipMouseEnterDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框移出延时
        /// </summary>
        [Fact]
        public void TestTooltipMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.TooltipMouseLeaveDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipMouseLeaveDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式类名
        /// </summary>
        [Fact]
        public void TestTooltipOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.TooltipOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzTooltipOverlayClassName=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式类名
        /// </summary>
        [Fact]
        public void TestBindTooltipOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipOverlayClassName]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框样式
        /// </summary>
        [Fact]
        public void TestTooltipOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.TooltipOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTooltipOverlayStyle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示框显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnTooltipVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnTooltipVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzTooltipVisibleChange)=\"a\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
