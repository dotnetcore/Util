using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Tabs.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tabs {
    /// <summary>
    /// 选项卡测试
    /// </summary>
    public class TabTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 选项卡
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
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-tab #a=\"\"><ng-template mat-tab-label=\"\"></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\">a</ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Add } };
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"><mat-icon>add</mat-icon></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Bus } };
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"><i class=\"fa fa-bus\"></i></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标签和Material图标
        /// </summary>
        [Fact]
        public void TestLabel_MaterialIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" },{ UiConst.MaterialIcon, MaterialIcon.Add } };
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"><mat-icon>add</mat-icon>a</ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<mat-tab [disabled]=\"a\"><ng-template mat-tab-label=\"\"></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试延迟加载
        /// </summary>
        [Fact]
        public void TestLazyLoad() {
            var attributes = new TagHelperAttributeList { { UiConst.LazyLoad,true } };
            var content = new DefaultTagHelperContent();
            content.AppendHtml( "a" );
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"></ng-template><ng-template matTabContent=\"\">a</ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( attributes,content: content ) );
        }

        /// <summary>
        /// 测试非延迟加载
        /// </summary>
        [Fact]
        public void TestNoLazyLoad() {
            var content = new DefaultTagHelperContent();
            content.AppendHtml( "a" );
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"></ng-template>a</mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( content: content ) );
        }
    }
}