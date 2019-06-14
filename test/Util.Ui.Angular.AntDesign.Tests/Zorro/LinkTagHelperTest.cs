using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Links;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro {
    /// <summary>
    /// 链接测试
    /// </summary>
    public class LinkTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 按钮
        /// </summary>
        private readonly LinkTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LinkTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new LinkTagHelper();
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
            result.Append( "<a nz-button=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<a #a=\"\" nz-button=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试判断
        /// </summary>
        [Fact]
        public void TestNgIf() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgIf, "a" } };
            var result = new String();
            result.Append( "<a *ngIf=\"a\" nz-button=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            var attributes = new TagHelperAttributeList { { UiConst.Text, "a" } };
            var result = new String();
            result.Append( "<a nz-button=\"\">a</a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试绑定文本
        /// </summary>
        [Fact]
        public void TestBindText() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindText, "a" } };
            var result = new String();
            result.Append( "<a nz-button=\"\">{{a}}</a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<a nz-button=\"\" nzType=\"primary\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestSize() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, ButtonSize.Small } };
            var result = new String();
            result.Append( "<a nz-button=\"\" nzSize=\"small\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<a nz-button=\"\" [disabled]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试提示
        /// </summary>
        [Fact]
        public void TestTooltip() {
            var attributes = new TagHelperAttributeList { { UiConst.Tooltip, "a" } };
            var result = new String();
            result.Append( "<a nz-button=\"\" nz-tooltip=\"\" nzTitle=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试路由链接地址
        /// </summary>
        [Fact]
        public void TestLink() {
            var attributes = new TagHelperAttributeList { { UiConst.Link, "a" } };
            var result = new String();
            result.Append( "<a nz-button=\"\" routerLink=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试路由链接地址
        /// </summary>
        [Fact]
        public void TestBindLink() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindLink, "a" } };
            var result = new String();
            result.Append( "<a nz-button=\"\" [routerLink]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParams() {
            var attributes = new TagHelperAttributeList { { UiConst.QueryParams, "a" } };
            var result = new String();
            result.Append( "<a nz-button=\"\" [queryParams]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<a (click)=\"a\" nz-button=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
