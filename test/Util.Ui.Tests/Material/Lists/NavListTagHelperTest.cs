using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Lists {
    /// <summary>
    /// 导航列表测试
    /// </summary>
    public class NavListTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 导航列表
        /// </summary>
        private readonly NavListTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public NavListTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new NavListTagHelper();
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
            result.Append( "<mat-nav-list></mat-nav-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-nav-list #a=\"\"></mat-nav-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试紧凑模式
        /// </summary>
        [Fact]
        public void TestDense() {
            var attributes = new TagHelperAttributeList { { UiConst.Dense, true } };
            var result = new String();
            result.Append( "<mat-nav-list dense=\"\"></mat-nav-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}