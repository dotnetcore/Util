using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tables {
    /// <summary>
    /// 表格列头测试
    /// </summary>
    public class TableHeaderCellTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格列头
        /// </summary>
        private readonly TableHeaderCellTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableHeaderCellTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TableHeaderCellTagHelper();
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
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\"></mat-header-cell>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-header-cell #a=\"\" *matHeaderCellDef=\"\"></mat-header-cell>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\">a</mat-header-cell>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试启用排序
        /// </summary>
        [Fact]
        public void TestSort() {
            var attributes = new TagHelperAttributeList { { UiConst.Sort, true } };
            var result = new String();
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\" mat-sort-header=\"\"></mat-header-cell>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}