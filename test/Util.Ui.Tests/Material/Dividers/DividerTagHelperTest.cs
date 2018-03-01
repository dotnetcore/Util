using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material;
using Util.Ui.Material.Dividers.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Dividers {
    /// <summary>
    /// 分隔线测试
    /// </summary>
    public class DividerTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 分隔线
        /// </summary>
        private readonly DividerTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DividerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DividerTagHelper();
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
            result.Append( "<mat-divider></mat-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-divider #a=\"\"></mat-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置间距
        /// </summary>
        [Fact]
        public void TestInset() {
            var attributes = new TagHelperAttributeList { { MaterialConst.Inset, true } };
            var result = new String();
            result.Append( "<mat-divider inset=\"true\"></mat-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置垂直方向
        /// </summary>
        [Fact]
        public void TestVertical() {
            var attributes = new TagHelperAttributeList { { UiConst.Vertical, true } };
            var result = new String();
            result.Append( "<mat-divider vertical=\"true\"></mat-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}