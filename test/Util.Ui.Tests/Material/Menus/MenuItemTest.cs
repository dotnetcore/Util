using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Menus;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Menus {
    /// <summary>
    /// 菜单项测试
    /// </summary>
    public class MenuItemTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 菜单项
        /// </summary>
        private readonly MenuItem _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuItemTest( ITestOutputHelper output ) {
            _output = output;
            _component = new MenuItem();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( MenuItem component ) {
            component.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = component.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"><span>a</span></button>" );
            Assert.Equal( result.ToString(), GetResult( _component.Text("a") ) );
        }

        /// <summary>
        /// 测试Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"><mat-icon>add</mat-icon></button>" );
            Assert.Equal( result.ToString(), GetResult( _component.Icon( MaterialIcon.Add ) ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"><i class=\"fa fa-bus fa-lg\"></i></button>" );
            Assert.Equal( result.ToString(), GetResult( _component.Icon( FontAwesomeIcon.Bus ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var result = new String();
            result.Append( "<button mat-menu-item=\"\" [disabled]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable( "a" ) ) );
        }

        /// <summary>
        /// 测试路由链接地址
        /// </summary>
        [Fact]
        public void TestLink() {
            var result = new String();
            result.Append( "<a mat-menu-item=\"\" routerLink=\"a\"><mat-icon>add</mat-icon><span>b</span></a>" );
            Assert.Equal( result.ToString(), GetResult( _component.Link("a").Text( "b" ).Icon( MaterialIcon.Add ) ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var result = new String();
            result.Append( "<button (click)=\"a\" mat-menu-item=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnClick( "a" ) ) );
        }

        /// <summary>
        /// 测试设置子菜单
        /// </summary>
        [Fact]
        public void TestMenu() {
            var result = new String();
            result.Append( "<button mat-menu-item=\"\" [matMenuTriggerFor]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _component.Menu( "a" ) ) );
        }
    }
}