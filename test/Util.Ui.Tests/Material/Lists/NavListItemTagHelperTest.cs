using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Lists {
    /// <summary>
    /// 导航列表项测试
    /// </summary>
    public class NavListItemTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 导航列表项
        /// </summary>
        private readonly NavListItemTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public NavListItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new NavListItemTagHelper();
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
            result.Append( "<a mat-list-item=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<a #a=\"\" mat-list-item=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加循环
        /// </summary>
        [Fact]
        public void TestNgFor() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgFor, "a" } };
            var result = new String();
            result.Append( "<a *ngFor=\"a\" mat-list-item=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加路由链接
        /// </summary>
        [Fact]
        public void TestLink() {
            var attributes = new TagHelperAttributeList { { UiConst.Link, "a" } };
            var result = new String();
            result.Append( "<a mat-list-item=\"\" routerLink=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加路由链接属性绑定
        /// </summary>
        [Fact]
        public void TestBindLink() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindLink, "a" } };
            var result = new String();
            result.Append( "<a mat-list-item=\"\" [routerLink]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加路由激活
        /// </summary>
        [Fact]
        public void TestActive() {
            var attributes = new TagHelperAttributeList { { UiConst.Active, "a" } };
            var result = new String();
            result.Append( "<a mat-list-item=\"\" routerLinkActive=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加路由激活绑定
        /// </summary>
        [Fact]
        public void TestBindActive() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindActive, "a" } };
            var result = new String();
            result.Append( "<a mat-list-item=\"\" [routerLinkActive]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试精确匹配
        /// </summary>
        [Fact]
        public void TestExact() {
            var attributes = new TagHelperAttributeList { { UiConst.Exact,true } };
            var result = new String();
            result.Append( "<a mat-list-item=\"\" [routerLinkActiveOptions]=\"{exact: true}\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<a href=\"a\" mat-list-item=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<a (click)=\"a\" mat-list-item=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}