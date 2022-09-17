using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Menus {
    /// <summary>
    /// 子菜单测试
    /// </summary>
    public class SubMenuTagHelperTest {
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
        public SubMenuTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SubMenuTagHelper().ToWrapper();
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
            result.Append( "<li nz-submenu=\"\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" nzTitle=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [nzTitle]=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [nzDisabled]=\"true\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [nzDisabled]=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestIcon() {
            _wrapper.SetContextAttribute( UiConst.Icon, AntDesignIcon.Alert );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" nzIcon=\"alert\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestBindIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [nzIcon]=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开
        /// </summary>
        [Fact]
        public void TestOpen() {
            _wrapper.SetContextAttribute( UiConst.Open, true );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [nzOpen]=\"true\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开
        /// </summary>
        [Fact]
        public void TestBindOpen() {
            _wrapper.SetContextAttribute( AngularConst.BindOpen, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [nzOpen]=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开
        /// </summary>
        [Fact]
        public void TestBindonOpen() {
            _wrapper.SetContextAttribute( AngularConst.BindonOpen, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [(nzOpen)]=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义子菜单容器类名
        /// </summary>
        [Fact]
        public void TestMenuClassName() {
            _wrapper.SetContextAttribute( UiConst.MenuClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" nzMenuClassName=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义子菜单容器类名
        /// </summary>
        [Fact]
        public void TestBindMenuClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindMenuClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\" [nzMenuClassName]=\"a\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-submenu=\"\"><ul>a</ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开变更事件
        /// </summary>
        [Fact]
        public void TestOnOpenChange() {
            _wrapper.SetContextAttribute( UiConst.OnOpenChange, "a" );
            var result = new StringBuilder();
            result.Append( "<li (nzOpenChange)=\"a\" nz-submenu=\"\"><ul></ul></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}