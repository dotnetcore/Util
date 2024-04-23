using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables; 

/// <summary>
/// 表格测试 - 指令扩展
/// </summary>
public partial class TableTagHelperTest {

    #region QueryParam

    /// <summary>
    /// 测试查询参数
    /// </summary>
    [Fact]
    public void TestQueryParam() {
        _wrapper.SetContextAttribute( UiConst.QueryParam, "b" );
        var result = new StringBuilder();
        result.Append( "<nz-table [(queryParam)]=\"b\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region Sort

    /// <summary>
    /// 测试排序条件
    /// </summary>
    [Fact]
    public void TestSort() {
        _wrapper.SetContextAttribute( UiConst.Sort, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table order=\"a\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region BindSort

    /// <summary>
    /// 测试排序条件
    /// </summary>
    [Fact]
    public void TestBindSort() {
        _wrapper.SetContextAttribute( AngularConst.BindSort, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table [order]=\"a\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region CheckedKeys

    /// <summary>
    /// 测试复选框选中的标识列表
    /// </summary>
    [Fact]
    public void TestCheckedKeys() {
        _wrapper.SetContextAttribute( UiConst.CheckedKeys, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table [checkedKeys]=\"a\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region Url

    /// <summary>
    /// 测试Api地址
    /// </summary>
    [Fact]
    public void TestUrl_1() {
        _wrapper.SetContextAttribute( UiConst.Url, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 添加表格总行数模板标签
    /// </summary>
    /// <param name="result">结果</param>
    private void AppendTotalTemplate( StringBuilder result ) {
        result.Append( "<ng-template #total_id=\"\" let-range=\"range\" let-total=\"\">" );
        result.Append( "{{ 'util.tableTotalTemplate'|i18n:{start:range[0],end:range[1],total:total} }}" );
        result.Append( "</ng-template>" );
    }

    /// <summary>
    /// 测试Api地址 - 添加一个列,自动创建嵌套结构
    /// </summary>
    [Fact]
    public void TestUrl_2() {
        //设置baseurl属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试Api地址 - 自定义表格主体行的*ngFor 
    /// </summary>
    [Fact]
    public void TestUrl_3() {
        //设置baseurl属性
        _wrapper.SetContextAttribute( UiConst.Url, "a" );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        head.SetContextAttribute( "hidden", "true" );
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
        row.SetContextAttribute( AngularConst.NgFor, "a" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.AppendContent( "b" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "url=\"a\" x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "<thead [hidden]=\"true\">" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr *ngFor=\"a\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region BindUrl

    /// <summary>
    /// 测试Api地址
    /// </summary>
    [Fact]
    public void TestBindUrl() {
        _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\" [url]=\"a\">" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region DeleteUrl

    /// <summary>
    /// 测试删除地址
    /// </summary>
    [Fact]
    public void TestDeleteUrl() {
        _wrapper.SetContextAttribute( UiConst.DeleteUrl, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table deleteUrl=\"a\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region BindDeleteUrl

    /// <summary>
    /// 测试删除地址
    /// </summary>
    [Fact]
    public void TestBindDeleteUrl() {
        _wrapper.SetContextAttribute( AngularConst.BindDeleteUrl, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table [deleteUrl]=\"a\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region AutoLoad

    /// <summary>
    /// 测试自动加载
    /// </summary>
    [Fact]
    public void TestAutoLoad() {
        _wrapper.SetContextAttribute( UiConst.AutoLoad, false );
        var result = new StringBuilder();
        result.Append( "<nz-table [autoLoad]=\"false\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region EnableExtend

    /// <summary>
    /// 测试启用扩展
    /// </summary>
    [Fact]
    public void TestEnableExtend() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用扩展 - 当启用扩展时,设置数据源会先输入到扩展指令再导出
    /// </summary>
    [Fact]
    public void TestEnableExtend_Data() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.Data, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[dataSource]=\"a\" [nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用扩展 - 覆盖是否显示改变分页大小按钮
    /// </summary>
    [Fact]
    public void TestEnableExtend_ShowSizeChanger() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.ShowSizeChanger, "false" );
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"false\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用扩展 - 覆盖是否显示分页快速跳转
    /// </summary>
    [Fact]
    public void TestEnableExtend_ShowQuickJumper() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.ShowQuickJumper, "false" );
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"false\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用扩展 - 覆盖总行数
    /// </summary>
    [Fact]
    public void TestEnableExtend_Total() {
        _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
        _wrapper.SetContextAttribute( UiConst.Total, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table #x_id=\"xTableExtend\" " );
        result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
        result.Append( "x-table-extend=\"\" " );
        result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
        result.Append( "[nzData]=\"x_id.dataSource\" " );
        result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzPageSizeOptions]=\"x_id.pageSizeOptions\" [nzShowQuickJumper]=\"true\" " );
        result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"a\">" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region SelectOnClickRow

    /// <summary>
    /// 测试单击选中行
    /// </summary>
    [Fact]
    public void TestSelectOnClickRow_1() {
        //设置单击选中行
        _wrapper.SetContextAttribute( UiConst.SelectOnClickRow, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr (click)=\"x_id.toggleSelect(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单击选中行 - 手工创建行
    /// </summary>
    [Fact]
    public void TestSelectOnClickRow_2() {
        //设置单击选中行
        _wrapper.SetContextAttribute( UiConst.SelectOnClickRow, true );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        //设置行单击事件
        row.SetContextAttribute( UiConst.OnClick, "d" );
        _wrapper.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr (click)=\"d;x_id.toggleSelect(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region SelectOnlyOnClickRow

    /// <summary>
    /// 测试单击仅选中一行
    /// </summary>
    [Fact]
    public void TestSelectOnlyOnClickRow_1() {
        //设置单击选中行
        _wrapper.SetContextAttribute( UiConst.SelectOnlyOnClickRow, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr (click)=\"x_id.selectRowOnly(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单击仅选中一行 - 手工创建行
    /// </summary>
    [Fact]
    public void TestSelectOnlyOnClickRow_2() {
        //设置单击选中行
        _wrapper.SetContextAttribute( UiConst.SelectOnlyOnClickRow, true );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        //设置行单击事件
        row.SetContextAttribute( UiConst.OnClick, "d" );
        _wrapper.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr (click)=\"d;x_id.selectRowOnly(row)\" [class.table-row-selected]=\"x_id.isSelected(row)\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region CheckOnClickRow

    /// <summary>
    /// 测试点击表格行时是否选中复选框或单选框 - 复选框
    /// </summary>
    [Fact]
    public void TestCheckOnClickRow_1() {
        _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
        _wrapper.SetContextAttribute( UiConst.CheckOnClickRow, true );

        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

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
        result.Append( "<tr (click)=\"x_id.toggle(row)\" *ngFor=\"let row of x_id.dataSource;index as index\">" );
        result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
        result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
        result.Append( "[nzShowCheckbox]=\"true\">" );
        result.Append( "</td>" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        AppendTotalTemplate( result );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试点击表格行时是否选中复选框或单选框 - 单选框
    /// </summary>
    [Fact]
    public void TestCheckOnClickRow_2() {
        _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
        _wrapper.SetContextAttribute( UiConst.CheckOnClickRow, true );

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
        result.Append( "<tr (click)=\"x_id.checkRowOnly(row)\" *ngFor=\"let row of x_id.dataSource;index as index\">" );
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

    #endregion

    #region OnLoad

    /// <summary>
    /// 测试数据加载完成事件
    /// </summary>
    [Fact]
    public void TestOnLoad() {
        _wrapper.SetContextAttribute( UiConst.OnLoad, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-table (onLoad)=\"a\"></nz-table>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region OnClickRow

    /// <summary>
    /// 测试行单击事件
    /// </summary>
    [Fact]
    public void TestOnClickRow_1() {
        //设置行单击事件
        _wrapper.SetContextAttribute( UiConst.OnClickRow, "c" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr (click)=\"c\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试行单击事件 - 同时设置OnClickRow和行上的OnClick
    /// </summary>
    [Fact]
    public void TestOnClickRow_2() {
        //设置行单击事件
        _wrapper.SetContextAttribute( UiConst.OnClickRow, "c" );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        //设置行单击事件
        row.SetContextAttribute( UiConst.OnClick, "d" );
        _wrapper.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.AppendContent( "b" );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr (click)=\"d;c\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试行单击事件 - 设置完整结构
    /// </summary>
    [Fact]
    public void TestOnClickRow_3() {
        //设置行单击事件
        _wrapper.SetContextAttribute( UiConst.OnClickRow, "c" );

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
        result.Append( "<nz-table>" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr (click)=\"c\">" );
        result.Append( "<td>b</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion

    #region IsBatchEdit

    /// <summary>
    /// 测试启用批量编辑模式
    /// </summary>
    [Fact]
    public void TestIsBatchEdit() {
        //创建表格
        _wrapper.SetContextAttribute( UiConst.IsBatchEdit, true );

        //添加列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.IsEdit, true );
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //添加输入框组件
        var input = new InputTagHelper().ToWrapper();
        column.AppendContent( input );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table #e_id=\"xEditTable\" x-edit-table=\"\" [isBatch]=\"true\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th>a</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr #id_row=\"xEditRow\" (click)=\"e_id.clickEdit(row.id)\" (dblclick)=\"e_id.dblClickEdit(row.id)\" [x-edit-row]=\"row\">" );
        result.Append( "<td>" );
        result.Append( "<ng-container *ngIf=\"e_id.editId !== row.id;else e_id_b\">" );
        result.Append( "{{row.b}}" );
        result.Append( "</ng-container>" );
        result.Append( "<ng-template #e_id_b=\"\">" );
        result.Append( "<input #c_id=\"\" nz-input=\"\" [editRow]=\"id_row\" [x-edit-control]=\"c_id\" />" );
        result.Append( "</ng-template>" );
        result.Append( "</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );

        //验证
        Assert.Equal( result.ToString(), GetResult() );
    }

    #endregion
}