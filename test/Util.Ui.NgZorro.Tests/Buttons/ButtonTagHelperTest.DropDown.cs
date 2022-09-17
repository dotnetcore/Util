using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 下拉菜单相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试下拉菜单
        /// </summary>
        [Fact]
        public void TestDropdownMenu() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenu, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nz-dropdown=\"\" [nzDropdownMenu]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单弹出位置
        /// </summary>
        [Fact]
        public void TestDropdownMenuPlacement() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuPlacement, DropdownMenuPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzPlacement=\"bottomLeft\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单弹出位置
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzPlacement]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单触发方式
        /// </summary>
        [Fact]
        public void TestDropdownMenuTrigger() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuTrigger, DropdownMenuTrigger.Click );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzTrigger=\"click\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单触发方式
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzTrigger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击隐藏下拉菜单
        /// </summary>
        [Fact]
        public void TestDropdownMenuClickHide() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuClickHide, false );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzClickHide]=\"false\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击隐藏下拉菜单
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuClickHide() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuClickHide, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzClickHide]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单可见性
        /// </summary>
        [Fact]
        public void TestDropdownMenuVisible() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuVisible, false );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzVisible]=\"false\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单可见性
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzVisible]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单可见性
        /// </summary>
        [Fact]
        public void TestBindonDropdownMenuVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonDropdownMenuVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [(nzVisible)]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单根元素类名
        /// </summary>
        [Fact]
        public void TestDropdownMenuOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzOverlayClassName=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单根元素类名
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzOverlayClassName]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单根元素样式
        /// </summary>
        [Fact]
        public void TestDropdownMenuOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzOverlayStyle]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<button (nzVisibleChange)=\"a\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
