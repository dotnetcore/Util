using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Commons.Configs;
using Util.Ui.Material.Panels.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Panels {
    /// <summary>
    /// 面板头部测试
    /// </summary>
    public class PanelHeaderTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 面板头部
        /// </summary>
        private readonly PanelHeaderTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PanelHeaderTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new PanelHeaderTagHelper();
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
            result.Append( "<mat-expansion-panel-header></mat-expansion-panel-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-expansion-panel-header #a=\"\"></mat-expansion-panel-header>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试面板折叠时标题的高度
        /// </summary>
        [Fact]
        public void TestCollapsedHeight() {
            var attributes = new TagHelperAttributeList { { MaterialConst.CollapsedHeight, 1 } };
            var result = new String();
            result.Append( "<mat-expansion-panel-header collapsedHeight=\"1px\"></mat-expansion-panel-header>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试面板展开时标题的高度
        /// </summary>
        [Fact]
        public void TestExpandedHeight() {
            var attributes = new TagHelperAttributeList { { MaterialConst.ExpandedHeight, 1 } };
            var result = new String();
            result.Append( "<mat-expansion-panel-header expandedHeight=\"1px\"></mat-expansion-panel-header>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}