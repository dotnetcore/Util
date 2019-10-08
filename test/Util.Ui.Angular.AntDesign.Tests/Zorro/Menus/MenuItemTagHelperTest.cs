using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Menus;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Menus {
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
            result.Append( "<li nz-menu-item=\"\"></li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<li #a=\"\" nz-menu-item=\"\"></li>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "true" } };
            var result = new String();
            result.Append( "<li nz-menu-item=\"\" [nzDisabled]=\"true\"></li>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中
        /// </summary>
        [Fact]
        public void TestSelected() {
            var attributes = new TagHelperAttributeList { { UiConst.Selected, "true" } };
            var result = new String();
            result.Append( "<li nz-menu-item=\"\" [nzSelected]=\"true\"></li>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<li (click)=\"a\" nz-menu-item=\"\"></li>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}