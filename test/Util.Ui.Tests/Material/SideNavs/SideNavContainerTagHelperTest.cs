using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.SideNavs.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.SideNavs {
    /// <summary>
    /// 侧边栏导航容器测试
    /// </summary>
    public class SideNavContainerTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 侧边栏导航容器
        /// </summary>
        private readonly SideNavContainerTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SideNavContainerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new SideNavContainerTagHelper();
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
            result.Append( "<mat-sidenav-container></mat-sidenav-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-sidenav-container #a=\"\"></mat-sidenav-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置全屏
        /// </summary>
        [Fact]
        public void TestFullscreen() {
            var attributes = new TagHelperAttributeList { { UiConst.Fullscreen, true } };
            var result = new String();
            result.Append( "<mat-sidenav-container fullscreen=\"\"></mat-sidenav-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}