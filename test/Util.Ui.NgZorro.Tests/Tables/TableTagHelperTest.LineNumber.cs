using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables;

/// <summary>
/// 表格测试 - 序号
/// </summary>
public partial class TableTagHelperTest {
    /// <summary>
    /// 测试设置序号 - 添加一个列
    /// </summary>
    [Fact]
    public void TestShowLineNumber_1() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );

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
        result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th>{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td>{{row.lineNumber}}</td>" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置序号 - 添加一个列,同时显示复选框
    /// </summary>
    [Fact]
    public void TestShowLineNumber_2() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );

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
        result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th>{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzShowCheckbox]=\"true\">" );
        result.Append( "</td>" );
        result.Append( "<td>{{row.lineNumber}}</td>" );
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
    public void TestShowLineNumber_3() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );

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
        result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{row.lineNumber}}</td>" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置复选框 - 手工创建完整结构,同时显示复选框
    /// </summary>
    [Fact]
    public void TestShowLineNumber_4() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );

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
        result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
        result.Append( "[nzShowCheckbox]=\"true\" [nzWidth]=\"x_id.config.table.checkboxWidth\">" );
        result.Append( "</th>" );
        result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzShowCheckbox]=\"true\">" );
        result.Append( "</td>" );
        result.Append( "<td>{{row.lineNumber}}</td>" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置序号 - 启用自定义列
    /// </summary>
    [Fact]
    public void TestShowLineNumber_5() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" [titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置序号 - 启用自定义列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestShowLineNumber_6() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" [titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置序号 - 启用自定义列 - 表格设置启用固定列
    /// </summary>
    [Fact]
    public void TestShowLineNumber_7() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" [nzLeft]=\"ts_id.isLeft('util.lineNumber')\" " );
        result.Append( "[nzRight]=\"ts_id.isRight('util.lineNumber')\" [titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('util.lineNumber')\" [nzRight]=\"ts_id.isRight('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置序号 - 启用自定义列 - 表格设置启用固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestShowLineNumber_8() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" [nzLeft]=\"ts_id.isLeft('util.lineNumber')\" " );
        result.Append( "[nzRight]=\"ts_id.isRight('util.lineNumber')\" [titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('util.lineNumber')\" [nzRight]=\"ts_id.isRight('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试设置序号 - 合并列
    /// </summary>
    [Fact]
    public void TestShowLineNumber_9() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );

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
        result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\" [rowSpan]=\"2\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th [colSpan]=\"2\">t</th>" );
        result.Append( "</tr>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "<th>c</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td>{{row.lineNumber}}</td>" );
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
    /// 测试固定序号
    /// </summary>
    [Fact]
    public void TestLineNumberLeft_1() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
        _wrapper.SetContextAttribute( UiConst.LineNumberLeft, "true" );

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
        result.Append( "<th [nzLeft]=\"true\" [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th>{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td [nzLeft]=\"true\">{{row.lineNumber}}</td>" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定序号 - 手工创建完整结构,同时显示固定的复选框
    /// </summary>
    [Fact]
    public void TestLineNumberLeft_2() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
        _wrapper.SetContextAttribute( UiConst.CheckboxLeft, "10px" );
        _wrapper.SetContextAttribute( UiConst.LineNumberLeft, "10px" );

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
        row.SetContextAttribute( AngularConst.NgFor, "let row of x_id.dataSource" );
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
        result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" nzLeft=\"10px\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
        result.Append( "[nzShowCheckbox]=\"true\" [nzWidth]=\"x_id.config.table.checkboxWidth\">" );
        result.Append( "</th>" );
        result.Append( "<th nzLeft=\"10px\" [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource\">" );
        result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nzLeft=\"10px\" [nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzShowCheckbox]=\"true\">" );
        result.Append( "</td>" );
        result.Append( "<td nzLeft=\"10px\">{{row.lineNumber}}</td>" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定序号 - 启用自定义列
    /// </summary>
    [Fact]
    public void TestLineNumberLeft_3() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
        _wrapper.SetContextAttribute( UiConst.LineNumberLeft, "10px" );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" nzLeft=\"10px\" [titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" nzLeft=\"10px\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定序号 - 启用自定义列 - 表格设置启用固定列
    /// </summary>
    [Fact]
    public void TestLineNumberLeft_4() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
        _wrapper.SetContextAttribute( UiConst.LineNumberLeft, "10px" );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" [nzLeft]=\"ts_id.isLeft('util.lineNumber')\" [nzRight]=\"ts_id.isRight('util.lineNumber')\" " );
        result.Append( "[titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('util.lineNumber')\" [nzRight]=\"ts_id.isRight('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定序号 - 启用自定义列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestLineNumberLeft_5() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
        _wrapper.SetContextAttribute( UiConst.LineNumberLeft, "10px" );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" nzLeft=\"10px\" [titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" nzLeft=\"10px\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定序号 - 启用自定义列 - 表格设置启用固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestLineNumberLeft_6() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.ShowLineNumber, true );
        _wrapper.SetContextAttribute( UiConst.LineNumberLeft, true );
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
        result.Append( "<th nzCellControl=\"util.lineNumber\" [nzLeft]=\"ts_id.isLeft('util.lineNumber')\" [nzRight]=\"ts_id.isRight('util.lineNumber')\" " );
        result.Append( "[titleAlign]=\"ts_id.getTitleAlign('util.lineNumber')\">{{'util.lineNumber'|i18n}}</th>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">{{'a'|i18n}}</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"util.lineNumber\" [nzAlign]=\"ts_id.getAlign('util.lineNumber')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('util.lineNumber')\" [nzRight]=\"ts_id.isRight('util.lineNumber')\">{{row.lineNumber}}</td>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'util.lineNumber','width':x_id.config.table.lineNumberWidth,'left':true,'align':'left'},{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }
}