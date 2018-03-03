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
    /// 选择列表项测试
    /// </summary>
    public class SelectListOptionTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 选择列表项
        /// </summary>
        private readonly SelectListOptionTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectListOptionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new SelectListOptionTagHelper();
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
            result.Append( "<mat-list-option></mat-list-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-list-option #a=\"\"></mat-list-option>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加循环
        /// </summary>
        [Fact]
        public void TestNgFor() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgFor, "a" } };
            var result = new String();
            result.Append( "<mat-list-option *ngFor=\"a\"></mat-list-option>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}