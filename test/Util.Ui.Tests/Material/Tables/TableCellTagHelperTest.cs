using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tables {
    /// <summary>
    /// 表格单元格测试
    /// </summary>
    public class TableCellTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格单元格
        /// </summary>
        private readonly TableCellTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableCellTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TableCellTagHelper();
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
            result.Append( "<mat-cell *matCellDef=\"let row\"></mat-cell>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-cell #a=\"\" *matCellDef=\"let row\"></mat-cell>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}