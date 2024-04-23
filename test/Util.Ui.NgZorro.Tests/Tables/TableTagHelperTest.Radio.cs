using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables; 

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
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
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
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
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
    /// 测试设置复选框 - 创建完整结构
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
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
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

    /// <summary>
    /// 测试设置单选框 - 启用自定义列
    /// </summary>
    [Fact]
    public void TestShowRadio_4() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.radio\" [nzAlign]=\"ts_id.getAlign('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置单选框 - 启用自定义列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestShowRadio_5() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.radio\" [nzAlign]=\"ts_id.getAlign('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置单选框 - 启用自定义列 - 表格设置启用固定列
    /// </summary>
    [Fact]
    public void TestShowRadio_6() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.radio\" [nzAlign]=\"ts_id.getAlign('util.radio')\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置单选框 - 启用自定义列 - 表格设置启用固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestShowRadio_7() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.radio\" [nzAlign]=\"ts_id.getAlign('util.radio')\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置单选框 - 合并列
    /// </summary>
    [Fact]
    public void TestShowRadio_8() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.AppendContent( "t" );
        th.SetContextAttribute( UiConst.Colspan, 2 );
        headRow.AppendContent( th );

        //创建表头行2
        var headRow2 = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow2 );

        //创建表头单元格
        var th21 = new TableHeadColumnTagHelper().ToWrapper();
        th21.AppendContent( "a" );
        headRow2.AppendContent( th21 );

        //创建表头单元格2
        var th22 = new TableHeadColumnTagHelper().ToWrapper();
        th22.AppendContent( "c" );
        headRow2.AppendContent( th22 );

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

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.AppendContent( "d" );
        row.AppendContent( column2 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th [nzWidth]=\"x_id.config.table.radioWidth\" [rowSpan]=\"2\"></th>" );
        result.Append( "<th [colSpan]=\"2\">t</th>" );
        result.Append( "</tr>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "<th>c</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td>b</td>" );
        result.Append( "<td>d</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定单选框
    /// </summary>
    [Fact]
    public void TestRadioLeft_1() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.RadioLeft, "10px" );

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
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzLeft=\"10px\" [nzWidth]=\"x_id.config.table.radioWidth\"></th>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzLeft=\"10px\">" );
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
    /// 测试固定单选框 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestRadioLeft_2() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.RadioLeft, "10px" );

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
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzLeft=\"10px\" [nzWidth]=\"x_id.config.table.radioWidth\"></th>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzLeft=\"10px\">" );
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
    /// 测试固定单选框 - 启用自定义列
    /// </summary>
    [Fact]
    public void TestRadioLeft_3() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.RadioLeft, "10px" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" nzLeft=\"10px\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.radio\" nzLeft=\"10px\" [nzAlign]=\"ts_id.getAlign('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定单选框 - 启用自定义列 - 表格设置启用固定列
    /// </summary>
    [Fact]
    public void TestRadioLeft_4() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.RadioLeft, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.radio\" [nzAlign]=\"ts_id.getAlign('util.radio')\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定单选框 - 启用自定义列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestRadioLeft_5() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.RadioLeft, "10px" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" nzLeft=\"10px\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.radio\" nzLeft=\"10px\" [nzAlign]=\"ts_id.getAlign('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定单选框 - 启用自定义列 - 表格设置启用固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestRadioLeft_6() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.RadioLeft, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
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
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" " );
        result.Append( "[nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
        result.Append( "[nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"util.radio\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\" [titleAlign]=\"ts_id.getTitleAlign('util.radio')\"></th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.radio\" [nzAlign]=\"ts_id.getAlign('util.radio')\" [nzLeft]=\"ts_id.isLeft('util.radio')\" [nzRight]=\"ts_id.isRight('util.radio')\">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.radio','width':x_id.config.table.radioWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }
}