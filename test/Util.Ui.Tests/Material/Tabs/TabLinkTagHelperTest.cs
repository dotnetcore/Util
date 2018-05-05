using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Tabs.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tabs {
    /// <summary>
    /// 链接选项卡测试
    /// </summary>
    public class TabLinkTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 链接选项卡
        /// </summary>
        private readonly TabLinkTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabLinkTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabLinkTagHelper();
            Id.SetId( "id" );
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
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "b" } };
            var result = new String();
            result.Append( "<a #b=\"\" #m_b=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_b.isActive\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestLink() {
            var attributes = new TagHelperAttributeList { { UiConst.Link, "b" } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLink=\"b\" routerLinkActive=\"\" [active]=\"m_id.isActive\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestBindLink() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindLink, "b" } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\" [routerLink]=\"b\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "label" } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\">label</a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Add } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"><mat-icon>add</mat-icon></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Bus } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"><i class=\"fa fa-bus\"></i></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标签和Material图标
        /// </summary>
        [Fact]
        public void TestLabel_MaterialIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" }, { UiConst.MaterialIcon, MaterialIcon.Add } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"><mat-icon>add</mat-icon>a</a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\" [disabled]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试ngIf
        /// </summary>
        [Fact]
        public void TestIf() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgIf, "a" } };
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" *ngIf=\"a\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}