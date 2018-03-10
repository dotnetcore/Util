using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.Material;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Tables.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tables {
    /// <summary>
    /// 表格列测试
    /// </summary>
    public class TableColumnTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格列
        /// </summary>
        private readonly TableColumnTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TableColumnTagHelper();
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
            result.Append( "<ng-container></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<ng-container #a=\"\"></ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试列名称
        /// </summary>
        [Fact]
        public void TestColumn() {
            var attributes = new TagHelperAttributeList { { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"a\">" );
            result.Append( "<mat-cell *matCellDef=\"let row\">{{ row.a }}</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<ng-container>" );
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\">a</mat-header-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试启用排序
        /// </summary>
        [Fact]
        public void TestSort() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" },{ UiConst.Sort, true } };
            var result = new String();
            result.Append( "<ng-container>" );
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\" mat-sort-header=\"\">a</mat-header-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置行号类型
        /// </summary>
        [Fact]
        public void TestType_LineNumber() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.LineNumber } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"lineNumber\">" );
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\">ID</mat-header-cell>" );
            result.Append( "<mat-cell *matCellDef=\"let row\">{{ row.lineNumber }}</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置行号类型，同时设置标题
        /// </summary>
        [Fact]
        public void TestType_LineNumber_Title() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.LineNumber }, { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"lineNumber\">" );
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\">a</mat-header-cell>" );
            result.Append( "<mat-cell *matCellDef=\"let row\">{{ row.lineNumber }}</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置复选框类型
        /// </summary>
        [Fact]
        public void TestType_Checkbox() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Checkbox } };
            var items = new Dictionary<object, object> { { MaterialConst.TableId, "id" } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"selectCheckbox\">" );
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\">" );
            result.Append( "<mat-checkbox (change)=\"$event?id.masterToggle():null\" " );
            result.Append( "[checked]=\"id.isMasterChecked()\" " );
            result.Append( "[disabled]=\"!id.dataSource.data.length\" " );
            result.Append( "[indeterminate]=\"id.isMasterIndeterminate()\"></mat-checkbox>" );
            result.Append( "</mat-header-cell>" );
            result.Append( "<mat-cell *matCellDef=\"let row\">" );
            result.Append( "<mat-checkbox " );
            result.Append( "(change)=\"$event?id.selection.toggle(row):null\" " );
            result.Append( "(click)=\"$event.stopPropagation()\" " );
            result.Append( "[checked]=\"id.selection.isSelected(row)\"></mat-checkbox>" );
            result.Append( "</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
        }
    }
}