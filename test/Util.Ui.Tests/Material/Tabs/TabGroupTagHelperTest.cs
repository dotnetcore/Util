using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Commons.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Tabs.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tabs {
    /// <summary>
    /// 选项卡组测试
    /// </summary>
    public class TabGroupTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 选项卡组
        /// </summary>
        private readonly TabGroupTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabGroupTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabGroupTagHelper();
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
            result.Append( "<mat-tab-group></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-tab-group #a=\"\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置背景色
        /// </summary>
        [Fact]
        public void TestBackgroundColor() {
            var attributes = new TagHelperAttributeList { { UiConst.BackgroundColor, Color.Primary } };
            var result = new String();
            result.Append( "<mat-tab-group backgroundColor=\"primary\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置主题色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<mat-tab-group color=\"primary\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置固定高度
        /// </summary>
        [Fact]
        public void TestHeight() {
            var attributes = new TagHelperAttributeList { { UiConst.Height, 200 } };
            var result = new String();
            result.Append( "<mat-tab-group style=\"height:200px\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置动态高度
        /// </summary>
        [Fact]
        public void TestDynamicHeight() {
            var attributes = new TagHelperAttributeList { { MaterialConst.DynamicHeight, true } };
            var result = new String();
            result.Append( "<mat-tab-group dynamicHeight=\"\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试拉伸选项卡
        /// </summary>
        [Fact]
        public void TestStretch() {
            var attributes = new TagHelperAttributeList { { UiConst.Stretch, true } };
            var result = new String();
            result.Append( "<mat-tab-group mat-stretch-tabs=\"\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中索引
        /// </summary>
        [Fact]
        public void TestSelectedIndex() {
            var attributes = new TagHelperAttributeList { { UiConst.SelectedIndex, "a" } };
            var result = new String();
            result.Append( "<mat-tab-group [(selectedIndex)]=\"a\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标题位置
        /// </summary>
        [Fact]
        public void TestHeaderPosition() {
            var attributes = new TagHelperAttributeList { { MaterialConst.HeaderPosition, YPosition.Below } };
            var result = new String();
            result.Append( "<mat-tab-group headerPosition=\"below\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}