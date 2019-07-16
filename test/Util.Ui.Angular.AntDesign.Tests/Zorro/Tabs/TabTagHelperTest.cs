using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tabs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tabs {
    /// <summary>
    /// 标签选项卡测试
    /// </summary>
    public class TabTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 标签选项卡
        /// </summary>
        private readonly TabTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabTagHelper();
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
            result.Append( "<nz-tab></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-tab #a=\"\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<nz-tab nzTitle=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试点击选项卡事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<nz-tab (nzClick)=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试延迟加载
        /// </summary>
        [Fact]
        public void TestLazy() {
            var attributes = new TagHelperAttributeList { { UiConst.Lazy, true } };
            TagHelperContent content = new DefaultTagHelperContent();
            content.AppendHtml( "a" );
            var result = new String();
            result.Append( "<nz-tab>" );
            result.Append( "<ng-template nz-tab=\"\">a</ng-template>" );
            result.Append( "</nz-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes,content: content ) );
        }
    }
}