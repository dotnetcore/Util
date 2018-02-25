using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Commons.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.SideNavs.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.SideNavs {
    /// <summary>
    /// 侧边栏导航测试
    /// </summary>
    public class DrawerTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 侧边栏导航
        /// </summary>
        private readonly DrawerTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DrawerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DrawerTagHelper();
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
            result.Append( "<mat-drawer></mat-drawer>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-drawer #a=\"\"></mat-drawer>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置位置
        /// </summary>
        [Fact]
        public void TestPosition() {
            var attributes = new TagHelperAttributeList { { UiConst.Position, XPosition.Right } };
            var result = new String();
            result.Append( "<mat-drawer position=\"end\"></mat-drawer>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置打开
        /// </summary>
        [Fact]
        public void TestOpened() {
            var attributes = new TagHelperAttributeList { { UiConst.Opened, true } };
            var result = new String();
            result.Append( "<mat-drawer opened=\"true\"></mat-drawer>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试打开模式
        /// </summary>
        [Fact]
        public void TestMode() {
            var attributes = new TagHelperAttributeList { { UiConst.Mode, SideNavMode.Side } };
            var result = new String();
            result.Append( "<mat-drawer mode=\"side\"></mat-drawer>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用关闭
        /// </summary>
        [Fact]
        public void TestDisableClose() {
            var attributes = new TagHelperAttributeList { { MaterialConst.DisableClose, true } };
            var result = new String();
            result.Append( "<mat-drawer disableClose=\"true\"></mat-drawer>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            var attributes = new TagHelperAttributeList { { UiConst.Width, 50 } };
            var result = new String();
            result.Append( "<mat-drawer style=\"width:50px\"></mat-drawer>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}