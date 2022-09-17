using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Drawers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Drawers {
    /// <summary>
    /// 抽屉测试
    /// </summary>
    public class DrawerTagHelperTest {
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
        public DrawerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DrawerTagHelper().ToWrapper();
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
            result.Append( "<nz-drawer></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可关闭
        /// </summary>
        [Fact]
        public void TestClosable() {
            _wrapper.SetContextAttribute( UiConst.Closable, true );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzClosable]=\"true\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可关闭
        /// </summary>
        [Fact]
        public void TestBindClosable() {
            _wrapper.SetContextAttribute( AngularConst.BindClosable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzClosable]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭图标
        /// </summary>
        [Fact]
        public void TestCloseIcon() {
            _wrapper.SetContextAttribute( UiConst.CloseIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzCloseIcon=\"account-book\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭图标
        /// </summary>
        [Fact]
        public void TestBindCloseIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzCloseIcon]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击遮罩是否允许关闭
        /// </summary>
        [Fact]
        public void TestMaskClosable() {
            _wrapper.SetContextAttribute( UiConst.MaskClosable, true );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzMaskClosable]=\"true\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击遮罩是否允许关闭
        /// </summary>
        [Fact]
        public void TestBindMaskClosable() {
            _wrapper.SetContextAttribute( AngularConst.BindMaskClosable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzMaskClosable]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示遮罩
        /// </summary>
        [Fact]
        public void TestMask() {
            _wrapper.SetContextAttribute( UiConst.Mask, true );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzMask]=\"true\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示遮罩
        /// </summary>
        [Fact]
        public void TestBindMask() {
            _wrapper.SetContextAttribute( AngularConst.BindMask, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzMask]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试导航时是否关闭
        /// </summary>
        [Fact]
        public void TestCloseOnNavigation() {
            _wrapper.SetContextAttribute( UiConst.CloseOnNavigation, true );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzCloseOnNavigation]=\"true\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试导航时是否关闭
        /// </summary>
        [Fact]
        public void TestBindCloseOnNavigation() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseOnNavigation, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzCloseOnNavigation]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试遮罩样式
        /// </summary>
        [Fact]
        public void TestMaskStyle() {
            _wrapper.SetContextAttribute( UiConst.MaskStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzMaskStyle]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持键盘ESC键关闭
        /// </summary>
        [Fact]
        public void TestKeyboard() {
            _wrapper.SetContextAttribute( UiConst.Keyboard, true );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzKeyboard]=\"true\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持键盘ESC键关闭
        /// </summary>
        [Fact]
        public void TestBindKeyboard() {
            _wrapper.SetContextAttribute( AngularConst.BindKeyboard, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzKeyboard]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试主体样式
        /// </summary>
        [Fact]
        public void TestBodyStyle() {
            _wrapper.SetContextAttribute( UiConst.BodyStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzBodyStyle]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzTitle=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzTitle]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试页脚
        /// </summary>
        [Fact]
        public void TestFooter() {
            _wrapper.SetContextAttribute( UiConst.Footer, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzFooter=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试页脚
        /// </summary>
        [Fact]
        public void TestBindFooter() {
            _wrapper.SetContextAttribute( AngularConst.BindFooter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzFooter]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可见
        /// </summary>
        [Fact]
        public void TestVisible() {
            _wrapper.SetContextAttribute( UiConst.Visible, true );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzVisible]=\"true\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可见
        /// </summary>
        [Fact]
        public void TestBindVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzVisible]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可见
        /// </summary>
        [Fact]
        public void TestBindonVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [(nzVisible)]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试抽屉方向
        /// </summary>
        [Fact]
        public void TestPlacement() {
            _wrapper.SetContextAttribute( UiConst.Placement, DrawerPlacement.Bottom );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzPlacement=\"bottom\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试抽屉方向
        /// </summary>
        [Fact]
        public void TestBindPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzPlacement]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            _wrapper.SetContextAttribute( UiConst.Width, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzWidth=\"1\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestBindWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzWidth]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试高度
        /// </summary>
        [Fact]
        public void TestHeight() {
            _wrapper.SetContextAttribute( UiConst.Height, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzHeight=\"1\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试高度
        /// </summary>
        [Fact]
        public void TestBindHeight() {
            _wrapper.SetContextAttribute( AngularConst.BindHeight, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzHeight]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试X坐标偏移量
        /// </summary>
        [Fact]
        public void TestOffsetX() {
            _wrapper.SetContextAttribute( UiConst.OffsetX, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzOffsetX=\"1\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试X坐标偏移量
        /// </summary>
        [Fact]
        public void TestBindOffsetX() {
            _wrapper.SetContextAttribute( AngularConst.BindOffsetX, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzOffsetX]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Y坐标偏移量
        /// </summary>
        [Fact]
        public void TestOffsetY() {
            _wrapper.SetContextAttribute( UiConst.OffsetY, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzOffsetY=\"1\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Y坐标偏移量
        /// </summary>
        [Fact]
        public void TestBindOffsetY() {
            _wrapper.SetContextAttribute( AngularConst.BindOffsetY, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzOffsetY]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对话框外层容器样式类名
        /// </summary>
        [Fact]
        public void TestWrapClassName() {
            _wrapper.SetContextAttribute( UiConst.WrapClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzWrapClassName=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对话框外层容器样式类名
        /// </summary>
        [Fact]
        public void TestBindWrapClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindWrapClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzWrapClassName]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试z-index
        /// </summary>
        [Fact]
        public void TestZIndex() {
            _wrapper.SetContextAttribute( UiConst.ZIndex, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-drawer nzZIndex=\"1\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试z-index
        /// </summary>
        [Fact]
        public void TestBindZIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindZIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer [nzZIndex]=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer>a</nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭事件
        /// </summary>
        [Fact]
        public void TestOnClose() {
            _wrapper.SetContextAttribute( UiConst.OnClose, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-drawer (nzOnClose)=\"a\"></nz-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}