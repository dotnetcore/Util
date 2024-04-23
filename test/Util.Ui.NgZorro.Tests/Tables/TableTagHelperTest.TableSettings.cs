using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables;

/// <summary>
/// 表格测试 - 表格设置
/// </summary>
public partial class TableTagHelperTest {
    /// <summary>
    /// 测试启用表格设置
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_1() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 设置初始表格尺寸
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_2() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );
        _wrapper.SetContextAttribute( UiConst.Size, TableSize.Small );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" initSize=\"small\" key=\"k\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 设置滚动高度
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_3() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );
        _wrapper.SetContextAttribute( UiConst.ScrollHeight, "1" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" scrollHeight=\"1\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 设置滚动宽度
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_4() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );
        _wrapper.SetContextAttribute( UiConst.ScrollWidth, "1" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" scrollWidth=\"1\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 设置滚动宽高
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_5() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );
        _wrapper.SetContextAttribute( UiConst.Scroll, "{x:'1px',y:'1px'}" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a'}]\" [initScroll]=\"{x:'1px',y:'1px'}\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 设置初始表格边框
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_6() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );
        _wrapper.SetContextAttribute( UiConst.Bordered, "true" );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "b" );
        _wrapper.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" [enableFixedColumn]=\"true\" [initBordered]=\"true\" " );
        result.Append( "[initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 设置完整结构
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_7() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
        th.SetContextAttribute( UiConst.TitleAlign, TableHeadColumnAlign.Center );
        headRow.AppendContent( th );

        //创建表格主体
        var body = new TableBodyTagHelper().ToWrapper();
        _wrapper.AppendContent( body );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        body.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Align, TableHeadColumnAlign.Right );
        column.SetContextAttribute( UiConst.Ellipsis, true );
        row.AppendContent( column );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table nzTableLayout=\"fixed\" [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','titleAlign':'center','align':'right','ellipsis':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 设置完整结构 - 2列
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_8() {
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );

        //创建表头
        var head = new TableHeadTagHelper().ToWrapper();
        _wrapper.AppendContent( head );

        //创建表头行
        var headRow = new TableRowTagHelper().ToWrapper();
        head.AppendContent( headRow );

        //创建表头单元格
        var th = new TableHeadColumnTagHelper().ToWrapper();
        th.SetContextAttribute( UiConst.Title, "a" );
        th.SetContextAttribute( UiConst.TitleAlign, TableHeadColumnAlign.Center );
        headRow.AppendContent( th );

        //创建表头单元格2
        var th2 = new TableHeadColumnTagHelper().ToWrapper();
        th2.SetContextAttribute( UiConst.TitleOperation, true );
        th2.SetContextAttribute( UiConst.Right, "true" );
        headRow.AppendContent( th2 );

        //创建表格主体
        var body = new TableBodyTagHelper().ToWrapper();
        _wrapper.AppendContent( body );

        //创建表格主体行
        var row = new TableRowTagHelper().ToWrapper();
        body.AppendContent( row );

        //创建列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.Column, "b" );
        column.SetContextAttribute( UiConst.Ellipsis, true );
        row.AppendContent( column );

        //创建列2
        var column2 = new TableColumnTagHelper().ToWrapper();
        column2.SetContextAttribute( UiConst.Column, "d" );
        row.AppendContent( column2 );

        //结果
        var result = new StringBuilder();
        result.Append( "<nz-table nzTableLayout=\"fixed\" [nzBordered]=\"ts_id.bordered\" [nzCustomColumn]=\"ts_id.columns\" [nzScroll]=\"ts_id.scroll\" [nzSize]=\"ts_id.size\">" );
        result.Append( "<thead>" );
        result.Append( "<tr>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'a')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"a\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\" [titleAlign]=\"ts_id.getTitleAlign('a')\">" );
        result.Append( "a" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "<th (nzResizeEnd)=\"ts_id.handleResize($event,'Operation')\" " );
        result.Append( "nz-resizable=\"\" nzBounds=\"window\" nzCellControl=\"Operation\" nzPreview=\"\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('Operation')\" [nzRight]=\"ts_id.isRight('Operation')\" [titleAlign]=\"ts_id.getTitleAlign('Operation')\">" );
        result.Append( "Operation" );
        result.Append( "<nz-resize-handle nzDirection=\"right\"></nz-resize-handle>" );
        result.Append( "</th>" );
        result.Append( "</tr>" );
        result.Append( "</thead>" );
        result.Append( "<tbody>" );
        result.Append( "<tr>" );
        result.Append( "<td nzCellControl=\"a\" [nzAlign]=\"ts_id.getAlign('a')\" [nzEllipsis]=\"ts_id.getEllipsis('a')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('a')\" [nzRight]=\"ts_id.isRight('a')\">{{row.b}}</td>" );
        result.Append( "<td nzCellControl=\"Operation\" [nzAlign]=\"ts_id.getAlign('Operation')\" [nzEllipsis]=\"ts_id.getEllipsis('Operation')\" " );
        result.Append( "[nzLeft]=\"ts_id.isLeft('Operation')\" [nzRight]=\"ts_id.isRight('Operation')\">{{row.d}}</td>" );
        result.Append( "</tr>" );
        result.Append( "</tbody>" );
        result.Append( "</nz-table>" );
        result.Append( "<x-table-settings #ts_id=\"\" key=\"k\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a','titleAlign':'center','ellipsis':true},{'title':'Operation','right':true}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试启用表格设置 - 编辑列显示区域嵌套列
    /// </summary>
    [Fact]
    public void TestEnableTableSettings_9() {
        _wrapper.SetContextAttribute( UiConst.Id, "tb" );
        _wrapper.SetContextAttribute( UiConst.Key, "k" );
        _wrapper.SetContextAttribute( UiConst.EnableTableSettings, true );

        //添加列
        var column = new TableColumnTagHelper().ToWrapper();
        column.SetContextAttribute( UiConst.IsEdit, true );
        column.SetContextAttribute( UiConst.Title, "a" );
        column.SetContextAttribute( UiConst.Column, "name" );
        _wrapper.AppendContent( column );

        //添加显示区域
        var display = new TableColumnDisplayTagHelper().ToWrapper();
        var subColumn = new TableColumnTagHelper().ToWrapper();
        subColumn.SetContextAttribute( UiConst.Title, "b" );
        subColumn.SetContextAttribute( UiConst.Column, "c" );
        display.AppendContent( subColumn );
        column.AppendContent( display );

        //添加控件区域
        var control = new TableColumnControlTagHelper().ToWrapper();
        control.AppendContent( "b" );
        column.AppendContent( control );

        //结果
        var result = new StringBuilder();
        result.Append( "<x-table-settings #ts_tb=\"\" key=\"k\" " );
        result.Append( "[enableFixedColumn]=\"true\" [initColumns]=\"[{'title':'a'}]\">" );
        result.Append( "</x-table-settings>" );
        Assert.EndsWith( result.ToString(), GetResult() );
    }
}