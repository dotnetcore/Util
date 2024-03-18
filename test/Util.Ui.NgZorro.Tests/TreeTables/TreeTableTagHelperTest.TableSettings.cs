using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.TreeTables;
/// <summary>
/// 树形表格测试 - 表格设置测试
/// </summary>
public partial class TreeTableTagHelperTest {

    #region EnableCustomColumn

    /// <summary>
    /// 测试启用自定义列 - 1列
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_1() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 2列
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_2() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.SetContextAttribute( UiConst.Title, "c" );
        column2.AppendContent( "d" );
        _wrapper.AppendContent( column2 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "<th nzCellControl=\"c\" [titleAlign]=\"ts_id.getTitleAlign('c')\">c</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "<td " );
        result.Append( "nzCellControl=\"c\" [nzAlign]=\"ts_id.getAlign('c')\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('c')\">" );
        result.Append( "d</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'},{'title':'c'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 1列  - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_3() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 2列  - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_4() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
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

        //创建表头单元格2
        var th2 = new TableHeadColumnTagHelper().ToWrapper();
        th2.SetContextAttribute( UiConst.Title, "c" );
        headRow.AppendContent( th2 );

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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "<th nzCellControl=\"c\" [titleAlign]=\"ts_id.getTitleAlign('c')\">c</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "<td " );
        result.Append( "nzCellControl=\"c\" [nzAlign]=\"ts_id.getAlign('c')\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('c')\">" );
        result.Append( "d</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'},{'title':'c'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置复选框
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_5() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置复选框 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_6() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置单选框
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_7() {
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置单选框 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_8() {
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 固定列
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_9() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Left, "10px" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzLeft=\"10px\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" nzLeft=\"10px\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_10() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
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
        th.SetContextAttribute( UiConst.Left, "10px" );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzLeft=\"10px\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" nzLeft=\"10px\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置复选框 - 固定列
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_11() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Left, "10px" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzLeft=\"10px\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" nzLeft=\"10px\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置复选框 - 固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_12() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
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
        th.SetContextAttribute( UiConst.Left, "10px" );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzLeft=\"10px\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" nzLeft=\"10px\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置单选框 - 固定列
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_13() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Left, "10px" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzLeft=\"10px\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" nzLeft=\"10px\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用自定义列 - 设置单选框 - 固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableCustomColumn_14() {
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
        th.SetContextAttribute( UiConst.Left, "10px" );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" nzLeft=\"10px\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" nzLeft=\"10px\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region EnableResizable

    /// <summary>
    /// 测试启用拖动调整列宽
    /// </summary>
    [Fact]
    public void TestEnableResizable_1() {
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableResizable_2() {
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 设置复选框
    /// </summary>
    [Fact]
    public void TestEnableResizable_3() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 设置复选框 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableResizable_4() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 设置单选框
    /// </summary>
    [Fact]
    public void TestEnableResizable_5() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用拖动调整列宽 - 设置单选框 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableResizable_6() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableResizable, true );

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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzPreview=\"\" [nzWidth]=\"ts_id.getWidth('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region EnableFixedColumn

    /// <summary>
    /// 测试固定列
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_1() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Left, true );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定列 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_2() {
        //设置url属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
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
        th.SetContextAttribute( UiConst.Left, true );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定列 - 设置复选框
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_3() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Left, true );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定列 - 设置复选框 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_4() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
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
        th.SetContextAttribute( UiConst.Left, true );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
        result.Append( "a" );
        result.Append( "</label>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label " );
        result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "nz-checkbox=\"\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定列 - 设置单选框
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_5() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.Key, "a" );
        _wrapper.SetContextAttribute( UiConst.EnableCustomColumn, true );
        _wrapper.SetContextAttribute( UiConst.EnableFixedColumn, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Left, true );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</ng-container>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试固定列 - 设置单选框 - 创建完整结构
    /// </summary>
    [Fact]
    public void TestEnableFixedColumn_6() {
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
        th.SetContextAttribute( UiConst.Left, true );
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
        result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-tree-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzScroll]=\"ts_id.scroll\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzSize]=\"ts_id.size\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th nzCellControl=\"a\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td " );
        result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" nzCellControl=\"a\" " );
        result.Append( "[nzEllipsis]=\"ts_id.getEllipsis('a')\" [nzExpand]=\"x_id.isExpand(row)\" " );
        result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" [nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" " );
        result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
        result.Append( ">" );
        result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
        result.Append( "b" );
        result.Append( "</label>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"a\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','left':true}]\" [isTreeTable]=\"true\">" );
        result.Append( "</x-table-settings>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion
}
