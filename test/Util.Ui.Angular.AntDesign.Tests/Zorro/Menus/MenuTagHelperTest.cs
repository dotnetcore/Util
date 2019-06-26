using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Dividers;
using Util.Ui.Zorro.Menus;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Menus {
    /// <summary>
    /// 菜单测试
    /// </summary>
    public class MenuTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 菜单
        /// </summary>
        private readonly MenuTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new MenuTagHelper();
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
            result.Append( "<ul nz-menu=\"\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<ul #a=\"\" nz-menu=\"\"></ul>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestMode() {
            var attributes = new TagHelperAttributeList { { UiConst.Mode, MenuMode.Inline } };
            var result = new String();
            result.Append( "<ul nz-menu=\"\" nzMode=\"inline\"></ul>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试允许选中
        /// </summary>
        [Fact]
        public void TestSelectable() {
            var attributes = new TagHelperAttributeList { { UiConst.Selectable, false } };
            var result = new String();
            result.Append( "<ul nz-menu=\"\" [nzSelectable]=\"false\"></ul>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试主题
        /// </summary>
        [Fact]
        public void TestTheme() {
            var attributes = new TagHelperAttributeList { { UiConst.Theme, MenuTheme.Light } };
            var result = new String();
            result.Append( "<ul nz-menu=\"\" nzTheme=\"light\"></ul>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试折叠状态
        /// </summary>
        [Fact]
        public void TestInlineCollapsed() {
            var attributes = new TagHelperAttributeList { { UiConst.InlineCollapsed, false } };
            var result = new String();
            result.Append( "<ul nz-menu=\"\" [nzInlineCollapsed]=\"false\"></ul>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试缩进宽度
        /// </summary>
        [Fact]
        public void TestInlineIndent() {
            var attributes = new TagHelperAttributeList { { UiConst.InlineIndent, 2 } };
            var result = new String();
            result.Append( "<ul nz-menu=\"\" [nzInlineIndent]=\"2\"></ul>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<ul (nzClick)=\"a\" nz-menu=\"\"></ul>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}