using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
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
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzPopconfirmTrigger=\"click\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡确认框触发行为
        /// </summary>
        [Fact]
        public void TestBindPopconfirmTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmTrigger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框位置
        /// </summary>
        [Fact]
        public void TestPopconfirmPlacement() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmPlacement, PopconfirmPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzPopconfirmPlacement=\"bottomLeft\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框位置
        /// </summary>
        [Fact]
        public void TestBindPopconfirmPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmPlacement]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框定位元素
        /// </summary>
        [Fact]
        public void TestPopconfirmOrigin() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOrigin, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmOrigin]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否可见
        /// </summary>
        [Fact]
        public void TestPopconfirmVisible() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmVisible, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmVisible]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否可见
        /// </summary>
        [Fact]
        public void TestBindPopconfirmVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmVisible]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否显示箭头
        /// </summary>
        [Fact]
        public void TestPopconfirmShowArrow() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmShowArrow, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmShowArrow]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框是否显示箭头
        /// </summary>
        [Fact]
        public void TestBindPopconfirmShowArrow() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmShowArrow, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmShowArrow]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框移入延时
        /// </summary>
        [Fact]
        public void TestPopconfirmMouseEnterDelay() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmMouseEnterDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzPopconfirmMouseEnterDelay=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框移入延时
        /// </summary>
        [Fact]
        public void TestBindPopconfirmMouseEnterDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmMouseEnterDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmMouseEnterDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框移出延时
        /// </summary>
        [Fact]
        public void TestPopconfirmMouseLeaveDelay() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmMouseLeaveDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzPopconfirmMouseLeaveDelay=\"1\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框移出延时
        /// </summary>
        [Fact]
        public void TestBindPopconfirmMouseLeaveDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmMouseLeaveDelay,"a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmMouseLeaveDelay]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框样式类名
        /// </summary>
        [Fact]
        public void TestPopconfirmOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzPopconfirmOverlayClassName=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框样式类名
        /// </summary>
        [Fact]
        public void TestBindPopconfirmOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmOverlayClassName]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框样式
        /// </summary>
        [Fact]
        public void TestPopconfirmOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmOverlayStyle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框浮层是否应带背景
        /// </summary>
        [Fact]
        public void TestPopconfirmBackdrop() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmBackdrop, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmBackdrop]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框浮层是否应带背景
        /// </summary>
        [Fact]
        public void TestBindPopconfirmBackdrop() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmBackdrop, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzPopconfirmBackdrop]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框取消按钮文字
        /// </summary>
        [Fact]
        public void TestPopconfirmCancelText() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmCancelText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzCancelText=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框取消按钮文字
        /// </summary>
        [Fact]
        public void TestBindPopconfirmCancelText() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmCancelText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzCancelText]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮文字
        /// </summary>
        [Fact]
        public void TestPopconfirmOkText() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOkText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzOkText=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮文字
        /// </summary>
        [Fact]
        public void TestBindPopconfirmOkText() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmOkText, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzOkText]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮类型
        /// </summary>
        [Fact]
        public void TestPopconfirmOkType() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmOkType, ButtonType.Primary );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzOkType=\"primary\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认按钮类型
        /// </summary>
        [Fact]
        public void TestBindPopconfirmOkType() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmOkType, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzOkType]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框条件触发
        /// </summary>
        [Fact]
        public void TestPopconfirmCondition() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmCondition, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzCondition]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框条件触发
        /// </summary>
        [Fact]
        public void TestBindPopconfirmCondition() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmCondition, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzCondition]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框自定义图标
        /// </summary>
        [Fact]
        public void TestPopconfirmIcon() {
            _wrapper.SetContextAttribute( UiConst.PopconfirmIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" nzIcon=\"account-book\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框自定义图标
        /// </summary>
        [Fact]
        public void TestBindPopconfirmIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindPopconfirmIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-popconfirm=\"\" [nzIcon]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnPopconfirmVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnPopconfirmVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzPopconfirmVisibleChange)=\"a\" nz-button=\"\" nz-popconfirm=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框取消事件
        /// </summary>
        [Fact]
        public void TestOnPopconfirmCancel() {
            _wrapper.SetContextAttribute( UiConst.OnPopconfirmCancel, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzOnCancel)=\"a\" nz-button=\"\" nz-popconfirm=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡框确认事件
        /// </summary>
        [Fact]
        public void TestOnPopconfirmConfirm() {
            _wrapper.SetContextAttribute( UiConst.OnPopconfirmConfirm, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzOnConfirm)=\"a\" nz-button=\"\" nz-popconfirm=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
