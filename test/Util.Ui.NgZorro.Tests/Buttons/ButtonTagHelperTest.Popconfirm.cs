using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 气泡确认框相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试气泡确认框标题
        /// </summary>
        [Fact]
        public void TestPopconfirmTitle() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzPopconfirmTitle=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡确认框标题 - 多语言
        /// </summary>
        [Fact]
        public void TestPopconfirmTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.PopconfirmTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmTitle]=\"'a'|i18n\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡确认框标题
        /// </summary>
        [Fact]
        public void TestBindPopconfirmTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmTitle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡确认框触发行为
        /// </summary>
        [Fact]
        public void TestPopconfirmTrigger() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmTrigger, PopconfirmTrigger.Click );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzPopconfirmTrigger=\"click\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡确认框触发行为
        /// </summary>
        [Fact]
        public void TestBindPopconfirmTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmTrigger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框位置
        /// </summary>
        [Fact]
        public void TestPopconfirmPlacement() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmPlacement, PopconfirmPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzPopconfirmPlacement=\"bottomLeft\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框位置
        /// </summary>
        [Fact]
        public void TestBindPopconfirmPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmPlacement]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框定位元素
        /// </summary>
        [Fact]
        public void TestPopconfirmOrigin() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmOrigin]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否可见
        /// </summary>
        [Fact]
        public void TestPopconfirmVisible() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmVisible, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmVisible]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否可见
        /// </summary>
        [Fact]
        public void TestBindonPopconfirmVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonPopconfirmVisible, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [(nzPopconfirmVisible)]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否显示箭头
        /// </summary>
        [Fact]
        public void TestPopconfirmShowArrow() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmShowArrow, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmShowArrow]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试箭头是否指向锚点的中心
        /// </summary>
        [Fact]
        public void TestPopconfirmArrowPointAtCenter() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmArrowPointAtCenter, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmArrowPointAtCenter]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框移入延时
        /// </summary>
        [Fact]
        public void TestPopconfirmMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmMouseEnterDelay, "1" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmMouseEnterDelay]=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框移出延时
        /// </summary>
        [Fact]
        public void TestPopconfirmMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmMouseLeaveDelay, "1" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmMouseLeaveDelay]=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框样式类名
        /// </summary>
        [Fact]
        public void TestPopconfirmOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzPopconfirmOverlayClassName=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框样式类名
        /// </summary>
        [Fact]
        public void TestBindPopconfirmOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmOverlayClassName]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框样式
        /// </summary>
        [Fact]
        public void TestPopconfirmOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmOverlayStyle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框浮层是否应带背景
        /// </summary>
        [Fact]
        public void TestPopconfirmBackdrop() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmBackdrop, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPopconfirmBackdrop]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框取消按钮文字
        /// </summary>
        [Fact]
        public void TestPopconfirmCancelText() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmCancelText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzCancelText=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框取消按钮文字
        /// </summary>
        [Fact]
        public void TestBindPopconfirmCancelText() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmCancelText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzCancelText]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮文字
        /// </summary>
        [Fact]
        public void TestPopconfirmOkText() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOkText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzOkText=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮文字
        /// </summary>
        [Fact]
        public void TestBindPopconfirmOkText() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmOkText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzOkText]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮类型
        /// </summary>
        [Fact]
        public void TestPopconfirmOkType() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOkType, ButtonType.Primary );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzOkType=\"primary\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮类型
        /// </summary>
        [Fact]
        public void TestBindPopconfirmOkType() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmOkType, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzOkType]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮是否为危险按钮
        /// </summary>
        [Fact]
        public void TestPopconfirmOkDanger() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOkDanger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzOkDanger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否禁用确认按钮
        /// </summary>
        [Fact]
        public void TestPopconfirmOkDisabled() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOkDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzOkDisabled]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡确认框按钮自动聚焦
        /// </summary>
        [Fact]
        public void TestPopconfirmAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmAutoFocus, PopconfirmAutoFocus.Cancel );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzAutoFocus=\"cancel\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡确认框按钮自动聚焦
        /// </summary>
        [Fact]
        public void TestBindPopconfirmAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmAutoFocus, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzAutoFocus]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框条件触发
        /// </summary>
        [Fact]
        public void TestPopconfirmCondition() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmCondition, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzCondition]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框自定义图标
        /// </summary>
        [Fact]
        public void TestPopconfirmIcon() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzIcon=\"account-book\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框自定义图标
        /// </summary>
        [Fact]
        public void TestBindPopconfirmIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzIcon]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确认前操作钩子
        /// </summary>
        [Fact]
        public void TestPopconfirmBeforeConfirm() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmBeforeConfirm, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzBeforeConfirm]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnPopconfirmVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnPopconfirmVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzPopconfirmVisibleChange)=\"a\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框取消事件
        /// </summary>
        [Fact]
        public void TestOnPopconfirmCancel() {
            _wrapper.SetContextAttribute( UiConst.OnPopconfirmCancel, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzOnCancel)=\"a\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认事件
        /// </summary>
        [Fact]
        public void TestOnPopconfirmConfirm() {
            _wrapper.SetContextAttribute( UiConst.OnPopconfirmConfirm, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzOnConfirm)=\"a\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
