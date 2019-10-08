using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Prime.Enums;
using Util.Ui.Prime.TreeTables.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Prime.TreeTables {
    /// <summary>
    /// 树型表格列测试
    /// </summary>
    public class TreeTableColumnTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 树型表格列
        /// </summary>
        private readonly ColumnTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TreeTableColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ColumnTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null,
            TagHelperContent content = null, IDictionary<object, object> items = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content, items );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<p-column></p-column>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<p-column #a=\"\"></p-column>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试列名称
        /// </summary>
        [Fact]
        public void TestColumn() {
            var attributes = new TagHelperAttributeList { { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<p-column field=\"a\"></p-column>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<p-column header=\"a\"></p-column>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置布尔类型
        /// </summary>
        [Fact]
        public void TestType_Bool() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Bool }, { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<p-column field=\"a\">" );
            result.Append( "<ng-template let-first=\"first\" let-i=\"index\" let-last=\"last\" let-row=\"rowData\">" );
            result.Append( "<mat-icon *ngIf=\"row.data.a\">check</mat-icon>" );
            result.Append( "<mat-icon *ngIf=\"!row.data.a\">clear</mat-icon>" );
            result.Append( "</ng-template>" );
            result.Append( "</p-column>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置日期类型
        /// </summary>
        [Fact]
        public void TestType_Date() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Date }, { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<p-column field=\"a\">" );
            result.Append( "<ng-template let-first=\"first\" let-i=\"index\" let-last=\"last\" let-row=\"rowData\">" );
            result.Append( "{{ row.data.a | date:\"yyyy-MM-dd\" }}" );
            result.Append( "</ng-template>" );
            result.Append( "</p-column>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置日期类型 - 指定格式化字符串
        /// </summary>
        [Fact]
        public void TestType_Date_Format() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Date }, { UiConst.DateFormat, "a" }, { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<p-column field=\"a\">" );
            result.Append( "<ng-template let-first=\"first\" let-i=\"index\" let-last=\"last\" let-row=\"rowData\">" );
            result.Append( "{{ row.data.a | date:\"a\" }}" );
            result.Append( "</ng-template>" );
            result.Append( "</p-column>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}