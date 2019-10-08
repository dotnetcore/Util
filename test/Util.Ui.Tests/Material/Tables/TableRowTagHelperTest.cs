using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tables {
    /// <summary>
    /// 表格行测试
    /// </summary>
    public class TableRowTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格行
        /// </summary>
        private readonly RowTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableRowTagHelperTest( ITestOutputHelper output ) {
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
            result.Append( "<mat-header-row>" );
            result.Append( "</mat-header-row>" );
            result.Append( "<mat-row class=\"mat-row-hover\">" );
            result.Append( "</mat-row>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-header-row>" );
            result.Append( "</mat-header-row>" );
            result.Append( "<mat-row #a=\"\" class=\"mat-row-hover\">" );
            result.Append( "</mat-row>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加列
        /// </summary>
        [Fact]
        public void TestColumns() {
            var attributes = new TagHelperAttributeList { { UiConst.Columns, "['a','b']" } };
            var result = new String();
            result.Append( "<mat-header-row *matHeaderRowDef=\"['a','b'];sticky:true\">" );
            result.Append( "</mat-header-row>" );
            result.Append( "<mat-row *matRowDef=\"let row;columns:['a','b']\" class=\"mat-row-hover\">" );
            result.Append( "</mat-row>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加列
        /// </summary>
        [Fact]
        public void TestColumns_2() {
            var attributes = new TagHelperAttributeList { { UiConst.Columns, "'a','b'" } };
            var result = new String();
            result.Append( "<mat-header-row *matHeaderRowDef=\"['a','b'];sticky:true\">" );
            result.Append( "</mat-header-row>" );
            result.Append( "<mat-row *matRowDef=\"let row;columns:['a','b']\" class=\"mat-row-hover\">" );
            result.Append( "</mat-row>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试取消冻结表头
        /// </summary>
        [Fact]
        public void TestSticky_False() {
            var attributes = new TagHelperAttributeList { { UiConst.Columns, "'a','b'" }, { UiConst.StickyHeader, false } };
            var result = new String();
            result.Append( "<mat-header-row *matHeaderRowDef=\"['a','b']\">" );
            result.Append( "</mat-header-row>" );
            result.Append( "<mat-row *matRowDef=\"let row;columns:['a','b']\" class=\"mat-row-hover\">" );
            result.Append( "</mat-row>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.Columns, "'a','b'" }, { UiConst.OnClick, "c" } };
            var result = new String();
            result.Append( "<mat-header-row *matHeaderRowDef=\"['a','b'];sticky:true\">" );
            result.Append( "</mat-header-row>" );
            result.Append( "<mat-row (click)=\"c;\" *matRowDef=\"let row;columns:['a','b']\" class=\"mat-row-hover\">" );
            result.Append( "</mat-row>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}