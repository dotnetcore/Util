using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Menus {
    /// <summary>
    /// 菜单项测试
    /// </summary>
    public partial class MenuItemTagHelperTest {
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
        public MenuItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new MenuItemTagHelper().ToWrapper();
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
            result.Append( "<li nz-menu-item=\"\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzDisabled]=\"true\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzDisabled]=\"a\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中
        /// </summary>
        [Fact]
        public void TestSelected() {
            _wrapper.SetContextAttribute( UiConst.Selected, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzSelected]=\"true\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中
        /// </summary>
        [Fact]
        public void TestBindSelected() {
            _wrapper.SetContextAttribute( AngularConst.BindSelected, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzSelected]=\"a\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试危险状态
        /// </summary>
        [Fact]
        public void TestDanger() {
            _wrapper.SetContextAttribute( UiConst.Danger, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzDanger]=\"true\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试危险状态
        /// </summary>
        [Fact]
        public void TestBindDanger() {
            _wrapper.SetContextAttribute( AngularConst.BindDanger, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzDanger]=\"a\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试匹配路由
        /// </summary>
        [Fact]
        public void TestMatchRouter() {
            _wrapper.SetContextAttribute( UiConst.MatchRouter, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzMatchRouter]=\"true\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试匹配路由
        /// </summary>
        [Fact]
        public void TestBindMatchRouter() {
            _wrapper.SetContextAttribute( AngularConst.BindMatchRouter, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzMatchRouter]=\"a\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试精确匹配路由
        /// </summary>
        [Fact]
        public void TestMatchRouterExact() {
            _wrapper.SetContextAttribute( UiConst.MatchRouterExact, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzMatchRouterExact]=\"true\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试精确匹配路由
        /// </summary>
        [Fact]
        public void TestBindMatchRouterExact() {
            _wrapper.SetContextAttribute( AngularConst.BindMatchRouterExact, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\" [nzMatchRouterExact]=\"a\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">a</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<li (click)=\"a\" nz-menu-item=\"\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}