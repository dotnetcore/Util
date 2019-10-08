using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Panels.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Panels {
    /// <summary>
    /// 手风琴测试
    /// </summary>
    public class AccordionTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 手风琴
        /// </summary>
        private readonly AccordionTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AccordionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new AccordionTagHelper();
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
            result.Append( "<mat-accordion></mat-accordion>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-accordion #a=\"\"></mat-accordion>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置多展开状态
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, true } };
            var result = new String();
            result.Append( "<mat-accordion multi=\"true\"></mat-accordion>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示模式
        /// </summary>
        [Fact]
        public void TestDisplayMode() {
            var attributes = new TagHelperAttributeList { { MaterialConst.DisplayMode, AccordionDisplayMode.Flat } };
            var result = new String();
            result.Append( "<mat-accordion displayMode=\"flat\"></mat-accordion>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}