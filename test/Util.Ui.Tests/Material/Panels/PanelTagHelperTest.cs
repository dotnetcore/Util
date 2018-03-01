using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material;
using Util.Ui.Material.Panels.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Panels {
    /// <summary>
    /// 面板测试
    /// </summary>
    public class PanelTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 面板
        /// </summary>
        private readonly PanelTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PanelTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new PanelTagHelper();
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
            result.Append( "<mat-expansion-panel></mat-expansion-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-expansion-panel #a=\"\"></mat-expansion-panel>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试打开事件
        /// </summary>
        [Fact]
        public void TestOnOpen() {
            var attributes = new TagHelperAttributeList { { UiConst.OnOpen, "a" } };
            var result = new String();
            result.Append( "<mat-expansion-panel (opened)=\"a\"></mat-expansion-panel>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试关闭事件
        /// </summary>
        [Fact]
        public void TestOnClose() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClose, "a" } };
            var result = new String();
            result.Append( "<mat-expansion-panel (closed)=\"a\"></mat-expansion-panel>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试隐藏折叠开关
        /// </summary>
        [Fact]
        public void TestHideToggle() {
            var attributes = new TagHelperAttributeList { { MaterialConst.HideToggle, true } };
            var result = new String();
            result.Append( "<mat-expansion-panel hideToggle=\"true\"></mat-expansion-panel>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试展开
        /// </summary>
        [Fact]
        public void TestExpanded() {
            var attributes = new TagHelperAttributeList { { UiConst.Expanded, "a" } };
            var result = new String();
            result.Append( "<mat-expansion-panel [expanded]=\"a\"></mat-expansion-panel>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<mat-expansion-panel [disabled]=\"a\"></mat-expansion-panel>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}