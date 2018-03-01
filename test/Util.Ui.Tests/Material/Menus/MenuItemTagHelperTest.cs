using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material;
using Util.Ui.Material.Menus.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Menus {
    /// <summary>
    /// 菜单项测试
    /// </summary>
    public class MenuItemTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 菜单项
        /// </summary>
        private readonly MenuItemTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new MenuItemTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"><span>a</span></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Add } };
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"><mat-icon>add</mat-icon></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Bus } };
            var result = new String();
            result.Append( "<button mat-menu-item=\"\"><i class=\"fa fa-bus\"></i></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<button mat-menu-item=\"\" [disabled]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试路由链接地址
        /// </summary>
        [Fact]
        public void TestLink() {
            var attributes = new TagHelperAttributeList { { UiConst.Link, "a" }, { UiConst.Label, "b" }, { UiConst.MaterialIcon, MaterialIcon.Add } };
            var result = new String();
            result.Append( "<a mat-menu-item=\"\" routerLink=\"a\"><mat-icon>add</mat-icon><span>b</span></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<button (click)=\"a\" mat-menu-item=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置子菜单
        /// </summary>
        [Fact]
        public void TestMenuId() {
            var attributes = new TagHelperAttributeList { { MaterialConst.MenuId, "a" } };
            var result = new String();
            result.Append( "<button mat-menu-item=\"\" [matMenuTriggerFor]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}