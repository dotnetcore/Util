using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Toolbars.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Toolbars {
    /// <summary>
    /// 工具栏测试
    /// </summary>
    public class ToolbarTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 工具栏
        /// </summary>
        private readonly ToolbarTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ToolbarTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ToolbarTagHelper();
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
            result.Append( "<mat-toolbar></mat-toolbar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-toolbar #a=\"\"></mat-toolbar>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<mat-toolbar color=\"primary\"></mat-toolbar>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}