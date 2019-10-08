using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Enums;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Configs;
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
        private readonly ColumnTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableColumnTagHelperTest( ITestOutputHelper output ) {
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
        /// 测试列名称- 取消自动创建
        /// </summary>
        [Fact]
        public void TestColumn_Cancel() {
            var attributes = new TagHelperAttributeList { { UiConst.Column, "a" } };
            var items = new Dictionary<object, object> { { ColumnConfig.ColumnShareKey, new ColumnShareConfig { AutoCreateCell = false } } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"a\">" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
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
        /// 测试添加标题 - 取消自动创建
        /// </summary>
        [Fact]
        public void TestTitle_Cancel() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var items = new Dictionary<object,object>{{ ColumnConfig.ColumnShareKey,new ColumnShareConfig{AutoCreateHeaderCell = false} } };
            var result = new String();
            result.Append( "<ng-container>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
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
            var items = new Dictionary<object, object> { { TableConfig.TableShareKey, new TableShareConfig( "id" ) } };
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
            result.Append( "(change)=\"$event?id.checkedSelection.toggle(row):null\" " );
            result.Append( "(click)=\"$event.stopPropagation()\" " );
            result.Append( "[checked]=\"id.checkedSelection.isSelected(row)\"></mat-checkbox>" );
            result.Append( "</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
        }

        /// <summary>
        /// 测试设置单选框类型
        /// </summary>
        [Fact]
        public void TestType_Radio() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Radio }, { UiConst.Title, "a" } };
            var items = new Dictionary<object, object> { { TableConfig.TableShareKey, new TableShareConfig( "id" ) } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"selectRadio\">" );
            result.Append( "<mat-header-cell *matHeaderCellDef=\"\">" );
            result.Append( "a" );
            result.Append( "</mat-header-cell>" );
            result.Append( "<mat-cell *matCellDef=\"let row\">" );
            result.Append( "<mat-radio-button " );
            result.Append( "(change)=\"$event?id.checkRow(row):null\" " );
            result.Append( "(click)=\"$event.stopPropagation()\" " );
            result.Append( "[checked]=\"id.checkedSelection.isSelected(row)\"></mat-radio-button>" );
            result.Append( "</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
        }

        /// <summary>
        /// 测试设置布尔类型
        /// </summary>
        [Fact]
        public void TestType_Bool() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Bool }, { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"a\">" );
            result.Append( "<mat-cell *matCellDef=\"let row\">" );
            result.Append( "<mat-icon *ngIf=\"row.a\">check</mat-icon>" );
            result.Append( "<mat-icon *ngIf=\"!row.a\">clear</mat-icon>" );
            result.Append( "</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置日期类型
        /// </summary>
        [Fact]
        public void TestType_Date() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Date }, { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"a\">" );
            result.Append( "<mat-cell *matCellDef=\"let row\">" );
            result.Append( "{{ row.a | date:\"yyyy-MM-dd\" }}" );
            result.Append( "</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置日期类型 - 指定格式化字符串
        /// </summary>
        [Fact]
        public void TestType_Date_Format() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Date }, { UiConst.DateFormat, "a" }, { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<ng-container matColumnDef=\"a\">" );
            result.Append( "<mat-cell *matCellDef=\"let row\">" );
            result.Append( "{{ row.a | date:\"a\" }}" );
            result.Append( "</mat-cell>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}