using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格单元格测试 - 指令扩展
    /// </summary>
    public partial class TableColumnTagHelperTest {

        #region 辅助操作

        /// <summary>
        /// 添加启用扩展的表格起始标签
        /// </summary>
        /// <param name="result">结果</param>
        private void AppendExtendTable( StringBuilder result ) {
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        }

        /// <summary>
        /// 添加表格总行数模板标签
        /// </summary>
        /// <param name="result">结果</param>
        private void AppendTotalTemplate( StringBuilder result ) {
            result.Append( "<ng-template #total_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( NgZorroOptionsService.GetOptions().TableTotalTemplate );
            result.Append( "</ng-template>" );
        }

        #endregion

        #region Title

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题和内容
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion

        #region Column

        /// <summary>
        /// 测试列名
        /// </summary>
        [Fact]
        public void TestColumn() {
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列名
        /// </summary>
        [Fact]
        public void TestColumn_2() {
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var input = new InputTagHelper().ToWrapper();
            _wrapper.AppendContent( input );
            var result = new StringBuilder();
            result.Append( "<td><input nz-input=\"\" /></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LineNumber

        /// <summary>
        /// 测试行号
        /// </summary>
        [Fact]
        public void TestType_LineNumber() {
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.LineNumber );
            var result = new StringBuilder();
            result.Append( "<td>{{row.lineNumber}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行号标题
        /// </summary>
        [Fact]
        public void TestType_LineNumber_Title() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置行号类型
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.LineNumber );

            //结果
            var result = new StringBuilder();
            AppendExtendTable( result );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{x_id.config.text.lineNumber}}</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td>{{row.lineNumber}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 测试设置复选框类型
        /// </summary>
        [Fact]
        public void TestType_Checkbox() {
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.Checkbox );
            var result = new StringBuilder();
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.checkedSelection.toggle(row)\" " );
            result.Append( "[nzChecked]=\"x_id.checkedSelection.isSelected(row)\" " );
            result.Append( "[nzShowCheckbox]=\"x_id.multiple\">" );
            result.Append( "</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表头复选框
        /// </summary>
        [Fact]
        public void TestType_Checkbox_Head() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置复选框类型
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.Checkbox );

            //结果
            var result = new StringBuilder();
            AppendExtendTable( result );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
            result.Append( "[nzShowCheckbox]=\"x_id.multiple\" [nzWidth]=\"x_id.config.table.checkboxWidth\">" );
            result.Append( "</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.checkedSelection.toggle(row)\" " );
            result.Append( "[nzChecked]=\"x_id.checkedSelection.isSelected(row)\" " );
            result.Append( "[nzShowCheckbox]=\"x_id.multiple\">" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion

        #region Bool

        /// <summary>
        /// 测试布尔类型列
        /// </summary>
        [Fact]
        public void TestType_Bool() {
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.Bool );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>{{row.a?'x_id.config.text.yes':'x_id.config.text.no'}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Width

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题,内容,宽度
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Width, "100" );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th nzWidth=\"100px\">a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion
    }
}