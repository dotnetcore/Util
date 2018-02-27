using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Panels.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Panels {
    /// <summary>
    /// 面板内容测试
    /// </summary>
    public class PanelContentTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 面板内容
        /// </summary>
        private readonly PanelContentTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PanelContentTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new PanelContentTagHelper();
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
            result.Append( "<ng-template matExpansionPanelContent=\"\"></ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<ng-template #a=\"\" matExpansionPanelContent=\"\"></ng-template>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}