using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Modals;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Modals {
    /// <summary>
    /// 对话框测试
    /// </summary>
    public class ModalTagHelperTest {
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
        public ModalTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ModalTagHelper().ToWrapper();
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
            result.Append( "<nz-modal></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示遮罩
        /// </summary>
        [Fact]
        public void TestMask() {
            _wrapper.SetContextAttribute( UiConst.Mask, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzMask]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示遮罩
        /// </summary>
        [Fact]
        public void TestBindMask() {
            _wrapper.SetContextAttribute( AngularConst.BindMask, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzMask]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击遮罩是否允许关闭
        /// </summary>
        [Fact]
        public void TestMaskClosable() {
            _wrapper.SetContextAttribute( UiConst.MaskClosable, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzMaskClosable]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击遮罩是否允许关闭
        /// </summary>
        [Fact]
        public void TestBindMaskClosable() {
            _wrapper.SetContextAttribute( AngularConst.BindMaskClosable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzMaskClosable]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试导航时是否关闭
        /// </summary>
        [Fact]
        public void TestCloseOnNavigation() {
            _wrapper.SetContextAttribute( UiConst.CloseOnNavigation, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCloseOnNavigation]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试导航时是否关闭
        /// </summary>
        [Fact]
        public void TestBindCloseOnNavigation() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseOnNavigation, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCloseOnNavigation]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可见
        /// </summary>
        [Fact]
        public void TestVisible() {
            _wrapper.SetContextAttribute( UiConst.Visible, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [(nzVisible)]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可关闭
        /// </summary>
        [Fact]
        public void TestClosable() {
            _wrapper.SetContextAttribute( UiConst.Closable, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzClosable]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可关闭
        /// </summary>
        [Fact]
        public void TestBindClosable() {
            _wrapper.SetContextAttribute( AngularConst.BindClosable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzClosable]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确定按钮是否加载状态
        /// </summary>
        [Fact]
        public void TestOkLoading() {
            _wrapper.SetContextAttribute( UiConst.OkLoading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzOkLoading]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用确定按钮
        /// </summary>
        [Fact]
        public void TestOkDisabled() {
            _wrapper.SetContextAttribute( UiConst.OkDisabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzOkDisabled]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用确定按钮
        /// </summary>
        [Fact]
        public void TestBindOkDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindOkDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzOkDisabled]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试取消按钮是否加载状态
        /// </summary>
        [Fact]
        public void TestCancelLoading() {
            _wrapper.SetContextAttribute( UiConst.CancelLoading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCancelLoading]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用取消按钮
        /// </summary>
        [Fact]
        public void TestCancelDisabled() {
            _wrapper.SetContextAttribute( UiConst.CancelDisabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCancelDisabled]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用取消按钮
        /// </summary>
        [Fact]
        public void TestBindCancelDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindCancelDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCancelDisabled]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持键盘ESC键关闭
        /// </summary>
        [Fact]
        public void TestKeyboard() {
            _wrapper.SetContextAttribute( UiConst.Keyboard, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzKeyboard]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持键盘ESC键关闭
        /// </summary>
        [Fact]
        public void TestBindKeyboard() {
            _wrapper.SetContextAttribute( AngularConst.BindKeyboard, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzKeyboard]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否垂直居中显示
        /// </summary>
        [Fact]
        public void TestCentered() {
            _wrapper.SetContextAttribute( UiConst.Centered, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCentered]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否垂直居中显示
        /// </summary>
        [Fact]
        public void TestBindCentered() {
            _wrapper.SetContextAttribute( AngularConst.BindCentered, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCentered]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.SetContextAttribute( UiConst.Content, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzContent]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试组件参数
        /// </summary>
        [Fact]
        public void TestComponentParams() {
            _wrapper.SetContextAttribute( UiConst.ComponentParams, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzComponentParams]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部内容
        /// </summary>
        [Fact]
        public void TestFooter() {
            _wrapper.SetContextAttribute( UiConst.Footer, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzFooter]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试z-index
        /// </summary>
        [Fact]
        public void TestZIndex() {
            _wrapper.SetContextAttribute( UiConst.ZIndex, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzZIndex=\"1\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试z-index
        /// </summary>
        [Fact]
        public void TestBindZIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindZIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzZIndex]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            _wrapper.SetContextAttribute( UiConst.Width, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzWidth=\"1\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestBindWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzWidth]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对话框外层容器样式类名
        /// </summary>
        [Fact]
        public void TestWrapClassName() {
            _wrapper.SetContextAttribute( UiConst.WrapClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzWrapClassName=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对话框外层容器样式类名
        /// </summary>
        [Fact]
        public void TestBindWrapClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindWrapClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzWrapClassName]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对话框样式类名
        /// </summary>
        [Fact]
        public void TestClassName() {
            _wrapper.SetContextAttribute( UiConst.ClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzClassName=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对话框样式类名
        /// </summary>
        [Fact]
        public void TestBindClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzClassName]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试浮层样式
        /// </summary>
        [Fact]
        public void TestModalStyle() {
            _wrapper.SetContextAttribute( UiConst.ModalStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzStyle]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzTitle=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzTitle]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭图标
        /// </summary>
        [Fact]
        public void TestCloseIcon() {
            _wrapper.SetContextAttribute( UiConst.CloseIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzCloseIcon=\"account-book\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭图标
        /// </summary>
        [Fact]
        public void TestBindCloseIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCloseIcon]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试遮罩样式
        /// </summary>
        [Fact]
        public void TestMaskStyle() {
            _wrapper.SetContextAttribute( UiConst.MaskStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzMaskStyle]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试主体样式
        /// </summary>
        [Fact]
        public void TestBodyStyle() {
            _wrapper.SetContextAttribute( UiConst.BodyStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzBodyStyle]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确认按钮文字
        /// </summary>
        [Fact]
        public void TestOkText() {
            _wrapper.SetContextAttribute( UiConst.OkText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzOkText=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确认按钮文字
        /// </summary>
        [Fact]
        public void TestBindOkText() {
            _wrapper.SetContextAttribute( AngularConst.BindOkText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzOkText]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试取消按钮文字
        /// </summary>
        [Fact]
        public void TestCancelText() {
            _wrapper.SetContextAttribute( UiConst.CancelText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzCancelText=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试取消按钮文字
        /// </summary>
        [Fact]
        public void TestBindCancelText() {
            _wrapper.SetContextAttribute( AngularConst.BindCancelText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzCancelText]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确认按钮类型
        /// </summary>
        [Fact]
        public void TestOkType() {
            _wrapper.SetContextAttribute( UiConst.OkType, ButtonType.Primary );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzOkType=\"primary\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确认按钮类型
        /// </summary>
        [Fact]
        public void TestBindOkType() {
            _wrapper.SetContextAttribute( AngularConst.BindOkType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzOkType]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确认按钮是否为危险按钮
        /// </summary>
        [Fact]
        public void TestOkDanger() {
            _wrapper.SetContextAttribute( UiConst.OkDanger, true );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzOkDanger]=\"true\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确认按钮是否为危险按钮
        /// </summary>
        [Fact]
        public void TestBindOkDanger() {
            _wrapper.SetContextAttribute( AngularConst.BindOkDanger, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzOkDanger]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestIconType() {
            _wrapper.SetContextAttribute( UiConst.IconType, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzIconType=\"account-book\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestBindIconType() {
            _wrapper.SetContextAttribute( AngularConst.BindIconType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzIconType]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestAutofocus() {
            _wrapper.SetContextAttribute( UiConst.Autofocus, ModalAutofocus.Cancel );
            var result = new StringBuilder();
            result.Append( "<nz-modal nzAutofocus=\"cancel\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestBindAutofocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutofocus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal [nzAutofocus]=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试子内容
        /// </summary>
        [Fact]
        public void TestAppendContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal>a</nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试确定事件
        /// </summary>
        [Fact]
        public void TestOnOk() {
            _wrapper.SetContextAttribute( UiConst.OnOk, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal (nzOnOk)=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试取消事件
        /// </summary>
        [Fact]
        public void TestOnCancel() {
            _wrapper.SetContextAttribute( UiConst.OnCancel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal (nzOnCancel)=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试打开后事件
        /// </summary>
        [Fact]
        public void TestOnAfterOpen() {
            _wrapper.SetContextAttribute( UiConst.OnAfterOpen, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal (nzAfterOpen)=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭后事件
        /// </summary>
        [Fact]
        public void TestOnAfterClose() {
            _wrapper.SetContextAttribute( UiConst.OnAfterClose, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-modal (nzAfterClose)=\"a\"></nz-modal>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}