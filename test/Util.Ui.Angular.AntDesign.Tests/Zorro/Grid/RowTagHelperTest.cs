using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Grid;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Grid {
    /// <summary>
    /// 栅格行测试
    /// </summary>
    public class RowTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 栅格行
        /// </summary>
        private readonly RowTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RowTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new RowTagHelper();
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
            result.Append( "<div nz-row=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<div #a=\"\" nz-row=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试间隔
        /// </summary>
        [Fact]
        public void TestGutter() {
            var attributes = new TagHelperAttributeList { { UiConst.Gutter, 2 } };
            var result = new String();
            result.Append( "<div nz-row=\"\" [nzGutter]=\"2\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否flex模式
        /// </summary>
        [Fact]
        public void TestIsFlex() {
            var attributes = new TagHelperAttributeList { { UiConst.IsFlex, true } };
            var result = new String();
            result.Append( "<div nz-row=\"\" nzType=\"flex\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否flex模式
        /// </summary>
        [Fact]
        public void TestIsFlex_False() {
            var attributes = new TagHelperAttributeList { { UiConst.IsFlex, false } };
            var result = new String();
            result.Append( "<div nz-row=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试垂直对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            var attributes = new TagHelperAttributeList { { UiConst.Align, Align.Middle } };
            var result = new String();
            result.Append( "<div nz-row=\"\" nzAlign=\"middle\" nzType=\"flex\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试水平排列方式
        /// </summary>
        [Fact]
        public void TestJustify() {
            var attributes = new TagHelperAttributeList { { UiConst.Justify, Justify.Center } };
            var result = new String();
            result.Append( "<div nz-row=\"\" nzJustify=\"center\" nzType=\"flex\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}