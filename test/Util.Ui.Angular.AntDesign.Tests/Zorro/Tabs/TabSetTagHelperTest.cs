using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tabs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tabs {
    /// <summary>
    /// 标签页测试
    /// </summary>
    public class TabSetTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 标签页
        /// </summary>
        private readonly TabSetTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabSetTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabSetTagHelper();
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
            result.Append( "<nz-tabset></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-tabset #a=\"\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中的选项卡索引
        /// </summary>
        [Fact]
        public void TestSelectedIndex() {
            var attributes = new TagHelperAttributeList { { UiConst.SelectedIndex, 2 } };
            var result = new String();
            result.Append( "<nz-tabset [nzSelectedIndex]=\"2\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中的选项卡索引
        /// </summary>
        [Fact]
        public void TestBindOnSelectedIndex() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindOnSelectedIndex, "a" } };
            var result = new String();
            result.Append( "<nz-tabset [(nzSelectedIndex)]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选项卡索引变更事件
        /// </summary>
        [Fact]
        public void TestOnSelectedIndexChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnSelectedIndexChange,"a" } };
            var result = new String();
            result.Append( "<nz-tabset (nzSelectedIndexChange)=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}