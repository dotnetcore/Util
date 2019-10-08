using System.IO;
using System.Text.Encodings.Web;
using Util.Helpers;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Tabs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tabs {
    /// <summary>
    /// 链接选项卡测试
    /// </summary>
    public class TabLinkTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 链接选项卡
        /// </summary>
        private readonly TabLink _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabLinkTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabLink();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TabLink component ) {
            component.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = component.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"></a>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<a #b=\"\" #m_b=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_b.isActive\"></a>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "b" ) ) );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestLink() {
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLink=\"b\" routerLinkActive=\"\" [active]=\"m_id.isActive\"></a>" );
            Assert.Equal( result.ToString(), GetResult( _component.Link( "b" ) ) );
        }

        /// <summary>
        /// 测试添加标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\">label</a>" );
            Assert.Equal( result.ToString(), GetResult( _component.Label( "label" ) ) );
        }

        /// <summary>
        /// 测试Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"><mat-icon>add</mat-icon></a>" );
            Assert.Equal( result.ToString(), GetResult( _component.Icon( MaterialIcon.Add ) ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\"><i class=\"fa fa-bus\"></i></a>" );
            Assert.Equal( result.ToString(), GetResult( _component.Icon( FontAwesomeIcon.Bus ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var result = new String();
            result.Append( "<a #m_id=\"routerLinkActive\" mat-tab-link=\"\" routerLinkActive=\"\" [active]=\"m_id.isActive\" [disabled]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable( "a" ) ) );
        }
    }
}