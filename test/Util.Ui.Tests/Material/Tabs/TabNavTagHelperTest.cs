using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Tabs.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tabs {
    /// <summary>
    /// 导航选项卡测试
    /// </summary>
    public class TabNavTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 导航选项卡
        /// </summary>
        private readonly TabNavTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabNavTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabNavTagHelper();
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
            result.Append( "<nav mat-tab-nav-bar=\"\"></nav><router-outlet></router-outlet>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nav #a=\"\" mat-tab-nav-bar=\"\"></nav><router-outlet></router-outlet>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置背景色
        /// </summary>
        [Fact]
        public void TestBackgroundColor() {
            var attributes = new TagHelperAttributeList { { UiConst.BackgroundColor, Color.Primary } };
            var result = new String();
            result.Append( "<nav backgroundColor=\"primary\" mat-tab-nav-bar=\"\"></nav><router-outlet></router-outlet>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置主题色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<nav color=\"primary\" mat-tab-nav-bar=\"\"></nav><router-outlet></router-outlet>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试ngIf
        /// </summary>
        [Fact]
        public void TestIf() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgIf, "a" } };
            var result = new String();
            result.Append( "<nav *ngIf=\"a\" mat-tab-nav-bar=\"\"></nav><router-outlet></router-outlet>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}