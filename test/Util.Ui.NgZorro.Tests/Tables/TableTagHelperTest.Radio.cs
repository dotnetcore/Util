using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格测试 - 单选框
    /// </summary>
    public partial class TableTagHelperTest {
        /// <summary>
        /// 测试设置单选框 - 添加一个列
        /// </summary>
        [Fact]
        public void TestShowRadio_1() {
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th [nzWidth]=\"x_id.config.table.radioWidth\"></th>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td>" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 添加一个列 - 同时设置复选框,则单选框不生效
        /// </summary>
        [Fact]
        public void TestShowRadio_2() {
            _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
            result.Append( "[nzShowCheckbox]=\"true\" [nzWidth]=\"x_id.config.table.checkboxWidth\">" );
            result.Append( "</th>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
            result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
            result.Append( "[nzShowCheckbox]=\"true\">" );
            result.Append( "</td>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置复选框 - 手工创建完整结构
        /// </summary>
        [Fact]
        public void TestShowRadio_3() {
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表头单元格
            var th = new TableHeadColumnTagHelper().ToWrapper();
            th.AppendContent( "a" );
            headRow.AppendContent( th );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            body.AppendContent( row );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th [nzWidth]=\"x_id.config.table.radioWidth\"></th>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}